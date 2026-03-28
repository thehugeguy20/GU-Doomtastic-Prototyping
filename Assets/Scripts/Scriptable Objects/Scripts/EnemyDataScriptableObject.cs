using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataScriptableObject", menuName = "Scriptable Objects/EnemyDataScriptableObject")]
public class EnemyDataScriptableObject : ScriptableObject
{
    public GameObject prefab;

    [MinMaxSlider(0, 10)]
    public Vector2 minMaxHP = new();

    [MinMaxSlider(0, 10)]
    public Vector2 minMaxDEF = new();

    [MinMaxSlider(0, 10)]
    public Vector2 minMaxSPD = new();

}
