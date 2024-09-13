using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public List<Rigidbody> SpawnCube(Cube cube, float splitChance)
    {
        int cubeMinCount = 2;
        int cubeMaxCount = 6;

        float radiusNextPosition = 45f;
        float nextSplitChance = splitChance * 0.5f;

        int cubeCount = Random.Range(cubeMinCount, cubeMaxCount + 1);

        List<Rigidbody> clones = new List<Rigidbody>();

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = cube.transform.position + new Vector3(Random.Range(-radiusNextPosition, radiusNextPosition),
                Random.Range(-radiusNextPosition, radiusNextPosition), Random.Range(-radiusNextPosition, radiusNextPosition));

            Cube clone = Instantiate(cube, randomPosition, Quaternion.identity);

            clone.Init(nextSplitChance);

            if (clone.TryGetComponent(out Rigidbody cloneRigidbody))
                clones.Add(cloneRigidbody);
        }

        return new List<Rigidbody>(clones);
    }
}