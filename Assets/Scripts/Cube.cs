using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeScaler _cubeScaler;
    [SerializeField] private CubeRandomColorChanger _cubeColor;

    public float SplitChance { get; set; } = 1.0f;

    public void Init(float nextSplitChance)
    {
        ChangeSplitChance(nextSplitChance);
        _cubeScaler.ScaleCube(this);
        _cubeColor.ChangeColor(this);
    }

    private void ChangeSplitChance(float chance)
    {
        SplitChance = chance;
    }
}