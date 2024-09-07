using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeDestroyer cubeDestroyer;
    [SerializeField] private CubeSpawn cubeSpawn;

    private float _splitChance = 1.0f;

    private void OnMouseDown()
    {
        if (Random.value < _splitChance)
            cubeSpawn.SpawnCubes(this, _splitChance);

        cubeDestroyer.DestroyCube();
    }

    public void ChangeSplitChance(float chance)
    {
        _splitChance = chance;
    }

    private void OnValidate()
    {
        if (cubeSpawn == null)
        {
            Debug.Log("cubeSpawn отсустствует!", this);
        }
        if (cubeDestroyer == null)
        {
            Debug.Log("cubeDestroyer отсутствует!", this);
        }
    }
}
