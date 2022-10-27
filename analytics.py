import pandas as pd
import csv

#
# 1 - Level Clear Rate (%)
#
def levelClearRate():
    level_start_dict = dict()
    level_end_dict = dict()
    level_clear_rate = dict()

    for level in level_index_dict:
        level_start_dict[level] = 0
        level_end_dict[level] = 0
        level_clear_rate[level] = 0

    # count num of 0 and 1 for each level index
    for line in range(size):
        if (df['Status'][line] == 0):
            level_start_dict[df['Level index'][line]] += 1
        elif (df['Status'][line] == 1):
            level_end_dict[df['Level index'][line]] += 1

    # calculate level clear rate
    for key in level_clear_rate:
        if level_start_dict[key] == 0:
            continue
        ratio = float("{:.4f}".format(float(level_end_dict[key]) / level_start_dict[key]))
        level_clear_rate[key] = ratio

    return level_clear_rate

#
# 2 - Game time (total)
# total minutes spent in game for individual users
#
def total_game_time():
    session_duration_dict = dict()
    time_distribution_dict = {
        "<1min": 0,
        "1-2min": 0,
        "2-3min": 0,
        "3-4min": 0,
        "4-5min": 0,
        "5-6min": 0,
        ">6min": 0
    }

    for session in sessionID_dict:
        df2 = df.loc[df['sessionID'] == session]
        start = df2.iloc[0]['G_Timestamp']
        end = df2.iloc[-1]['G_Timestamp']
        session_duration_dict[session] = float("{:.2f}".format(pd.Timedelta(end - start).seconds / 60.0))

    for session in session_duration_dict:
        if session_duration_dict[session] < 1:
            time_distribution_dict["<1min"]+=1
        elif session_duration_dict[session] <2:
            time_distribution_dict["1-2min"]+=1
        elif session_duration_dict[session] < 3:
            time_distribution_dict["2-3min"]+=1
        elif session_duration_dict[session] < 4:
            time_distribution_dict["3-4min"]+=1
        elif session_duration_dict[session] < 5:
            time_distribution_dict["4-5min"]+=1
        elif session_duration_dict[session] < 6:
            time_distribution_dict["5-6min"]+=1
        else:
            time_distribution_dict[">6min"] += 1

    for key in time_distribution_dict:
        time_distribution_dict[key] = float("{:.2f}".format(1.0 * time_distribution_dict[key] / unique_users))

    return time_distribution_dict

#
# 3 - Game time (level avg)
#
def level_game_time():
    level_duration_dict = dict()
    single_level_time_dict = dict()
    level_play_dict= dict()

    for level in level_index_dict:
        level_duration_dict[level] = 0
        single_level_time_dict[level] = []

    for ulid in ULID_dict:
        end = df.loc[(df['ULID'] == ulid) & (df['Status'] == 1), 'G_Timestamp']
        if(end.empty):
            continue
        start = df.loc[(df['ULID'] == ulid) & (df['Status'] == 0), 'G_Timestamp']
        end_time = end.iloc[0]
        start_time = start.iloc[0]
        interval = pd.Timedelta(end_time - start_time).seconds

        # get level index
        idx = (df.loc[df['ULID'] == ulid, 'Level index']).iloc[0]

        single_level_time_dict[idx].append(interval)

    # level avg
    for index in level_duration_dict:
        level_duration_dict[index] = float("{:.2f}".format(sum(single_level_time_dict[index]) / float(len((single_level_time_dict[index])))))

    return level_duration_dict

#
# 4 - Percent of players who continue with the same mechanism after tutorial (%)
#
def tutorial_continue_rate():
    mechanism_continue_dict = dict()

    for tutorial in tutorial_level_set:

        mechanism_continue_dict[tutorial] = 0

        for session in sessionID_dict:
            df2 = df.loc[df["sessionID"] == session, "Level index"]
            data_list = df2.values.tolist()
            res = set(data_list).intersection(tutorial_basic_relation_dict[tutorial])
            if len(res) > 0:
                mechanism_continue_dict[tutorial] += 1
        mechanism_continue_dict[tutorial] = float("{:.5f}".format(mechanism_continue_dict[tutorial] / float(unique_users)))


    return mechanism_continue_dict



#
# 5 - Level Replay Rate (%)
#
def replay_rate():
    level_replay_dict = dict()

    for key in level_index_dict:

        level_replay_dict[key] = 0

        df2 = df.loc[(df['Level index'] == key) & (df['Status'] == 0)]

        total_plays = len(df2)
        unique_plays = len(df2['sessionID'].value_counts())

        replay = float("{:.4f}".format( 1.0 - float(unique_plays) / total_plays ))

        level_replay_dict[key] = replay

    return level_replay_dict

