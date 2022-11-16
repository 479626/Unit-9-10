using UnityEngine;

public class BrickListener : MonoBehaviour
{
    [SerializeField] Animator animator;
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
        }
    }
}
