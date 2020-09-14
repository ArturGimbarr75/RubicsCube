using Assets.Scripts.Cube;
using Assets.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class CubeSceneManager : MonoBehaviour
{
    public GameObject Cube;

    private RubiksCube3x3 RubiksCube;

    void Start()
    {
        RubiksCube = new RubiksCube3x3(Cube);
    }

    private void ModifySelectedParts()
    {
        GameObject selectedParts = RubiksCube.SelectedPartsToRotate;
        if (selectedParts == null)
            return;

        for (int i = 0; i < Cube.transform.childCount; i++)
            Cube.transform.GetChild(i).localScale = new Vector3(0.7f, 0.7f, 0.7f);

        for (int i = 0; i < selectedParts.transform.childCount; i++)
            selectedParts.transform.GetChild(i).localScale = new Vector3(1f, 1f, 1f);
    }

    private void ShowCubeIndexes()
    {
        string log = string.Empty;

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                    log += RubiksCube.CurrentCubeCombination[x, y, z].name + " ";
                log += "\n";
            }
            log += "\n";
        }

        Debug.Assert(true, log);
    }

    public void F()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.F);
        ModifySelectedParts();
    }
    public void S()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.S);
        ModifySelectedParts();
    }
    public void B()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.B);
        ModifySelectedParts();
    }
    public void L()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.L);
        ModifySelectedParts();
    }
    public void M()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.M);
        ModifySelectedParts();
    }
    public void R()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.R);
        ModifySelectedParts();
    }
    public void U()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.U);
        ModifySelectedParts();
    }
    public void E()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.E);
        ModifySelectedParts();
    }
    public void D()
    {
        RubiksCube.Select(RubiksCube3x3.RotationRing.D);
        ModifySelectedParts();
    }
    public void Rotate()
    {
        RubiksCube.Rotate();
        ShowCubeIndexes();
    }
}
