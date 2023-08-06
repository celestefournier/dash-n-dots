using UnityEngine;

namespace Common
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        public int Score { get; private set; }

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

        public void SetScore(int score)
        {
            Score = score;
        }

        public void ClearScore()
        {
            Score = 0;
        }
    }
}