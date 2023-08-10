using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] ButtonController PlayButton;
        [SerializeField] ToggleController SoundButton;
        [SerializeField] ToggleController MusicButton;

        void Awake()
        {
            PlayButton.SetClick(StartGame);
            SoundButton.Init(PlayerPrefs.GetInt("soundFxOn", 1) == 1, ToggleSound);
            MusicButton.Init(PlayerPrefs.GetInt("musicOn", 1) == 1, ToggleMusic);
        }

        void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        void ToggleSound(bool active)
        {
            AudioManager.Instance.SetSoundSettings(active);
        }

        void ToggleMusic(bool active)
        {
            AudioManager.Instance.SetMusicSettings(active);
        }
    }
}