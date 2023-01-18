using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private BulletPoolController BulletPoolController;

    [SerializeField] private Transform EjectPos;
    [SerializeField] private float fireSpeed = 720;
    [SerializeField] private int defaultBulletCount = 30;

    private int BulletCount = 30;


    private Coroutine EjectCoroutine;
    private bool IsEjectCoroutineRunnig = false;
    private void OnMouseEventHandler(Constant.MouseEvent evt)
    {
        Fire(evt);
    }
    // Start is called before the first frame update
    void Start()
    {
        BulletCount = defaultBulletCount;
        BulletPoolController = GameObject.Find("BulletPool").GetComponent<BulletPoolController>();
        Managers.Input.MouseAction -= OnMouseEventHandler;
        Managers.Input.MouseAction += OnMouseEventHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire(Constant.MouseEvent evt)
    {
        switch (evt)
        {
            case Constant.MouseEvent.PointerDown:
                StartEjectCoroutine();
                break;
            case Constant.MouseEvent.Pressed:
                break;
            case Constant.MouseEvent.Clicked:
                StopEjectCoroutine();
                break;
            case Constant.MouseEvent.PointerUp:
                StopEjectCoroutine();
                break;
        }
    }

    IEnumerator Eject()
    {
        while(BulletCount > 0){
            BulletPoolController.Eject(EjectPos.position, EjectPos.rotation);
            BulletCount -= 1;
            Debug.Log("fire");
            yield return new WaitForSeconds(1.0f);
        }
        IsEjectCoroutineRunnig = false;
    }

    private void StartEjectCoroutine()
    {
        if(!IsEjectCoroutineRunnig){
            IsEjectCoroutineRunnig = true;
            EjectCoroutine = StartCoroutine(Eject());
        }
    }

    private void StopEjectCoroutine()
    {
        if(IsEjectCoroutineRunnig){
            StopCoroutine(EjectCoroutine);
            IsEjectCoroutineRunnig = false;
        }
    }

    private void Reload()
    {
        BulletCount = defaultBulletCount;
    }
}
