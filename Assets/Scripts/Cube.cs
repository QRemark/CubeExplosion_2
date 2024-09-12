using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;

    public float GetSplitChance() => _splitChance;

    public void ChangeSplitChance(float chance)
    {
        _splitChance = chance;
    }
}