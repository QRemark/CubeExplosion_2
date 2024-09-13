using UnityEngine;

public class CubeScaler : MonoBehaviour
{
    private float _scaler = 0.5f;

    public void ScaleCube(Cube cube)
    {
        cube.transform.localScale *= _scaler;
    }
}