using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataScriptableObject", menuName = "Scriptable Objects/EnemyDataScriptableObject")]
public class EnemyDataScriptableObject : ScriptableObject
{
    public GameObject prefab;

    //the lowest and highest possible base values that the enemy can originally spawn with. with higher difficulty or unique effects, this base value may be multiplied or altered.
    
    [MinMaxSlider(0, 10)]
    public Vector2 baseHP = new();
    public MiniStat minHP;
    public MiniStat maxHP;

    [MinMaxSlider(0, 10)]
    public Vector2 baseDEF = new();
    public MiniStat minDEF;
    public MiniStat maxDEF;

    [MinMaxSlider(0, 10)]
    public Vector2 baseSPD = new();
    public MiniStat minSPD;
    public MiniStat maxSPD;

    public Stat damage;

}
