using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2);
    }
     
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            // 找到敌人对应的脚本，调用其GetHit方法，敌人掉血
            col.gameObject.GetComponent<Enemy>().GetHit(1);

            // 销毁当前的子弹对象
            Destroy(gameObject);
        }
    }
}
