using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExplosier _cubeExplosier;
    [SerializeField] private CubeScaler _cubeScaler;

    private int _leftMouseButton = 0;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            RaycastHit hit;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                {
                    if (cube != null)
                    {
                        ActionCube(cube);
                    }
                }
            }
        }
    }

    private void ActionCube(Cube cube)
    {
        List<Rigidbody> cubesInRadius = new List<Rigidbody>();

        if (Random.value <= cube.GetSplitChance())
        {
            _cubeSpawner.SpawnCube(cube, cube.GetSplitChance(), out List<Rigidbody> clones);
            _cubeExplosier.Explode(cube.transform.position, clones, _cubeScaler.ForceScalerX(cube));
        }
        else
        {
            cubesInRadius = _cubeExplosier.GetCubesInRadius();
            _cubeExplosier.Explode(cube.transform.position, cubesInRadius, _cubeScaler.ForceScalerX(cube));
        }

        Destroy(cube.gameObject);
    }
}