using Assets.Scripts.GameSettings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class MainMenuCameraManager : MonoBehaviour
{
    public DirectionalLight Light;
    private CameraSettings Settings;

    void Start()
    {
        Settings = GlobalSettings.GetInstance().CameraSettings;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        const float speed = 0.1f
;        transform.RotateAround
        (
            Vector3.zero,
            Vector3.up,
            Settings.HorizontalRotationSpeed * Time.deltaTime * speed
        );

        Light.direction = Vector3.zero;
    }
}
