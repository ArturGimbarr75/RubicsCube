using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class SwapExtension
    {
        public static void Swap(this GameObject[,,] gm, Vector3Int first, Vector3Int second)
        {
            var temp = gm[first.x, first.y, first.z];
            gm[first.x, first.y, first.z] = gm[second.x, second.y, second.z];
            gm[second.x, second.y, second.z] = temp;
        }
    }
}
