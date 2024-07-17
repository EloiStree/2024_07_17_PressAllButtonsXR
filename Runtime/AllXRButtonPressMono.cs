using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class AllXRButtonPress : MonoBehaviour
{
    private AllXrButtons inputActions;

    private void Awake()
    {
        inputActions = new AllXrButtons();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.AllButtons.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.AllButtons.Disable();
    }
    public bool m_isLeftUp;
    public bool m_isLeftDown;
    public bool m_isRightUp;
    public bool m_isRightDown;

    public bool m_isLeftTriggetDown;
    public bool m_isRightTriggetDown;
    public bool m_isLeftGrabDown;
    public bool m_isRightGrabDown;

    public bool m_isAllDown;
    public bool m_isAllButtonsDown;
    public bool m_isAllGrabTriggersDown;

    public UnityEvent<bool> m_onIsAllTriggersDown;
    public UnityEvent<bool> m_onIsAllButtonsDown;
    public UnityEvent<bool> m_onIsAllDown;

    private void Update()
    {
        
        m_isLeftUp = inputActions.AllButtons.LeftTopButton.IsPressed();
        m_isLeftDown = inputActions.AllButtons.LeftDownButton.IsPressed();
        m_isRightUp = inputActions.AllButtons.RightTopButton.IsPressed();
        m_isRightDown = inputActions.AllButtons.RightDownButton.IsPressed();

        m_isLeftTriggetDown = inputActions.AllButtons.TriggerLeft.IsPressed();
        m_isRightTriggetDown = inputActions.AllButtons.TriggerRight.IsPressed();
        m_isLeftGrabDown = inputActions.AllButtons.GrabLeft.IsPressed();
        m_isRightGrabDown = inputActions.AllButtons.GrabRight.IsPressed();
    
        bool prevAllDown = m_isAllDown;
        bool prevAllButtonsDown = m_isAllButtonsDown;
        bool prevAllGrabTriggersDown = m_isAllGrabTriggersDown;


        m_isAllDown = m_isLeftDown && m_isRightDown && m_isLeftUp && m_isRightUp;
        m_isAllButtonsDown = m_isLeftDown && m_isRightDown && m_isLeftUp && m_isRightUp && m_isLeftTriggetDown && m_isRightTriggetDown;
        m_isAllGrabTriggersDown = m_isLeftTriggetDown && m_isRightTriggetDown && m_isLeftGrabDown && m_isRightGrabDown;
    

        if( prevAllDown != m_isAllDown)
            m_onIsAllDown.Invoke(m_isAllDown);
        if( prevAllButtonsDown != m_isAllButtonsDown)
            m_onIsAllButtonsDown.Invoke(m_isAllButtonsDown);
        if( prevAllGrabTriggersDown != m_isAllGrabTriggersDown)
            m_onIsAllTriggersDown.Invoke(m_isAllGrabTriggersDown);


    }

    public void DebugBool(bool value)
    {
        Debug.Log("Debug Bool:"+value);
    }
}
