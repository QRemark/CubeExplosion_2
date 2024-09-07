using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private CubeExplosion _cubeExplosion;
    [SerializeField] private CubeScaler _cubeScaler;

    public void DestroyCube()
    {
        _cubeExplosion.Explode(gameObject.transform.position, _cubeScaler.ForceScalerX(gameObject));
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        if (_cubeScaler == null)
        {
            Debug.Log("cubeScaler отсустствует!", this);
        }
        if (_cubeExplosion == null)
        {
            Debug.Log("cubeExplosion отсутствует!", this);
        }
    }
}
