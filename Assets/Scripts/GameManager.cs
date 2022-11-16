using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Statistics storage;

    public void EndGame(bool beatGame)
    {
        Debug.Log("Beat game? " + beatGame);
        RestartGame();
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        storage.score = 0;
    }
}
