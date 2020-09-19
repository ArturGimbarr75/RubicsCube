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
            new Vector3(),
            Vector3.up,
            Settings.CameraSettings.HorizontalRotationSpeed * CameraJoystick.Horizontal * Time.deltaTime
        );

        var pos = transform.position;
        var XZprojection = Mathf.Sqrt(Mathf.Pow(Settings.CameraSettings.CameraDistanceFromCenter, 2) - Mathf.Pow(pos.y, 2));
        var hypotenuse = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.z, 2));
        var aspectRatio = Mathf.Round(hypotenuse / XZprojection);
        if (Math.Abs(aspectRatio) > 0.98f)
            aspectRatio = 1.0f;
        pos = new Vector3
        (
            pos.x * aspectRatio,
            Mathf.Clamp
            (
                pos.y + CameraJoystick.Vertical * Time.deltaTime * Settings.CameraSettings.VerticalRotationSpeed,
                Settings.CameraSettings.VerticalMin,
                Settings.CameraSettings.VerticalMax
            ),
            pos.z * aspectRatio
        );
        transform.position = pos;

        transform.LookAt(new Vector3());
    }

    private decimal RoundUp(decimal number, int digits)
    {
        var factor = Convert.ToDecimal(Math.Pow(10, digits));
        return Math.Ceiling(number * factor) / factor;
    }
}
