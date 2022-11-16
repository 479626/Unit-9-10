using TMPro;
using UnityEngine;

public class ScoreManager : GameManager
{
    [SerializeField] private TextMeshProUGUI hud, lost, win;

    private void Update()
    {
        Score();
    }

    private void Score()
    {
        hud.text = storage.score.ToString().PadLeft(5, '0');
        lost.text = storage.score.ToString().PadLeft(5, '0');
        win.text = storage.score.ToString().PadLeft(5, '0');
    }
}
