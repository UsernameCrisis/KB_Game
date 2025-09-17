using UnityEngine;

[CreateAssetMenu(fileName = "DungeonParameters_", menuName = "Generate/DungeonData")]
public class GeneratorObject : ScriptableObject
{
    public int iterations = 10;
    public int walkLength = 10;
    public bool startRandomlyEachIteration = true;
}
