using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage = 20.0f;
    
    [SerializeField] private float force = 1500.0f;
    
    [SerializeField] private Rigidbody rigidbody;
    void Start()
    {
        
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        int num = int.Parse(Regex.Replace(gameObject.name, @"[^0-9]", ""));
        transform.parent.gameObject.GetComponent<BulletPoolController>().BulletPool().Enqueue(num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForceBullet()
    {
        rigidbody.AddForce(transform.forward * force);
    }
}
