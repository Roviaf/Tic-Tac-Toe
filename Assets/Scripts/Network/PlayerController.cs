using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    string Thisone;
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.Mouse0)
        };
        print(EventSystem.current.currentSelectedGameObject.name);
        ClientSend.PlayerMovement(_inputs);
    }
}
