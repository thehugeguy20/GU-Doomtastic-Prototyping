using UnityEngine;

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