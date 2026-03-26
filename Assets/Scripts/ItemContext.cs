using UnityEngine;

public class ItemContext : MonoBehaviour
{
    [SerializeField] private ItemDataScriptableObject _base;

    [SerializeField] internal Item item;
    
    internal ItemStateManager manager => GetComponentInChildren<ItemStateManager>();

    internal Billboard billboard => GetComponentInChildren<Billboard>();

    internal Animator animator => GetComponentInChildren<Animator>();

    internal Pickup pickup => GetComponentInChildren<Pickup>();

    void Awake()
    {
        item = new(_base);
    }

}
