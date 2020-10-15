using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Assets.Scripts.Cube.Inputs
{
    class RubiksCube3x3x3Input : MonoBehaviour
    {
        private LayerMask layerMask;
        private float rayLength;
        private string CurrentSwipe;
        private static List<RubiksCube3x3x3.RotationRing> Rotations;
        private DateTime LastSwipe;

        private void Start()
        {
            CurrentSwipe = String.Empty;
            LastSwipe = DateTime.UtcNow;
            rayLength = 20;
            const int DEFAULT_LAYER_MASK = 1;
            layerMask = new LayerMask()
            {
                value = DEFAULT_LAYER_MASK
            };
            Rotations = new List<RubiksCube3x3x3.RotationRing>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
               
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, rayLength, layerMask))
                {
                    if (hit.collider.name != "Skip")
                    {
                        PutNextRing(hit.collider.gameObject.transform.parent.name + "." + hit.collider.name);
                        LastSwipe = DateTime.UtcNow;
                    }
                }
            }

            if (LastSwipe.AddSeconds(1) < DateTime.UtcNow)
            {
                CurrentSwipe = string.Empty;
            }
        }

        private void PutNextRing(string ring)
        {
            if (CurrentSwipe.EndsWith(ring))
                return;


            CurrentSwipe += (CurrentSwipe != string.Empty) ? "_" + ring : ring;

            if (CurrentSwipe.Split(new char[] { '_' }).Length > 2)
            {
                if (RingsOfCube.L.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.L);
                else if (RingsOfCube.M.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.M);
                else if (RingsOfCube.R.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.R);
                else if (RingsOfCube.F.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.F);
                else if (RingsOfCube.S.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.S);
                else if (RingsOfCube.B.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.B);
                else if (RingsOfCube.U.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.U);
                else if (RingsOfCube.E.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.E);
                else if (RingsOfCube.D.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.D);

                else if (RingsOfCube.L_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.L_);
                else if (RingsOfCube.M_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.M_);
                else if (RingsOfCube.R_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.R_);
                else if (RingsOfCube.F_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.F_);
                else if (RingsOfCube.S_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.S_);
                else if (RingsOfCube.B_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.B_);
                else if (RingsOfCube.U_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.U_);
                else if (RingsOfCube.E_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.E_);
                else if (RingsOfCube.D_.Contains(CurrentSwipe))
                    Rotations.Add(RubiksCube3x3x3.RotationRing.D_);

                CurrentSwipe = string.Empty;
            }
            else if (CurrentSwipe.Split(new char[] { '_' }).Length >= 3)
            {
                CurrentSwipe = string.Empty;
            }
        }

        struct RingsOfCube
        {
            public const string L = "5.7_5.4_5.1 _3.3_3.6_3.9 _6.3_6.6_6.9 _1.7_1.4_1.1 _5.7";
            public const string M = "5.8_5.5_5.2 _3.2_3.5_3.8 _6.2_6.5_6.8 _1.8_1.5_1.2 _5.8";
            public const string R = "5.9 _1.3_1.6_1.9 _6.7_6.4_6.1 _3.7_3.4_3.1 _5.3_5.6_5.9";

            public const string F = "5.7_5.8_5.9 _2.1_2.4_2.7 _6.7_6.8_6.9 _4.9_4.6_4.3 _5.7";
            public const string S = "5.4_5.5_5.6 _2.2_2.5_2.8 _6.4_6.5_6.6 _4.8_4.5_4.2 _5.4";
            public const string B = "5.1_4.1_4.4_4.7_6.3_6.2_6.1_2.9_2.6_2.3_5.3_5.2_5.1";

            public const string U = "1.3_1.2_1.1 _4.3_4.2_4.1 _3.3_3.2_3.1 _2.3_2.2_2.1 _1.3";
            public const string E = "1.6_1.5_1.4 _4.6_4.5_4.4 _3.6_3.5_3.4 _2.6_2.5_2.4 _1.6";
            public const string D = "1.9 _2.7_2.8_2.9 _3.7_3.8_3.9 _4.7_4.8_4.9 _1.7_1.8_1.9";


            public const string L_ = "5.7 _1.1_1.4_1.7 _6.9_6.6_6.3 _3.9_3.6_3.3 _5.1_5.4_5.7";
            public const string M_ = "5.8 _1.2_1.5_1.8 _6.8_6.5_6.2 _3.8_3.5_3.2 _5.2_5.5_5.8";
            public const string R_ = "5.9_5.6_5.3 _3.1_3.4_3.7 _6.1_6.4_6.7 _1.9_1.6_1.3 _5.9";

            public const string F_ = "5.7 _4.3_4.6_4.9 _6.9_6.8_6.7 _2.7_2.4_2.1 _5.9_5.8_5.7";
            public const string S_ = "5.4 _4.2_4.5_4.8 _6.6_6.5_6.4 _2.8_2.5_2.2 _5.6_5.5_5.4";
            public const string B_ = "5.1_5.2_5.3 _2.3_2.6_2.9 _6.1_6.2_6.3 _4.7_4.4_4.1 _5.1";

            public const string U_ = "1.3 _2.1_2.2_2.3 _3.1_3.2_3.3 _4.1_4.2_4.3 _1.1_1.2_1.3";
            public const string E_ = "1.6 _2.4_2.5_2.6 _3.4_3.5_3.6 _4.4_4.5_4.6 _1.4_1.5_1.6";
            public const string D_ = "1.9_1.8_1.7 _4.9_4.8_4.7 _3.9_3.8_3.7 _2.9_2.8_2.7 _1.9";
        }

        public static RubiksCube3x3x3.RotationRing GetNextRotation()
        {
            if (Rotations.Count == 0)
                return RubiksCube3x3x3.RotationRing.Skip;

            var rot = Rotations.First();
            Rotations.RemoveAt(0);
            return rot;
        }
    }
}
