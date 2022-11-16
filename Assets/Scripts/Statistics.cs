using UnityEngine;

[CreateAssetMenu]
public class Statistics : ScriptableObject
{
    public int score;

    private void OnEnable()
    {
        score = 0;
    }
}