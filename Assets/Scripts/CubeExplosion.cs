using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField]private float _explosionForce = 1000000f;
    [SerializeField]private float _explosionRadius = 10000f;

    public void Explode(Vector3 cubePosition, float forceScaler)
    {
        float newExplosionForce = _explosionForce * forceScaler;
        float newExplosionRadius = _explosionRadius * forceScaler;

        foreach (Rigidbody explotableCubs in GetExplodableCube())
            explotableCubs.AddExplosionForce(newExplosionForce, cubePosition, newExplosionRadius);
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
