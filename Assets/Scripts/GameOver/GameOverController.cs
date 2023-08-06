using Common;
using Gameplay;
using TMPro;
using UnityEngine;

namespace GameOver
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ScoreText;

        [Header("Best Score")]
        [SerializeField] private TextMeshProUGUI FirstPlaceScore;
        [SerializeField] private TextMeshProUGUI SecondPlaceScore;
        [SerializeField] private TextMeshProUGUI ThirdPlaceScore;

        void Start()
        {
            var playerData = SaveSystem.Load();

            ScoreText.text = ScoreManager.Instance.Score.ToString();
            FirstPlaceScore.text = playerData.BestScores[0].ToString();
            SecondPlaceScore.text = playerData.BestScores[1].ToString();
            ThirdPlaceScore.text = playerData.BestScores[2].ToString();
        }
    }
}