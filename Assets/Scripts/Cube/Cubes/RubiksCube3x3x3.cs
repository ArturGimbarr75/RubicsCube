using Assets.Scripts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Cube
{
    class RubiksCube3x3x3
    {
        public GameObject Cube { get; private set; }
        public GameObject[,,] CurrentCubeCombination { get; private set; }


        private Vector3 SelectedAxisOfRotation;
        private Vector3Int[] RotationVector;
        private int RotationAngle;

        public RotationRing SelectedRing { get; private set; }
        public GameObject SelectedPartsToRotate { get; private set; }

        public RubiksCube3x3x3(GameObject cube)
        {
            Cube = cube;
            CorrectRotateCubeParts();
            SetupCubeParts();
        }

        #region Public

        public void Select(RotationRing ring)
        {
            SelectedRing = ring;
            if (SelectedPartsToRotate != null)
            {
                var selected = SelectedPartsToRotate.transform;
                while (selected.childCount != 0)
                    selected.GetChild(0).transform.parent = Cube.transform;
                UnityEngine.Object.Destroy(SelectedPartsToRotate);
            }
            SelectedPartsToRotate = new GameObject();
            switch (ring)
            {
                case RotationRing.B:
                case RotationRing.B_:
                    for (int y = 0; y < 3; y++)
                        for (int z = 0; z < 3; z++)
                            CurrentCubeCombination[0, y, z].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(1, 0, 0);
                    RotationAngle = -90;
                    RotationVector = RotateX.Select(n => new Vector3Int(0, n.y, n.z)).ToArray();
                    break;

                case RotationRing.S:
                case RotationRing.S_:
                    for (int y = 0; y < 3; y++)
                        for (int z = 0; z < 3; z++)
                            CurrentCubeCombination[1, y, z].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(1, 0, 0);
                    RotationAngle = 90;
                    RotationVector = RotateX.Select(n => new Vector3Int(1, n.y, n.z)).ToArray();
                    break;

                case RotationRing.F:
                case RotationRing.F_:
                    for (int y = 0; y < 3; y++)
                        for (int z = 0; z < 3; z++)
                            CurrentCubeCombination[2, y, z].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(1, 0, 0);
                    RotationAngle = 90;
                    RotationVector = RotateX.Select(n => new Vector3Int(2, n.y, n.z)).ToArray();
                    break;
                //////////////////////////////////////////////////
                case RotationRing.U:
                case RotationRing.U_:
                    for (int x = 0; x < 3; x++)
                        for (int z = 0; z < 3; z++)
                            CurrentCubeCombination[x, 2, z].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(0, 1, 0);
                    RotationAngle = 90;
                    RotationVector = RotateY.Select(n => new Vector3Int(n.x, 2, n.z)).ToArray();
                    break;

                case RotationRing.E:
                case RotationRing.E_:
                    for (int x = 0; x < 3; x++)
                        for (int z = 0; z < 3; z++)
                            CurrentCubeCombination[x, 1, z].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(0, 1, 0);
                    RotationAngle = 90;
                    RotationVector = RotateY.Select(n => new Vector3Int(n.x, 1, n.z)).ToArray();
                    break;

                case RotationRing.D:
                case RotationRing.D_:
                    for (int x = 0; x < 3; x++)
                        for (int z = 0; z < 3; z++)
                            CurrentCubeCombination[x, 0, z].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(0, 1, 0);
                    RotationAngle = -90;
                    RotationVector = RotateY.Select(n => new Vector3Int(n.x, 0, n.z)).ToArray();
                    break;
                //////////////////////////////////////////////////
                case RotationRing.R:
                case RotationRing.R_:
                    for (int x = 0; x < 3; x++)
                        for (int y = 0; y < 3; y++)
                            CurrentCubeCombination[x, y, 2].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(0, 0, 1);
                    RotationAngle = -90;
                    RotationVector = RotateZ.Select(n => new Vector3Int(n.x, n.y, 2)).ToArray();
                    break;

                case RotationRing.M:
                case RotationRing.M_:
                    for (int x = 0; x < 3; x++)
                        for (int y = 0; y < 3; y++)
                            CurrentCubeCombination[x, y, 1].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(0, 0, 1);
                    RotationAngle = 90;
                    RotationVector = RotateZ.Select(n => new Vector3Int(n.x, n.y, 1)).ToArray();
                    break;

                case RotationRing.L:
                case RotationRing.L_:
                    for (int x = 0; x < 3; x++)
                        for (int y = 0; y < 3; y++)
                            CurrentCubeCombination[x, y, 0].transform.parent = SelectedPartsToRotate.transform;
                    SelectedAxisOfRotation = new Vector3(0, 0, 1);
                    RotationAngle = 90;
                    RotationVector = RotateZ.Select(n => new Vector3Int(n.x, n.y, 0)).ToArray();
                    break;
            }

            if (ring.ToString().Contains("_"))
                RotationAngle *= -1;
        }

        public (Quaternion from, Quaternion to) RotateInArray()
        {
            for (int i = 1; i < 4; i++)
            {
                if (SelectedRing > 0)
                {
                    CurrentCubeCombination.Swap(RotationVector[0], RotationVector[i]);
                    CurrentCubeCombination.Swap(RotationVector[4], RotationVector[i + 4]);
                }
                else
                {
                    CurrentCubeCombination.Swap(RotationVector[0], RotationVector[4 - i]);
                    CurrentCubeCombination.Swap(RotationVector[4], RotationVector[8 - i]);
                }
            }

            var to = Quaternion.Euler(SelectedAxisOfRotation * RotationAngle); 
            return (SelectedPartsToRotate.transform.rotation, SelectedPartsToRotate.transform.rotation * to);
        }

        public enum RotationRing
        {
            Skip = 0,

            L = 1,
            M = 2,
            R = -3,
            F = 4,
            S = 5,
            B = -6,
            U = 7,
            E = 8,
            D = -9,

            L_ = -1,
            M_ = -2,
            R_ = 3,
            F_ = -4,
            S_ = -5,
            B_ = 6,
            U_ = -7,
            E_ = -8,
            D_ = 9,
        }

        #endregion

        #region RotationVectors

        private Vector3Int[] RotateX = new Vector3Int[]
        {
            new Vector3Int( 1, 0, 2 ),
            new Vector3Int( 1, 0, 0 ),
            new Vector3Int( 1, 2, 0 ),
            new Vector3Int( 1, 2, 2 ),

            new Vector3Int( 1, 0, 1 ),
            new Vector3Int( 1, 1, 0 ),
            new Vector3Int( 1, 2, 1 ),
            new Vector3Int( 1, 1, 2 ),
        };

        private Vector3Int[] RotateY = new Vector3Int[]
        {
            new Vector3Int( 0, 1, 2 ),
            new Vector3Int( 2, 1, 2 ),
            new Vector3Int( 2, 1, 0 ),
            new Vector3Int( 0, 1, 0 ),

            new Vector3Int( 1, 1, 2 ),
            new Vector3Int( 2, 1, 1 ),
            new Vector3Int( 1, 1, 0 ),
            new Vector3Int( 0, 1, 1 ),
        };

        private Vector3Int[] RotateZ = new Vector3Int[]
        {
            new Vector3Int( 0, 0, 1 ),
            new Vector3Int( 2, 0, 1 ),
            new Vector3Int( 2, 2, 1 ),
            new Vector3Int( 0, 2, 1 ),

            new Vector3Int( 1, 0, 1 ),
            new Vector3Int( 2, 1, 1 ),
            new Vector3Int( 1, 2, 1 ),
            new Vector3Int( 0, 1, 1 ),
        };

        #endregion

        #region Private

        private void SetupCubeParts()
        {
            CurrentCubeCombination = new GameObject[3, 3, 3];
            List<GameObject> parts = new List<GameObject>();
            for (int i = 0; i < Cube.transform.childCount; i++)
                parts.Add(Cube.transform.GetChild(i).gameObject);
            parts = parts.Where(x => int.TryParse(x.name, out int n))
                .Select(x => x).OrderBy(x => int.Parse(x.name)).ToList();

            int index = 0;

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    for (int z = 0; z < 3; z++)
                    {
                        CurrentCubeCombination[x, y, z] = parts[index];
                        index++;
                    }
        }

        private void CorrectRotateCubeParts()
        {
            for (int i = 0; i < Cube.transform.childCount; i++)
                Cube.transform.GetChild(i).RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), 90);
        }

        #endregion
    }
}
