using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    }
}
