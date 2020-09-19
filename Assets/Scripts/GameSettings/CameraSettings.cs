using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameSettings
{
    struct CameraSettings
    {
        private const float verticalMax =  6;
        private const float verticalMin = -6;
        private float verticalRotationSpeed;
        private const float verticalRotationSpeedMax = 18.0f;
        private const float verticalRotationSpeedMin = 6.0f;
        private float horizontalRotationSpeed;
        private const float horizontalRotationSpeedMax = 720.0f;
        private const float horizontalRotationSpeedMin = 60.0f;
        private const float cameraDistanceFromCenter = 9.27f;

        public float VerticalMax { get { return verticalMax; } }
        public float VerticalMin { get { return verticalMin; } }
        public float VerticalRotationSpeedMax { get { return verticalRotationSpeedMax; } }
        public float VerticalRotationSpeedMin { get { return verticalRotationSpeedMin; } }
        public float VerticalRotationSpeed
        {
            get
            {
                return verticalRotationSpeed;
            }
            set
            {
                verticalRotationSpeed = Mathf.Clamp
                (
                    value,
                    verticalRotationSpeedMin,
                    verticalRotationSpeedMax
                );
            }
        }
        public float HorizontalRotationSpeedMax { get { return horizontalRotationSpeedMax; } }
        public float HorizontalRotationSpeedMin { get { return horizontalRotationSpeedMin; } }
        public float HorizontalRotationSpeed
        {
            get
            {
                return horizontalRotationSpeed;
            }
            set
            {
                horizontalRotationSpeed = Mathf.Clamp
                (
                    value,
                    horizontalRotationSpeedMin,
                    horizontalRotationSpeedMax
                );
            }
        }
        public float CameraDistanceFromCenter { get { return cameraDistanceFromCenter; } }
    }
}
