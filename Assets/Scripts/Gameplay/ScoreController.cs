using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ScoreText;

        public void SetScore(int score)
        {
            ScoreText.text = score.ToString();
        }
    }
}