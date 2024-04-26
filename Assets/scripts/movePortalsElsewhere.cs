using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePortalsElsewhere : MonoBehaviour
{
    public List<GameObject> objectsToMove;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -4f;
    public float maxY = 4f;
    public float minDistance = 2f;
    public float interval = 25f;

    void Start()
    {
        StartCoroutine(PlaceObjectsRepeatedly());
    }

    IEnumerator PlaceObjectsRepeatedly()
    {
        while (true)
        {
            PlaceObjects();
            yield return new WaitForSeconds(interval);
        }
    }

    void PlaceObjects()
    {
        HashSet<Vector2> positions = new HashSet<Vector2>();

        foreach (GameObject obj in objectsToMove)
        {
            Vector2 newPosition = GetRandomPosition(positions);
            obj.transform.position = newPosition;
            positions.Add(newPosition);
        }
    }

    Vector2 GetRandomPosition(HashSet<Vector2> positions)
    {
        Vector2 position;

        do
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            position = new Vector2(x, y);
        } while (!IsValidPosition(position, positions));

        return position;
    }

    bool IsValidPosition(Vector2 position, HashSet<Vector2> positions)
    {
        foreach (Vector2 pos in positions)
        {
            if (Vector2.Distance(position, pos) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}

