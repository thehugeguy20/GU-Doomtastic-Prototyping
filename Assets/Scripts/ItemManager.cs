using UnityEngine;

public struct ItemBlackboard
{
    
}

public class ItemManager : MonoBehaviour
{
    protected ItemBlackboard blackboard = new()
    {
        
    };

    [SerializeField] private ScriptableObject ItemData;

    public ScriptableObject itemData => ItemData;
}