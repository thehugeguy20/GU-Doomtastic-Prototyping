using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class TimeScaleManager : MonoBehaviour
{
    public static TimeScaleManager _singleton;

    public static TimeScaleManager singleton
    {
        get
        {
            if (_singleton == null)
            {
                Debug.LogError("singleton is null");
            }
            return _singleton;
        }
    }

    private void Awake()
    {
        _singleton = this;
    }

    public Coroutine HitStop(float duration)
    {
        Time.timeScale = 0f;
        Coroutine freezeCoroutine = StartCoroutine(UnfreezeHitStop(duration));
        return freezeCoroutine;
    }

    public IEnumerator UnfreezeHitStop(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        yield return null;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void StartTime()
    {
        Time.timeScale = 1f;
    }
}
