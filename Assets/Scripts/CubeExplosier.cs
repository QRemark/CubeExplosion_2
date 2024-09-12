using System.Collections.Generic;
using UnityEngine;

public class CubeExplosier : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1000000f;
    [SerializeField] private float _explosionRadius = 10000f;

    public void Explode(Vector3 cubePosition, List<Rigidbody> cubes, float cubeScalerForce)///принимать только лист , позиция
    {
        float newExplosionForce = _explosionForce * cubeScalerForce;
        float newExplosionRadius = _explosionRadius * cubeScalerForce;

        foreach (Rigidbody explotableCubs in cubes)
            explotableCubs.AddExplosionForce(newExplosionForce, cubePosition, newExplosionRadius);
    }

    public List<Rigidbody> GetCubesInRadius()
    {
        return new List<Rigidbody>(GetExplodableCube());
    }

    private List<Rigidbody> GetExplodableCube()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubs = new List<Rigidbody>();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubs.Add(hit.attachedRigidbody);

        return cubs;
    }
}