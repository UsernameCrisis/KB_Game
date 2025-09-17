using System.Collections.Generic;
using UnityEngine;

public class Randomwalk
{
    public static HashSet<Vector2Int> Walk(Vector2Int startPos, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        Vector2Int currentPos = startPos;
        var previousPosition = startPos;
        path.Add(currentPos);

        for (int i = 0; i < walkLength; i++)
        {
            Vector2Int newPosition = previousPosition + Direction2D.GetRandomDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }

        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0, 1),  // Up
        new Vector2Int(1, 0),  // Right
        new Vector2Int(0, -1), // Down
        new Vector2Int(-1, 0)  // Left
    };

    public static Vector2Int GetRandomDirection()
    {
        int randomIndex = Random.Range(0, cardinalDirectionsList.Count);
        return cardinalDirectionsList[randomIndex];
    }
}
