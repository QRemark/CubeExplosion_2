using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private CubeScaler cubeScaler;
    [SerializeField] private CubeRandomColorChanger cubeColor;

    public void SpawnCubes(Cube cube, float splitChance)
    {
        int cubeMinCount = 2;
        int cubeMaxCount = 6;

        float radiusNextPosition = 5f;
        float nextSplitChance = splitChance * 0.5f;

        int cubeCount = Random.Range(cubeMinCount, cubeMaxCount + 1);

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = cube.transform.position + new Vector3(Random.Range(-radiusNextPosition, radiusNextPosition),
                Random.Range(-radiusNextPosition, radiusNextPosition), Random.Range(-radiusNextPosition, radiusNextPosition));

            Cube newCube = Instantiate(cube, randomPosition, Quaternion.identity);

            cubeScaler.ScaleCube(newCube);

            cubeColor.ChangeColor(newCube);

            Cube splitController = newCube.GetComponent<Cube>();

            if (splitController != null)
                splitController.ChangeSplitChance(nextSplitChance);
        }
    }

    private void OnValidate()
    {
        if (cubeScaler == null)
        {
            Debug.Log("cubeScaler отсустствует!", this);
        }
        if (cubeColor == null)
        {
            Debug.Log("cubeColor отсутствует!", this);
        }
        //if (cubeExplosion == null)
        //{
        //    Debug.Log("cubeExplosion отсутствует!", this);
        //}
    }
}
