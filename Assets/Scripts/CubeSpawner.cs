using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeScaler _cubeScaler;
    [SerializeField] private CubeRandomColorChanger _cubeColor;

    public void SpawnCube(Cube cube, float splitChance, out List<Rigidbody> clones)
    {
        int cubeMinCount = 2;
        int cubeMaxCount = 6;

        float radiusNextPosition = 5f;
        float nextSplitChance = splitChance * 0.5f;

        int cubeCount = Random.Range(cubeMinCount, cubeMaxCount + 1);

        clones = new List<Rigidbody>();

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = cube.transform.position + new Vector3(Random.Range(-radiusNextPosition, radiusNextPosition),
                Random.Range(-radiusNextPosition, radiusNextPosition), Random.Range(-radiusNextPosition, radiusNextPosition));

            Cube clone = Instantiate(cube, randomPosition, Quaternion.identity);

            _cubeScaler.ScaleCube(clone);

            _cubeColor.ChangeColor(clone);

            clone.ChangeSplitChance(nextSplitChance);

            clones.Add(clone.GetComponent<Rigidbody>());
        }
    }
}