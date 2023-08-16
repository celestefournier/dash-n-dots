using UnityEngine;

namespace Common
{
    public class BootManager : MonoBehaviour
    {
        void Start()
        {
            Application.targetFrameRate = (int) Screen.currentResolution.refreshRateRatio.value;
        }
    }
}