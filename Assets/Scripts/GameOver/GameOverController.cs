using Gameplay;
using TMPro;
using UnityEngine;

namespace GameOver
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ScoreText;

        void Start()
        {
            ScoreText.text = ScoreManager.Instance.Score.ToString();
        }
    }
}