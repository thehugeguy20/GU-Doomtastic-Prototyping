using UnityEngine;


public class ItemManager : MonoBehaviour
{
    [SerializeField] internal float charge = float.NaN;
    
    [SerializeField] private ScriptableObject ItemData;

    public ScriptableObject itemData => ItemData;
}