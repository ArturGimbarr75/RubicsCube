using Assets.Scripts.GameSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Cube.RubiksCube3x3x3;

namespace Assets.Scripts.Cube.Controllers
{
    class RubiksCubeController3x3x3
    {
        public bool IsAnimationEnded { get; private set; }

        private RubiksCube3x3x3 RubiksCube;
        private Quaternion Begin;
        private Quaternion Target;
        private float LerpQuantity;
        private GlobalSettings Settings;

        public RubiksCubeController3x3x3(GameObject cube)
        {
            RubiksCube = new RubiksCube3x3x3(cube);
            LerpQuantity = 0.0f;
            IsAnimationEnded = true;
            Settings = GlobalSettings.GetInstance();
        }

        public void Select(RotationRing ring)
        {
            if (!IsAnimationEnded)
                CompleteCurrentAnimation();
            RubiksCube.Select(ring);
            ModifySelectedParts();
        }

        public void Rotate()
        {
            if (!IsAnimationEnded)
                CompleteCurrentAnimation();
            (Begin, Target) = RubiksCube.RotateInArray();
            IsAnimationEnded = false;
        }

        public void AnimateCube()
        {
            if (!IsAnimationEnded)
            {
                LerpQuantity = LerpQuantity + (Time.deltaTime / Settings.CubeSettings.RotateTimeInSeconds);
                if (LerpQuantity > 1.0)
                {
                    CompleteCurrentAnimation();
                    return;
                }
                RubiksCube.SelectedPartsToRotate.transform.rotation = Quaternion.Lerp(Begin, Target, LerpQuantity);
            }
        }

        private void CompleteCurrentAnimation()
        {
            if (IsAnimationEnded)
                return;

            RubiksCube.SelectedPartsToRotate.transform.rotation = Quaternion.Lerp(Begin, Target, 1.0f);
            IsAnimationEnded = true;
            LerpQuantity = 0.0f;
        }

        private void ModifySelectedParts()
        {
            GameObject selectedParts = RubiksCube.SelectedPartsToRotate;
            if (selectedParts == null)
                return;

            for (int i = 0; i < RubiksCube.Cube.transform.childCount; i++)
                RubiksCube.Cube.transform.GetChild(i).localScale = new Vector3(0.9f, 0.9f, 0.9f);

            for (int i = 0; i < selectedParts.transform.childCount; i++)
                selectedParts.transform.GetChild(i).localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
