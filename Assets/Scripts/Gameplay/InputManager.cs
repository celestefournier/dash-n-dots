using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster GraphicRaycaster;
        [SerializeField] private EventSystem EventSystem;

        private void Update()
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

        private void DetectCollision(Vector2 position, string shape)
        {
            var pointerEventData = new PointerEventData(EventSystem) {position = position};
            var results = new List<RaycastResult>();

            GraphicRaycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag(shape))
                {
                    result.gameObject.GetComponent<Shape>().Hit();
                }
            }
        }
    }
}