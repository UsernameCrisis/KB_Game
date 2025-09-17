using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generate : AbstractGenerate
{

    [SerializeField]
    private GeneratorObject parameters;

    private HashSet<Vector2Int> RandomWalk()
    {
        var currentPos = startPos;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = Randomwalk.Walk(currentPos, parameters.walkLength);
            floorPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration)
            {
                currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }

    protected override void RunGeneration()
    {
        HashSet<Vector2Int> floorPositions = RandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    public static explicit operator Generate(GameObject v)
    {
        throw new NotImplementedException();
    }
}
