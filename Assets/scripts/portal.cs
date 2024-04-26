using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] private Transform teleportationPosition;

    private GameObject puck;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject obj)
    {
        if (obj != null)
        {
            obj.transform.position = teleportationPosition.position;
        }
    }
}
