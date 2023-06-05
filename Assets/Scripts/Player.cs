using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    bool isJump = false;

    Vector3 moveVec;

    Rigidbody rigid;

    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeRotation();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");

        moveVec = (hAxis * Camera.main.transform.right + vAxis * Camera.main.transform.forward).normalized;
    }

    void Move()
    {
        if (moveVec != Vector3.zero)
        {
            if (wDown)
                transform.position += moveVec * speed * 0.3f * Time.deltaTime;
            else
                transform.position += moveVec * speed * Time.deltaTime;

            anim.SetBool("isRun", true);
            anim.SetBool("isWalk", wDown);
        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", false);
        }
    }

    void Turn()
    {
        if (moveVec != Vector3.zero)
        {
            Vector3 lookDir = moveVec.normalized;
            lookDir.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(lookDir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
