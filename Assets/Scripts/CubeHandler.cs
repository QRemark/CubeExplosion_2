using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeExplosier _cubeExplosier;

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
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    ExecuteCubeAction(cube);
                }
            }
        }
    }

    private void ExecuteCubeAction(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            List<Rigidbody> clones = _cubeSpawner.SpawnCube(cube, cube.SplitChance);
            _cubeExplosier.Explode(cube.transform.position, clones, _cubeExplosier.ForceScalerX(cube));
        }
        else
        {
            List<Rigidbody> cubesInRadius = _cubeExplosier.GetCubesInRadius();
            _cubeExplosier.Explode(cube.transform.position, cubesInRadius, _cubeExplosier.ForceScalerX(cube));
        }

        Destroy(cube.gameObject);
    }
}