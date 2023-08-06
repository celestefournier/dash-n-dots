using UnityEngine;

namespace Gameplay
{
    public class FloorController : MonoBehaviour
    {
        [SerializeField] GameplayController GameplayController;
        [SerializeField] Camera Camera;

        const float Offset = 1;
        BoxCollider2D BoxCollider;

        void Start()
        {
            BoxCollider = GetComponent<BoxCollider2D>();

            var cameraHeight = 2f * Camera.orthographicSize;
            var cameraWidth = cameraHeight * Camera.aspect;

            BoxCollider.size = new Vector2(cameraWidth, 1f);
            transform.position = new Vector3(0, -(cameraHeight / 2) - BoxCollider.size.y / 2 - Offset);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag is "Circle" or "Triangle")
            {
                GameplayController.GameOver();
            }
        }
    }
}