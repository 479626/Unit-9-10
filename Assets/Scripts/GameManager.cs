using System.Collections;
using System.Collections.Generic;
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
}
