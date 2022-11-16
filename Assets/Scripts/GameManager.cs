using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Statistics storage;

    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public void Save()
    {

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
