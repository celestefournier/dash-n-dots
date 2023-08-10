using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class ButtonController : MonoBehaviour
    {
        Action OnClick;

        public void SetClick(Action onClick)
        {
            OnClick = onClick;
            GetComponent<Button>().onClick.AddListener(PlaySound);
        }

        void PlaySound()
        {
            AudioManager.Instance.PlaySound(SoundEffect.Select);
            OnClick?.Invoke();
        }
    }
}