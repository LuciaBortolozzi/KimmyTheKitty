using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    private PlayerMoveJoystick playerMove;

    private void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
            playerMove.SetMoveLeft(true);
        else
            playerMove.SetMoveLeft(false);
        
            
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving();
    }
}
