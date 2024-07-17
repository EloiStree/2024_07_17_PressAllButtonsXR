using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllXrPressKingOfTheHillMono : MonoBehaviour
{
    public string m_guid;
    public bool m_useDontDestroyAtLoad = true;
    public static List<AllXrPressKingOfTheHillMono> m_allXrPressKingOfTheHills = new List<AllXrPressKingOfTheHillMono>();

    public UnityEvent m_onDestroyCall;
    public bool m_destroyCurrentObject = true;
    public void DestroyLinkedGameObject() { 
        Destroy(gameObject);
    }
    private void Reset()
    {
        m_guid = System.Guid.NewGuid().ToString();
    }

    private void Awake()
    {
        if (m_useDontDestroyAtLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
        foreach( var v in m_allXrPressKingOfTheHills)
        {
            if (v.m_guid == m_guid)
            {
                CallAutoDestruction();
                return;
            }
        }
        m_allXrPressKingOfTheHills.Add(this);
    }

    private void CallAutoDestruction()
    {
        m_onDestroyCall.Invoke();
        if (m_destroyCurrentObject)
        {
            Destroy(gameObject);
        }
    }
}
