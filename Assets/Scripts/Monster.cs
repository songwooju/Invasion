using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Rigidbody target;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 3.0f;

    void Update()
    {
        if (target != null)
        {
            // 몬스터가 플레이어를 바라보도록 회전
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // 몬스터가 플레이어를 향해 이동
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
