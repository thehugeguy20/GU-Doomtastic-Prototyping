using UnityEngine;

// sits at the utmost top object of an enemy / the top of it's tree, so that all children can GetComponentInParent<>() and find this component
// which holds the enemy's stats and points to important components
public class EnemyCore : MonoBehaviour
{
    [SerializeField] private EnemyDataScriptableObject _base;
    [SerializeField] internal EnemyStats stats;

    internal EntityStateManager manager => GetComponentInChildren<EntityStateManager>();

    internal Billboard billboard => GetComponentInChildren<Billboard>();

    internal Animator animator => GetComponentInChildren<Animator>();

    void Awake()
    {
        stats = new(_base);
    }
}