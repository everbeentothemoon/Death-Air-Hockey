using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class goalPost : MonoBehaviour
{
    public Transform goalie;
    public TextMeshProUGUI scoreText;
    public float scoreNum = 0f; 
    public float point = 1f;
    public string winSceneName = "Win"; 
    public string loseSceneName = "Lose"; 

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            if (collision.transform.position.x > goalie.position.x)
            {
                scoreNum += point;
                scoreText.text = scoreNum.ToString();
            }
        }

        if (scoreNum >= 5f)
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}
