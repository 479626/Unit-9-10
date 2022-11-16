using TMPro;
using UnityEngine;

public sealed class ScoreManager : GameManager
{
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        Score();

        if (Input.GetKeyDown(KeyCode.V))
            AddScore(100);
    }

    private void Score()
    {
        text.text = storage.score.ToString().PadLeft(5, '0');
    }

    public void AddScore(int score)
    {
        storage.score += score;
    }

    public void RemoveScore(int score)
    {
        storage.score -= score;
    }
}
