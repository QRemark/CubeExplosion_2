using System.Collections.Generic;
using UnityEngine;

public class CubePusher : MonoBehaviour
{
    private float _explosionForce = 1000f;
    private float _explosionRadius = 20f;

    public void PushCube(Vector3 cubePosition, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            Rigidbody cloneCubeRb = cube.GetComponent<Rigidbody>();

            if (cloneCubeRb != null)
                cloneCubeRb.AddExplosionForce(_explosionForce, cubePosition, _explosionRadius);
        }
    }
}
