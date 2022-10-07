using System;

namespace Utility
{
    public class FinishJson
    {
        private SimpleJson json = new SimpleJson();
        
        public void AddSessionID(long id)
        {
            json.Put("sessionID", id);
        }

        public void AddLevelClearTime(String levelTime)
        {
            json.Put("LevelClearTime", levelTime);
        }

        public void AddLevel(int level)
        {
            json.Put("Level", level);
        }

        public void AddJumps(int jumps)
        {
            json.Put("Jumps", jumps);
        }

        public String ToJsonString()
        {
            return json.ToJsonString();
        }
    }
}