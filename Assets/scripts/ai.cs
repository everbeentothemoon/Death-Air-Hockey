using System.Collections;
using UnityEngine;

public class ai : MonoBehaviour
{
    public Transform puck;
    public float moveSpeed = 5f;
    public float maxDistanceToPuck = 1f;
    public GameObject ownGoal;
    public GameObject goal;

    private Rigidbody2D rb;
    private Collider2D aiCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 directionToPuck = puck.position - transform.position;

        if (directionToPuck.magnitude <= maxDistanceToPuck)
        {
            rb.velocity = Vector2.zero;
            maxDistanceToPuck = 0f;
        }
        else
        {
            rb.velocity = directionToPuck.normalized * moveSpeed;
            maxDistanceToPuck = 2f;
        }

        // Limit movement to within the air hockey table
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8.187876f, 0f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.075f, 4.075f);
        transform.position = clampedPosition;
    }

    void FixedUpdate()
    {
        if (ownGoal != null && puck.position.x < ownGoal.transform.position.x)
        {
            // Move to defend the goal
            Vector2 moveDirection = (ownGoal.transform.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;
        }
        else if (puck.position.x < -7f)
        {
            // Move to block the puck's path
            Vector2 moveDirection = new Vector2(-1f, 0f);
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            // Add force to the puck to simulate a hit
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(rb.velocity * 2f, ForceMode2D.Impulse);
        }
    }
}
