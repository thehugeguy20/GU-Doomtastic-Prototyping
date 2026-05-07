using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public Camera cam => GetComponentInChildren<Camera>();
    [SerializeField] private PlayerDataScriptableObject _base;
    [SerializeField] internal PlayerStats stats;

    void Awake()
    {
        stats = new(_base);
    }
}
