using UnityEngine;

public class TileStats : MonoBehaviour
{

    [SerializeField]
    Attributes stats = new(Attributes.Ai.clumsy, Attributes.Physical.small, Attributes.Modifier.poison);


}
