using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Base State")]
    public float health;
    public bool isDead;

    public void GetHit(float damage)
    {
        health = health - damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 1;  
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            isDead = true;
            health = 0;
        }
        if (isDead)
        {
           GameObject.Find("Player").GetComponent<shunyi>().MoveToTarget(transform);
           Destroy(gameObject);
        }
    }
}
