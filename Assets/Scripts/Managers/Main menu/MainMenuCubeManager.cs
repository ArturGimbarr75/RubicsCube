using Assets.Scripts.Cube;
using Assets.Scripts.Cube.Controllers;
using Assets.Scripts.Cube.Inputs;
using Assets.Scripts.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class MainMenuCubeManager : MonoBehaviour
{
    public GameObject Cube;

    private RubiksCubeController3x3x3 RubiksCube;

    void Start()
    {
        RubiksCube = new RubiksCubeController3x3x3(Cube);
    }

    void FixedUpdate()
    {
        if (RubiksCube.IsAnimationEnded)
        {
            System.Random rand = new System.Random();
            var arr = Enum.GetValues(typeof(RubiksCube3x3x3.RotationRing)).Cast<RubiksCube3x3x3.RotationRing>();
            var ring = arr.ElementAt(rand.Next(0, arr.Count()));
            RubiksCube.Select(ring);
            RubiksCube.Rotate();
            Debug.Log(ring);
        }

        RubiksCube.AnimateCube();
    }
}
