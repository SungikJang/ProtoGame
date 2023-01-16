using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    public enum MouseEvent {
        PointerDown,
        Clicked,
        Pressed,
        PointerUp
    }
    public enum CursorState {
        None,
        Basic,
        Attack
    }
    public enum KeyBoardEvent {
        Clicked,
        Pressed,
        none
    }
}
