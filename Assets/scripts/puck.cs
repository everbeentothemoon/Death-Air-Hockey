using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class puck : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;

    private int collisionCount1 = 0;
    private int collisionCount2 = 0;
    private goalScoringMe gsm;
    private aiScoring ais;

    private void Start()
    {
        gsm = GameObject.FindGameObjectWithTag("Goal").GetComponent<goalScoringMe>();
        ais = GameObject.FindGameObjectWithTag("AI").GetComponent<aiScoring>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == gameObject1)
        {
            gsm.OnPuckCollision();
            ais.consecutiveCollisions = 0;
        }
        else if (collision.gameObject == gameObject2)
        {
            ais.OnPuckCollision();
            gsm.consecutiveCollisions = 0;
        }

        if (collision.gameObject == gameObject1 && ais.consecutiveCollisions > 0)
        {
            gsm.consecutiveCollisions = 0;
        }

        if (collision.gameObject == gameObject2 && gsm.consecutiveCollisions > 0)
        {
            ais.consecutiveCollisions = 0;
        }
    }
}
