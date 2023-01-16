using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float hInput;
    private float vInput;

    public float GetHInput()
    {
        return this.hInput;
    }
    public float GetVInput()
    {
        return this.vInput;
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
    }
}
