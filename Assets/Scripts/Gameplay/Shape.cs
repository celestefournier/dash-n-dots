using System;
using UnityEngine;

namespace Gameplay
{
    public class Shape : MonoBehaviour
    {
        [SerializeField] private float fallSpeed = 300f;
        [SerializeField] private float rotationSpeed = 180f;

        private RectTransform rectTransform;
        private Action OnHit;

        public void Init(Action onHit)
        {
            OnHit = onHit;
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            var position = rectTransform.anchoredPosition;
            position.y -= fallSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = position;

            var rotation = rectTransform.rotation;
            var rotationAngle = rotationSpeed * Time.deltaTime;
            var newRotation = Quaternion.Euler(0f, 0f, rotation.eulerAngles.z + rotationAngle);
            rectTransform.rotation = newRotation;
        }

        public void Hit()
        {
            OnHit();
            // Lógica de exibir animação
            Destroy(gameObject);
        }
    }
}