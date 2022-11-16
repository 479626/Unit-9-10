using UnityEngine;

public class BrickListener : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player, coin;
    private bool isOn = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOn)
        {
            return;
        }
        else if (collision.CompareTag("Player"))
        {
            animator.SetBool("Off", true);
            isOn = false;

            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        Instantiate(coin, player.transform.position + new Vector3(0f, 5f, 0f), player.transform.rotation);
    }
}
