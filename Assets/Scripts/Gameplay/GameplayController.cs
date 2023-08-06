using Common;
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
            ScoreManager.Instance.ClearScore();
        }

        public void IncreaseScore()
        {
            Score++;
            ScoreManager.Instance.SetScore(Score);
            ScoreController.SetScore(Score);
        }

        public void GameOver()
        {
            var playerData = SaveSystem.Load();

            for (var i = 0; i < playerData.BestScores.Count; i++)
            {
                var playerScore = playerData.BestScores[i];

                if (Score > playerScore)
                {
                    playerData.BestScores.Insert(i, Score);
                    playerData.BestScores.RemoveAt(playerData.BestScores.Count - 1);
                    break;
                }
            }

            SaveSystem.Save(playerData);
            SceneManager.LoadScene("GameOver");
        }
    }
}