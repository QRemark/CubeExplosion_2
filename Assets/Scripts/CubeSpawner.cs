using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeScaler _cubeScaler;
    [SerializeField] private CubeRandomColorChanger _cubeColor;
    [SerializeField] private CubePusher _cubePusher;
    [SerializeField] private CubeManager _cubeManager;

    public void SpawnCubes(Cube cube, float splitChance)
    {
        int cubeMinCount = 2;
        int cubeMaxCount = 6;

        float radiusNextPosition = 5f;
        float nextSplitChance = splitChance * 0.5f;

        int cubeCount = Random.Range(cubeMinCount, cubeMaxCount + 1);

        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = cube.transform.position + new Vector3(Random.Range(-radiusNextPosition, radiusNextPosition),
                Random.Range(-radiusNextPosition, radiusNextPosition), Random.Range(-radiusNextPosition, radiusNextPosition));

            Cube newCube = Instantiate(cube, randomPosition, Quaternion.identity);

            _cubeScaler.ScaleCube(newCube);

            _cubeColor.ChangeColor(newCube);

            newCube.ChangeSplitChance(nextSplitChance);

            newCube.Initialize(_cubeManager);

            cubes.Add(newCube);
        }

        _cubePusher.PushCube(cube.transform.position, cubes);
    }
}
