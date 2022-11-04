using UnityEngine;

namespace PauseScreenScripts.DifficultySettingScripts
{
    [CreateAssetMenu(fileName = "PlayerPreference", menuName = "ScriptableObjects/PlayerPreference")]
    public class PlayerPreference : ScriptableObject
    {
        public float scale = 1f;
    }
}
