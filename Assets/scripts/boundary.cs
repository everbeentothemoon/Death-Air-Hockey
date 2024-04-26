using UnityEngine;

public class Boundary : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    public float speed;

    private void Start()
    {

    }

    private void Update()
    {
        // Limit movement within the specified bounds
        float clampedX = Mathf.Clamp(transform.position.x, left.transform.position.x, right.transform.position.x);
        float clampedY = Mathf.Clamp(transform.position.y, bottom.transform.position.y, top.transform.position.y);
        transform.position = new Vector2(clampedX, clampedY);

        // Move based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        transform.Translate(movement * Time.deltaTime * speed);
    }
}
