using UnityEngine;

public class TileStats : MonoBehaviour
{

    [SerializeField]
    Attributes stats = new(Attributes.Ai.Clumsy, Attributes.Physical.Small, Attributes.Modifier.Poison);


}
