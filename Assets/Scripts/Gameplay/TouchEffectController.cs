using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class TouchEffectController : MonoBehaviour
    {
        [SerializeField] GameObject TapEffectPrefab;
        [SerializeField] List<TrailRenderer> Trails;
        [SerializeField] Camera Camera;

        const int MaxTrails = 5;

        void Update()
        {
            if (Input.touchCount <= 0)
                return;

            for (var i = 0; i < Input.touches.Length; i++)
            {
                var touch = Input.GetTouch(i);
                var touchPosition = Camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                    Camera.nearClipPlane));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Instantiate(TapEffectPrefab, touchPosition, Quaternion.identity, transform);
                        Trails[i].transform.position = touchPosition;
                        Trails[i].Clear();
                        break;
                    case TouchPhase.Moved:
                        if (i >= MaxTrails)
                            return;
                        Trails[i].transform.position = touchPosition;
                        break;
                }
            }
        }
    }
}