using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button PlayButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}