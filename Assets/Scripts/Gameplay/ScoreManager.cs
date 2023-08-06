using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : MonoBehaviour 
    {
        public static ScoreManager Instance;
        public int Score;

        void Awake() 
        {
            if (Instance == null) 
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            } 
            else if (Instance != this) 
            {
                Destroy(gameObject);
            }
        }
    }
}