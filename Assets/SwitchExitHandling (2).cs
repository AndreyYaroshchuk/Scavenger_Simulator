using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchExitHandling : MonoBehaviour
{
    

#if UNITY_SWITCH && !UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        UnityEngine.Switch.Notification.EnterExitRequestHandlingSection();
        UnityEngine.Switch.Notification.notificationMessageReceived += YourSystemMessageHandler;
    }

    static void YourSystemMessageHandler(UnityEngine.Switch.Notification.Message message)
    {
        
            if (message == UnityEngine.Switch.Notification.Message.ExitRequest)
            {
                SaveBridge.SaveAllData(true);
                UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection();
            }
    }
#endif
}