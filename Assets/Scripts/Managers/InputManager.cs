using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<Constant.MouseEvent> MouseAction = null;
    private bool MousePressed = false;
    private float PressedTime;
    
    private float hInput;
    private float vInput;
    private float mouseX;

    public float HInput()
    {
        return this.hInput;
    }
    public float VInput()
    {
        return this.vInput;
    }
    public float MouseX()
    {
        return this.mouseX;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        this.hInput = Input.GetAxis("Horizontal");
        this.vInput = Input.GetAxis("Vertical");
        this.mouseX = Input.GetAxis("Mouse X");
        
        if (MouseAction != null) {

            if (Input.GetMouseButton(0)) {
                if (MousePressed == false) {
                    MouseAction.Invoke(Constant.MouseEvent.PointerDown);
                    MousePressed = true;
                    PressedTime = Time.time;
                }
                else {
                    MouseAction.Invoke(Constant.MouseEvent.Pressed);
                }
            }
            else {
                if (MousePressed == true) {
                    if (Time.time - PressedTime < 0.1f) {
                        MouseAction.Invoke(Constant.MouseEvent.Clicked);
                    }
                    else {
                        MouseAction.Invoke(Constant.MouseEvent.PointerUp);
                    }
                    MousePressed = false;
                    PressedTime = 0;
                }

            }
        }
    }
}
