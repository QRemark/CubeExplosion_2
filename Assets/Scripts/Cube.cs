using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawn;
    private CubeManager _cubeManager;

    private float _splitChance = 1.0f;

    public void Initialize(CubeManager cubeManager)
    {
        _cubeManager = cubeManager;
    }

    private void Start()
    {
        if (_cubeManager == null)
        {
            _cubeManager = FindObjectOfType<CubeManager>();
        }
    }

    private void OnMouseDown()
    {
        if (Random.value < _splitChance)
            _cubeSpawn.SpawnCubes(this, _splitChance);
        else
            _cubeManager.ExploideCube(gameObject);

        _cubeManager.DestroyCube(gameObject);
    }

    public void ChangeSplitChance(float chance)
    {
        _splitChance = chance;
    }
}
