using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] ScoreController ScoreController;
        [SerializeField] ShapeSpawnController ShapeSpawnController;

        public bool IsGameOver;
        int Score;

        void Start()
        {
            ShapeSpawnController.Init(this);
            ScoreManager.Instance.Score = 0;
        }

        public void IncreaseScore()
        {
            Score++;
            ScoreManager.Instance.Score = Score;
            ScoreController.SetScore(Score);
        }

        public void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}