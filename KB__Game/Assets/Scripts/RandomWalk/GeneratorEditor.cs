using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractGenerate), true)]

public class GeneratorEditor : Editor
{
    AbstractGenerate generator;

    private void Awake()
    {
        generator = (AbstractGenerate)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
        {
            generator.Generate();
        }
    }
}
