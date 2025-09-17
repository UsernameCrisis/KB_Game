using UnityEngine;

public abstract class AbstractGenerate : MonoBehaviour
{
    [SerializeField]
    protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    void Awake()
    {
        RunGeneration();
    }

    public void Generate()
    {
        tilemapVisualizer.Clear();
        RunGeneration();
    }

    protected abstract void RunGeneration();
}
