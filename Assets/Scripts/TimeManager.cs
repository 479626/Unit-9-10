using TMPro;
using UnityEngine;
public sealed class TimeManager : GameManager
{
    [Header("Time Restraint")]
    [SerializeField] private float timeLeft;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] Animator timeAnimator;
    bool flashing = false;

    private void Update()
    {
        Timer();
        Flash();
    }

    private void Timer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            timer.text = Mathf.RoundToInt(timeLeft).ToString().PadLeft(3, '0');
        }
        else
        {
            EndGame();
        }
    }

    private void Flash()
    {
        if (flashing)
            return;

        if (timeLeft < 6)
        {
            flashing = true;
            timeAnimator.SetBool("On", true);
        }
    }
}
