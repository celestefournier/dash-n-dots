using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] Button PlayButton;

        void Awake()
        {
            PlayButton.onClick.AddListener(StartGame);
        }

        void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}