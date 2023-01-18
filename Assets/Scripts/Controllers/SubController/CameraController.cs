using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform TargetTransform;
    [SerializeField] private Transform CameraTransform;
    
    [Range(2.0f, 20.0f)]
    [SerializeField] private float distance;
    
    [Range(0.0f, 10.0f)]
    [SerializeField] private float height;
    
    [SerializeField] private float targetOffset = 2.0f;
    
    [SerializeField] private float damping = 10.0f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        Vector3 pos = TargetTransform.position
                                   + (-TargetTransform.forward * distance)
                                   + (Vector3.up * height);
        
        // CameraTransform.position = Vector3.Lerp(CameraTransform.position,
        //     pos,
        //     Time.deltaTime * damping
        //     );

        CameraTransform.position = Vector3.SmoothDamp(CameraTransform.position,
            pos,
            ref velocity,
            damping);
        
        CameraTransform.LookAt(TargetTransform.position + (TargetTransform.up * targetOffset));
    }
}
