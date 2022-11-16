using System.Collections;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    private float timer;
    private bool turnLeft;
    [SerializeField] private Statistics statistics;
    Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        timer = 3;
        animator = GetComponent<Animator>();    
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ShouldMove();
    }

    private void ShouldMove()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (turnLeft)
            {
                turnLeft = false;
                Move(turnLeft);
            }
            else
            {
                turnLeft = true;
                Move(turnLeft);
            }

            timer = 3;
        }
    }

    private void Move(bool left)
    {
        Vector2 velocity = rb.velocity;
        if (left)
        {
            velocity.x = 3;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            velocity.x = -3;
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        rb.velocity = velocity;
        animator.SetFloat("Movement", velocity.sqrMagnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(startDeath());
        }
    }

    private IEnumerator startDeath()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        statistics.score += 100;
        yield return null;
    }
}
