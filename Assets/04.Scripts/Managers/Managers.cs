using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static Managers Instance { get { Init(); return s_instance; } }
    
    private InputManager _input_managers = new InputManager();
    public static InputManager Input { get { return Instance._input_managers; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static void Init() {
        if (s_instance == null) {
            GameObject Go = GameObject.Find("@Managers");
            if (Go == null) {
                Go = new GameObject("@Managers");
                Go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(Go);
            s_instance = Go.GetComponent<Managers>();
        }
    }   
    // Update is called once per frame
    void Update()
    {
        Input.OnUpdate();
    }
}
