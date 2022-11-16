using UnityEngine;

public class PlayerKiller : GameManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EndGame(false);
        }
    }
}
