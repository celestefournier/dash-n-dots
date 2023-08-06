using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Shape : MonoBehaviour
    {
        [SerializeField] float FallSpeed = 300f;
        [SerializeField] float RotationSpeed = 180f;

        Action OnHit;

        public void Init(Action onHit)
        {
            OnHit = onHit;
        }

        void Update()
        {
            transform.Translate(0, -FallSpeed * Time.deltaTime, 0, Space.World);
            transform.Rotate(0f, 0f, RotationSpeed * Time.deltaTime, Space.World);
        }

        public void Hit()
        {
            OnHit();
            // Lógica de exibir animação
            Destroy(gameObject);
        }
    }
}