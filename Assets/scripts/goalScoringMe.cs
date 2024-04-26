using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class goalScoringMe : MonoBehaviour
{
    public Transform goalie;
    public TextMeshProUGUI scoreText;
    public float scoreNum = 0f; 
    public float point = 1f;
    public string winSceneName = "Win"; 
    public GameObject respawnPuck;
    public GameObject resetRespawn;
    public GameObject puck;

    public int consecutiveCollisions = 0;

    public void OnPuckCollision()
    {
        consecutiveCollisions++;
        if (consecutiveCollisions >= 2)
        {
            scoreNum -= point;
            if (scoreNum <= 0f)
            {
                scoreNum = 0f;
            }
            scoreText.text = scoreNum.ToString();
            consecutiveCollisions = 0;

            ResetPuck();

            if (scoreNum >= 5f)
            {
                SceneManager.LoadScene(winSceneName);
            }
        }
    }

    void Start()
    {

    }

    private void Update()
    {
        if (puck.transform.position.y > 6f || 
            puck.transform.position.y < -6f ||
            puck.transform.position.x > 10f || 
            puck.transform.position.x < -10f)
        {
            Resett();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            if (collision.transform.position.x > goalie.position.x)
            {
                scoreNum += point;
                scoreText.text = scoreNum.ToString();
                ResetPuck();
                consecutiveCollisions = 0;
            }
        }

        if (scoreNum >= 5f)
        {
            SceneManager.LoadScene(winSceneName);
        }
    }

    void ResetPuck()
    {
        puck.transform.position = respawnPuck.transform.position;
        Rigidbody2D puckRb = puck.GetComponent<Rigidbody2D>();
        puckRb.velocity = Vector2.zero;
        puckRb.angularVelocity = 0f;
    }

    void Resett()
    {
        puck.transform.position = resetRespawn.transform.position;
        Rigidbody2D puckRb = puck.GetComponent<Rigidbody2D>();
        puckRb.velocity = Vector2.zero;
        puckRb.angularVelocity = 0f;
    }
}