#
# 6 - Mechanism Play Rate(%)
#
def mechanism_play_rate():
    mechanism_play_dict = {"Basic":0, "SuperItem":0, "Catapult": 0, "Brush":0, "Wind":0, "Fragile": 0, "Obstacle": 0, "ColorAdd": 0, "Magnetic":0, "Night": 0}
    mechanism_count_dict = dict()
    mechanism_play_rate_dict = dict()

    # count occurance of each level
    df2 = df.loc[df['Status'] == 0].groupby(by='Level index', as_index=False).size()
    level_count_dict = dict(zip(df2['Level index'], df2['size']))

    for key in level_index_dict:
        mechanism_count_dict[key] = len(level_to_mechanism_dict[key])
        mechanism_count_dict[key] *= level_count_dict[key]
    mechanism_sum = sum(mechanism_count_dict.values())

    for key in level_to_mechanism_dict:
        for mechanism in level_to_mechanism_dict[key]:
            if key not in level_count_dict:
                continue
            mechanism_play_dict[mechanism] += level_count_dict[key]

    for key in mechanism_play_dict:
        mechanism_play_rate_dict[key] = float("{:.4f}".format( 1.0 * (mechanism_play_dict[key]) / mechanism_sum ))

    return mechanism_play_rate_dict


def process_time():
    df.loc[:, 'G_Timestamp'] = pd.to_datetime(df['G_Timestamp'], format='%Y/%m/%d %I:%M:%S %p MDT')

if __name__ == '__main__':

    # header = ['G_Time','session_ID','level_index','ULID','W_Time','status','path']
    df = pd.read_csv("Analytics-mt.csv", header=0)
    size = len(df)
    unique_users = len(df['sessionID'].value_counts())

    sessionID_dict = set(df['sessionID'])
    ULID_dict = set(df['ULID'])
    level_index_dict = set(df['Level index'])
    tutorial_level_set = {1, 26, 5, 8, 11, 15, 17, 18, 21, 23}
    tutorial_basic_relation_dict = {
        1: [2,3],
        26:[],
        5:[6,7],
        8:[9,10],
        11:[12,13,14],
        15:[16],
        17:[],
        18:[19],
        21:[],
        23:[]
    }

    tutorial_mechanism_relation_dict = {
        1: "Basic",
        26:"SuperItem",
        5:"Catapult",
        8:"Brush",
        11:"Wind",
        15:"Fragile",
        17:"Obstacle",
        18:"ColorAdd",
        21:"Night",
        23:"Magnetic"
    }

    level_to_mechanism_dict = {
        1:["Basic"],
        2:["Basic"],
        3:["Basic"],
        4:["SuperItem", "Basic"],
        5:["Catapult"],
        6:["Catapult"],
        7:["Catapult"],
        8:["Brush"],
        9:["Brush"],
        10:["Brush"],
        11:["Wind"],
        12:["Wind"],
        13:["Wind"],
        14:["Wind"],
        15:["Fragile"],
        16:["Fragile"],
        17:["Obstacle"],
        18:["ColorAdd"],
        19:["ColorAdd"],
        20: ["Catapult", "Obstacle", "Magnetic", "Basic"],
        21:["Night"],
        22: ["Wind", "ColorAdd", "Basic"],
        23:["Magnetic"],
        24: ["Night", "ColorAdd", "Basic"],
        25: ["Catapult", "Magnetic", "Brush", "Basic"],
        26:["SuperItem"],
        27: ["Obstacle", "Fragile", "Magnetic", "Basic"]
    }

    e_mechanism_play_rate = {"Basic":9, "SuperItem":2, "Catapult": 5, "Brush":4, "Wind":5, "Fragile": 3, "Obstacle": 3,
                           "ColorAdd": 4, "Magnetic":4, "Night": 2}
    e_tot_mech = 41

    for key in e_mechanism_play_rate:
        e_mechanism_play_rate[key] = float("{:.4f}".format( 1.0 * e_mechanism_play_rate[key] / e_tot_mech ))

    # process timestamp
    process_time()

    level_clear_ratio = levelClearRate()

    total_time = total_game_time()

    avg_level_play_time = level_game_time()

    mechanism_continue_ratio = tutorial_continue_rate()

    replay_ratio = replay_rate()

    mechanism_play = mechanism_play_rate()

    # output
    with open('1 - Level Clear Rate.csv', 'w') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerow(["Level index","% of players cleared"])
        for key, value in level_clear_ratio.items():
            writer.writerow([key, value])
        csv_file.close()

    with open('2 - Total Game Time.csv', 'w') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerow(["Time Range","% of players"])
        for key, value in total_time.items():
            writer.writerow([key, value])
        csv_file.close()

    with open('3 - Avg Level Clear Time.csv', 'w') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerow(["Level index","Avg Clear Time (sec)"])
        for key, value in avg_level_play_time.items():
            writer.writerow([key, value])
        csv_file.close()

    with open('4 - Mechanism Continue Rate.csv', 'w') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerow(["Level index (tutorial)","Correspond mechanism","% of player continue after playing tutorial"])
        for key, value in mechanism_continue_ratio.items():
            writer.writerow([key, tutorial_mechanism_relation_dict[key], value])
        csv_file.close()

    with open('5 - Level Replay Rate.csv', 'w') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerow(["Level index","% of player replay the level"])
        for key, value in replay_ratio.items():
            writer.writerow([key, value])
        csv_file.close()

    with open('6 - Mechanism Play Rate.csv', 'w') as csv_file:
        writer = csv.writer(csv_file)
        writer.writerow(["Mechanism","% actual play rate", "% expected play rate"])
        for key, value in mechanism_play.items():
            writer.writerow([key, value, e_mechanism_play_rate[key]])
        csv_file.close()


