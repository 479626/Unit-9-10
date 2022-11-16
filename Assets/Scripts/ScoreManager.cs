using TMPro;
using UnityEngine;

public class ScoreManager : GameManager
{
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        Score();
    }

    private void Score()
    {
        text.text = storage.score.ToString().PadLeft(5, '0');
    }
}
