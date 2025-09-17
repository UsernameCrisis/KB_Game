using System;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPos, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPos, Direction2D.cardinalDirectionsList);
        foreach (var position in (HashSet<Vector2Int>)basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);

            // Optionally add wall hitboxes here if you want to handle it during wall creation
            // Example (pseudo-code, depends on your implementation):
            // WallHitboxManager.AddHitboxAtPosition(position);
        }
    }

    private static object FindWallsInDirections(HashSet<Vector2Int> floorPos, List<Vector2Int> cardinalDirectionsList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPos)
        {
            foreach (var direction in cardinalDirectionsList)
            {
                var neighborPos = position + direction;
                if (floorPos.Contains(neighborPos) == false)
                {
                    wallPositions.Add(neighborPos);
                }
            }
        }
        return wallPositions;
    }
}
