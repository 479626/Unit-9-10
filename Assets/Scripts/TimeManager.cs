using TMPro;
using UnityEngine;
public sealed class TimeManager : GameManager
{
    [Header("Time Restraint")]
    [SerializeField] private float timeLeft;
    [SerializeField] private TextMeshProUGUI timer;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        timeLeft -= Time.deltaTime;

        timer.text = Mathf.RoundToInt(timeLeft).ToString().PadLeft(3, '0');
    }
}
