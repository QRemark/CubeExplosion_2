using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class CubeRandomColorChanger : MonoBehaviour
{
    public void ChangeColor(Cube cube)
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        Renderer renderer = cube.GetComponent<Renderer>();

        renderer.material.color = randomColor;
    }
}