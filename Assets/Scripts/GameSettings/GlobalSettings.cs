using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameSettings
{
    class GlobalSettings
    {
        private static GlobalSettings Instance;
        private GlobalSettings(){}
        private static GlobalSettings ReadSettingsFromJson()
        {
            return DefaultSettings;
            throw new NotImplementedException();
        }

        public static GlobalSettings GetInstance() => Instance ?? (Instance = ReadSettingsFromJson());

        public CameraSettings CameraSettings;
        public CubeSettings CubeSettings;
        public static GlobalSettings DefaultSettings { get; } = new GlobalSettings()
        {
            CameraSettings = new CameraSettings()
            {
                VerticalRotationSpeed = 18.0f,
                HorizontalRotationSpeed = 360.0f
            },
            CubeSettings = new CubeSettings()
            {
                RotateTimeInSeconds = 3.0f
            }
        };
    }
}
