using UnityEngine;

namespace Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private ScoreController ScoreController;
        [SerializeField] private ShapeSpawnController ShapeSpawnController;

        public bool IsGameOver;
        private int Score;

        void Start()
        {
            ShapeSpawnController.Init(this);
        }

        public void IncreaseScore()
        {
            Score++;
            ScoreController.SetScore(Score);
        }

        public void GameOver()
        {
            Time.timeScale = 0;
        }
    }
}