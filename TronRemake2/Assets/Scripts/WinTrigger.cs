using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // General Variables
    public GameObject pbody;
    public GameObject cbody;

    public void PlayerWin()
    {
        // If CPU object is Destroyed, Stop Player Movement
        if (cbody == null)
        {
            PlayerMove PlayScript = pbody.GetComponent<PlayerMove>();

            PlayScript.speed = 0;
        }
    }
    
    public void CPUWin()
    {
        // If Player Object is Destroyed, Stop CPU Movement
        if (pbody == null)
        {
            CPUMove CPUScript = cbody.GetComponent<CPUMove>();

            CPUScript.speed = 0;
        }
    }
}
