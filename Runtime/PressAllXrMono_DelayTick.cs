using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressAllXrMono_DelayTick : MonoBehaviour
{
    public float m_delayTick = 0.1f;
    public UnityEvent m_onTick;
    private void Awake()
    {
        Invoke("LoadTick", m_delayTick);
    }

    [ContextMenu("Load Tick")]
    private void LoadTick()
    {
        m_onTick.Invoke();
    }
}
