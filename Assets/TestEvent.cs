using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Managers;

public class TestEvent : MonoBehaviour
{
    private void CallEventDebug()
    {        
        EventManager.TriggerEvent(GenericEvents.Test);        
    }
}
