using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
    public float damage;
    public float attackRange;
    public Attributes.Modifier damageType;
}
