using UnityEngine;

namespace Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private ScoreController ScoreController;

        private int Score;

        public void IncreaseScore()
        {
            Score++;
            ScoreController.SetScore(Score);
        }
    }
}