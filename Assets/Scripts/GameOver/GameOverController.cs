using Common;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameOver
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ScoreText;

        [Header("Best Score")]
        [SerializeField] private TextMeshProUGUI FirstPlaceScore;
        [SerializeField] private TextMeshProUGUI SecondPlaceScore;
        [SerializeField] private TextMeshProUGUI ThirdPlaceScore;

        [Header("Buttons")]
        [SerializeField] ButtonController RetryButton;
        [SerializeField] ButtonController MenuButton;

        void Start()
        {
            var playerData = SaveSystem.Load();

            ScoreText.text = ScoreManager.Instance.Score.ToString();
            FirstPlaceScore.text = playerData.BestScores[0].ToString();
            SecondPlaceScore.text = playerData.BestScores[1].ToString();
            ThirdPlaceScore.text = playerData.BestScores[2].ToString();
            
            RetryButton.SetClick(Retry);
            MenuButton.SetClick(Menu);
        }

        void Retry()
        {
            ScoreManager.Instance.ClearScore();
            SceneManager.LoadScene("Gameplay");
        }

        void Menu()
        {
            ScoreManager.Instance.ClearScore();
            SceneManager.LoadScene("Menu");
        }
    }
}