using UnityEngine;

namespace Gameplay
{
    [ExecuteInEditMode]
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField] Vector2 ReferenceResolution = new Vector2(1080, 1920);
        [SerializeField] float PixelsPerUnit = 100;

        Camera Cam;

        void Start()
        {
            Cam = GetComponent<Camera>();
        }

        void Update()
        {
            var targetAspect = ReferenceResolution.x / ReferenceResolution.y;
            var currentAspect = (float) Screen.width / Screen.height;

            if (currentAspect < targetAspect)
            {
                Cam.orthographicSize = ReferenceResolution.y / PixelsPerUnit / 2 * (targetAspect / currentAspect);
            }
            else
            {
                Cam.orthographicSize = ReferenceResolution.y / PixelsPerUnit / 2;
            }
        }
    }
}