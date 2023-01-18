using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{

    private Transform MyPlayerTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private GameObject RWeaponHolder;
    [SerializeField] private GameObject LWeaponHolder;

    private GameObject nowWeapon;
    
    private Animation MyPlayerAnimation;
    void Awake()
    {
        // 가장 먼저 호출되는 함수
        // 스크립트가 비활성화돼 있어도 호출되는 함수
    }
    void OnEnable()
    {
        // 두번째로 호출되는 함수
        // 스크립트가 활성화될 때마다 호출되는 함수
    }
    void Start()
    {
        // 세번째로 호출되는 함수
        // Update 함수가 호출되기 전에 호출되는 함수
        // 코루틴으로 호출될 수 있는 함수
        MyPlayerTransform = GetComponent<Transform>();
        MyPlayerAnimation = GetComponent<Animation>();

        MyPlayerAnimation.Play("Idle");

        nowWeapon = Resources.Load<GameObject>("Prefabs/w_rifle01");
        GameObject weaponInstance = PrefabUtility.InstantiatePrefab(nowWeapon) as GameObject;
        weaponInstance.transform.SetParent(RWeaponHolder.transform);
        weaponInstance.transform.localPosition = Vector3.zero;
        weaponInstance.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
    void Update()
    {
        // 프레임마다 호출되는 함수
        // 호출 간격이 불규칙적인 함수
        // 화면의 랜더링 추기와 일치
    }
    private void LateUpdate()
    {
        // Update 함수가 종료된후 호출되는 함수
    }

    private void FixedUpdate()
    {
        //일정한 간격으로 호출되는 함수(가본값 : 0.02초)
        // 물리 엔진의 계산 주기와 일치
        Vector3 Movedir = (Managers.Input.VInput() * Vector3.forward + Managers.Input.HInput() * Vector3.right);
        
        MyPlayerTransform.Translate(Movedir.normalized * moveSpeed * Time.deltaTime);
        
        MyPlayerTransform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * Managers.Input.MouseX());
        
        PlayAnimation(Managers.Input.HInput(), Managers.Input.VInput());
    }



    private void PlayAnimation(float h, float v)
    {
        if (v >= 0.1f)
        {
            MyPlayerAnimation.CrossFade("RunF", 0.25f);
        }else if (v <= -0.1f)
        {
            MyPlayerAnimation.CrossFade("RunB", 0.25f);
        }else if (h >= 0.1f)
        {
            MyPlayerAnimation.CrossFade("RunR", 0.25f);
        }else if (h <= -0.1f)
        {
            MyPlayerAnimation.CrossFade("RunL", 0.25f);
        }
        else
        {
            MyPlayerAnimation.CrossFade("Idle", 0.25f);
        }
    }
}
