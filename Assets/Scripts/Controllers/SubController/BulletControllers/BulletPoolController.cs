using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using UnityEngine;

public class BulletPoolController : MonoBehaviour
{
    private Queue<int> bulletPool = new Queue<int>();

    private int bulletCount = 0;
    public Queue<int> BulletPool()
    {
        return bulletPool;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int num = int.Parse(Regex.Replace(transform.GetChild(i).gameObject.name, @"[^0-9]", ""));
            bulletPool.Enqueue(num);
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void eject(Vector3 pos, Quaternion rot)
    {
        if(bulletCount < transform.childCount){
            GameObject bullet = transform.GetChild(bulletCount).gameObject;
            bullet.SetActive(true);
            bullet.transform.SetPositionAndRotation(pos, rot);
            bullet.GetComponent<BulletController>().ForceBullet();
        }
        else
        {
            bulletCount = 0;
            GameObject bullet = transform.GetChild(bulletCount).gameObject;
            bullet.SetActive(true);
            bullet.transform.SetPositionAndRotation(pos, rot);
            bullet.GetComponent<BulletController>().ForceBullet();
        }
        bulletCount += 1;
    }

    public void Eject(Vector3 pos, Quaternion rot)
    {
        eject(pos, rot);
    }
    
}
