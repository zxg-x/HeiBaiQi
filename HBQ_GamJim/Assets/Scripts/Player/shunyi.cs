using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shunyi : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public void MoveToTarget(Transform targetPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.time+2);
    }
}
