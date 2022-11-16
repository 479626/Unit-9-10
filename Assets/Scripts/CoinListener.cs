using UnityEngine;

public class CoinListener : GameManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Destroy(this.gameObject);
        AddScore(50);
    }
}
