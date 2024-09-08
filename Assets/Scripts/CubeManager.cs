using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private CubeExplosier _cubeExplosier;
    [SerializeField] private CubeScaler _cubeScaler;

    public void DestroyCube(GameObject cube)
    {
        Destroy(cube);
    }

    public void ExploideCube(GameObject cube)
    {
        _cubeExplosier.Explode(cube.transform.position, _cubeScaler.ForceScalerX(cube));
    }
}
