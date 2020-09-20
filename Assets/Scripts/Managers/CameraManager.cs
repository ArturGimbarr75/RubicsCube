using Assets.Scripts.GameSettings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Joystick CameraJoystick;
    private GlobalSettings Settings;

    void Start()
    {
        Settings = GlobalSettings.GetInstance();
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        transform.RotateAround
        (
            Vector3.zero,
            Vector3.up,
            Settings.CameraSettings.HorizontalRotationSpeed * CameraJoystick.Horizontal * Time.deltaTime
        );

        var pos = transform.position;
        pos.y = Mathf.Clamp
            (
                pos.y + CameraJoystick.Vertical * Time.deltaTime * Settings.CameraSettings.VerticalRotationSpeed,
                Settings.CameraSettings.VerticalMin,
                Settings.CameraSettings.VerticalMax
            );
        transform.position = pos;

        transform.LookAt(new Vector3());
    }
}
