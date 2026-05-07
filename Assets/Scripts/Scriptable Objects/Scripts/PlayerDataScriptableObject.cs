using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataScriptableObject", menuName = "Scriptable Objects/PlayerDataScriptableObject")]
public class PlayerDataScriptableObject : ScriptableObject
{
    public GameObject prefab;

    public Stat health;
    public Stat defense;
    public Stat speed;
    public Stat agility;
}
