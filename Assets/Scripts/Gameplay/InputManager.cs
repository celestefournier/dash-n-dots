using UnityEngine;

namespace Gameplay
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] Camera cam;

        void Update()
        {
            if (Input.touchCount <= 0)
                return;

            foreach (var touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        DetectCollision(touch.position, "Circle");
                        break;
                    case TouchPhase.Moved:
                        DetectCollision(touch.position, "Triangle");
                        break;
                }
            }
        }

        void DetectCollision(Vector2 position, string shape)
        {
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                if (hit.transform.CompareTag(shape))
                {
                    hit.transform.GetComponent<Shape>().Hit();
                }
            }
        }
    }
}