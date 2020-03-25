/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */
using System; 
using System.Linq; 
using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class SampleUserPolling_ReadWrite : MonoBehaviour
{
    public SerialController serialController;
    bool canSendInput = true;
    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        Debug.Log("Press A or Z to execute some actions");
    }

    IEnumerator delay()
    {
        canSendInput = false;
        yield return new WaitForSeconds(1);
        canSendInput = true;
    }
    void OnMessageArrived(string msg)
    {
        print("Messaged recieved from Arduino " + msg);
    }


    void OnConnectionEvent(bool success)
    {
        print("Connected to Arduino? "+success);
    }

    // Executed each frame
    void Update()
    {
        if (Input.inputString != "")
        {
            int asciiCode = System.Convert.ToInt32(Input.inputString[0]);
            serialController.SendSerialMessage(Input.inputString.Substring(0,1));
        }
    }
}
