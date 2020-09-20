using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameSettings
{
    class CubeSettings
    {
        private float rotateTimeInSeconds;
        private const float rotateTimeInSecondsMin = 0.5f;
        private const float rotateTimeInSecondsMax = 3.0f;
        public float RotateTimeInSeconds
        {
            get
            {
                return rotateTimeInSeconds;
            }
            set
            {
                rotateTimeInSeconds = Mathf.Clamp
                (
                    value,
                    rotateTimeInSecondsMin,
                    rotateTimeInSecondsMax
                );
            }
        }
        public float RotateTimeInSecondsMin { get { return rotateTimeInSecondsMin; } }
        public float RotateTimeInSecondsMax { get { return rotateTimeInSecondsMax; } }
    }
}
