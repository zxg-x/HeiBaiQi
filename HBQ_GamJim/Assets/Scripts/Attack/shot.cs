using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{

    public Rigidbody2D Bullet; //申明
    public float bulletspeed;//子弹速度

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //角度获取

        Vector3 mousePosition = Input.mousePosition;
        Vector3 vpos3 = Camera.main.ScreenToWorldPoint(mousePosition);

        vpos3.z = 0;

        // 子弹角度
        float fireangle = Vector2.Angle(vpos3 - transform.position, Vector2.up);

        if (vpos3.x > transform.position.x)
        {
            fireangle = -fireangle;
        }
        //子弹射击
        if (Input.GetButtonDown("Fire1"))
        {
            //产生子弹
            Rigidbody2D bInsullettance = Instantiate(Bullet, transform.position, Quaternion.identity) as Rigidbody2D;


            //速度和角度
            bInsullettance.velocity = ((vpos3 - transform.position).normalized * bulletspeed);
            bInsullettance.gravityScale = 0;
            bInsullettance.transform.eulerAngles = new Vector3(0, 0, fireangle);
        }
        
    }
    
}