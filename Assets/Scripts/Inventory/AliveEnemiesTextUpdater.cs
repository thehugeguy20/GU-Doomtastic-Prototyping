using TMPro;
using UnityEngine;

public class AliveEnemiesTextUpdater : MonoBehaviour
{
    public REALLevelManagerREAL lvlManager;
    public TextMeshProUGUI thisText;

    // Update is called once per frame
    void Update()
    {
        thisText.text = $"Alive Enemies: {lvlManager.aliveEnemies}";
    }
}
