using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShootingRangeEditorSpawner : MonoBehaviour
{
    public int lanes = 6;
    public float laneGap = 2.5f;
    public float[] targetDistances = { 50f, 100f, 200f };

#if UNITY_EDITOR
    [ContextMenu("Generate Range (Editor)")]
    void GenerateRange()
    {
        // 방호벽
        var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = new Vector3((lanes-1)*laneGap/2, 1.2f, -2f);
        wall.transform.localScale = new Vector3(lanes*laneGap + 2, 2.4f, 0.6f);
        wall.name = "BackWall";

        // 입사호
        for (int i=0; i<lanes; ++i)
        {
            var booth = GameObject.CreatePrimitive(PrimitiveType.Cube);
            booth.transform.position = new Vector3(i*laneGap, 0.6f, 0);
            booth.transform.localScale = new Vector3(1, 1.2f, 0.3f);
            booth.name = $"Booth_{i+1}";
        }

        // 표적
        foreach (float z in targetDistances)
        {
            for (int i=0; i<lanes; ++i)
            {
                var target = GameObject.CreatePrimitive(PrimitiveType.Cube);
                target.transform.position = new Vector3(i*laneGap, 0.75f, z);
                target.transform.localScale = new Vector3(0.5f, 1.5f, 0.05f);
                target.name = $"Target_{i+1}_{z}m";
            }
        }
    }
#endif
}
