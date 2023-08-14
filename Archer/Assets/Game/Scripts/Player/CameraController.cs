using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class CameraController : MonoBehaviour
    {
       public GameObject mainCamera;
       public GameObject aimCamera;

        public void SetAimingCameraFocus(bool isAiming)
        {
            mainCamera.SetActive(!isAiming);
            aimCamera.SetActive(isAiming);
        }
    }
}
