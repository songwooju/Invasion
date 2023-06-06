using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage = 10.0f;
    public float speed = 1000.0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(-transform.forward * speed);
        Destroy(gameObject, 1.0f); // 2초 후에 자신을 파괴
    }

    void Update()
    {

    }
}
