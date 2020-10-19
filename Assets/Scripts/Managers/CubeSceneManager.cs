using Assets.Scripts.Cube;
using Assets.Scripts.Cube.Controllers;
using Assets.Scripts.Cube.Inputs;
using Assets.Scripts.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class CubeSceneManager : MonoBehaviour
{
    public GameObject Cube;

    private RubiksCubeController3x3x3 RubiksCube;

    void Start()
    {
        RubiksCube = new RubiksCubeController3x3x3(Cube);
    }

    void Update()
    {
        if (RubiksCube.IsAnimationEnded)
        {
            var rot = RubiksCube3x3x3Input.GetNextRotation();
            if (rot != RubiksCube3x3x3.RotationRing.Skip)
            {
                RubiksCube.Select(rot);
                RubiksCube.Rotate();
            }
            else
                return;
        }

        RubiksCube.AnimateCube();
    }

    public void F()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.F);
    }
    public void S()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.S);
    }
    public void B()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.B);
    }
    public void L()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.L);
    }
    public void M()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.M);
    }
    public void R()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.R);
    }
    public void U()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.U);
    }
    public void E()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.E);
    }
    public void D()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.D);
    }
    public void Rotate()
    {
        RubiksCube.Rotate();
    }
    public void F_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.F_);
    }
    public void S_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.S_);
    }
    public void B_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.B_);
    }
    public void L_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.L_);
    }
    public void M_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.M_);
    }
    public void R_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.R_);
    }
    public void U_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.U_);
    }
    public void E_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.E_);
    }
    public void D_()
    {
        RubiksCube.Select(RubiksCube3x3x3.RotationRing.D_);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
