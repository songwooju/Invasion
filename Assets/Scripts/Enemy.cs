using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public RuntimeAnimatorController[] animCon;
    public bool isChase;
    public float health;
    public float maxHealth;

    bool isLive;

    Rigidbody rigid;
    Animator anim;
    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();

        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            target = GameManager.instance.player.transform;
        }

        Invoke("ChaseStart", 1);
    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }

    void Update()
    {
        if (isChase)
        {
            nav.SetDestination(target.position);
        }
    }

    void OnEnable()
    {
        isLive = true;
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isLive)
            return; // Don't take damage if already dead

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isLive = false;
        // Perform death animation or other actions

        GameManager.instance.IncreaseKillCount(); // Increase kill count
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(100);
        }
    }
}