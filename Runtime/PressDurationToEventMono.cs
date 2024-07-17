using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressDurationToEventMono : MonoBehaviour
{

    public bool m_isPressed = false;
    public float m_currentTimePressed;

    public DurationEvent[] m_durationEvents;
    [System.Serializable]
    public class DurationEvent { 
    
        public float m_duration;
        public UnityEvent m_event;
        
    }
    public void SetAsPressed(bool isDown) {
        bool changed = m_isPressed != isDown;
        if (changed)
        {
            if (!isDown) { 
                m_currentTimePressed = 0;
                m_previousTimePressed = 0;
            }
        }
        m_isPressed = isDown;
    }

    private float m_previousTimePressed;
    public void Update()
    {
        
        if (m_isPressed)
        {
            m_previousTimePressed = m_currentTimePressed;
            m_currentTimePressed += Time.deltaTime;
            
            for (int i = 0; i < m_durationEvents.Length; i++)
            {
                float t = m_durationEvents[i].m_duration;
                if (t <= m_currentTimePressed && t > m_previousTimePressed) {

                    m_durationEvents[i].m_event.Invoke();
                }
            }
            
        }
    }
}
