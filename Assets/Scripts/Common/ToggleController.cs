using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class ToggleController : MonoBehaviour
    {
        [SerializeField] Sprite SpriteOn;
        [SerializeField] Sprite SpriteOff;

        Image Image;

        bool ToggleOn;
        Action<bool> OnToggle;

        public void Init(bool active, Action<bool> onToggle)
        {
            ToggleOn = active;
            OnToggle = onToggle;
            Image = GetComponent<Image>();

            Image.sprite = active ? SpriteOn : SpriteOff;
            GetComponent<Button>().onClick.AddListener(Toggle);
        }

        void Toggle()
        {
            ToggleOn = !ToggleOn;
            Image.sprite = ToggleOn ? SpriteOn : SpriteOff;

            AudioManager.Instance.PlaySound(SoundEffect.Select);
            OnToggle?.Invoke(ToggleOn);
        }
    }
}