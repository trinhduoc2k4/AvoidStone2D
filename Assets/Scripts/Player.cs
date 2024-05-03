using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    Rigidbody2D m_rb;
    Animator m_anim;
    float HorizontalInput;
    public float speed;
    bool m_isDead;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>(); 
        m_anim = GetComponent<Animator>(); 
    }
    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        Flip();
    }

    

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (m_rb) m_rb.velocity = new Vector2(HorizontalInput, m_rb.velocity.y) * speed;

        if (m_anim) m_anim.SetBool("running", true);      

        
        if(HorizontalInput == 0) 
        {
            m_rb.velocity = new Vector2(0, m_rb.velocity.y);

            if (m_anim) m_anim.SetBool("running", false);
        }
    }

    private void Flip()
    {
        if (HorizontalInput < 0) 
            if(transform.localScale.x < 0) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); 
            else if (transform.localScale.x > 0) transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
        if (HorizontalInput > 0)
            if (transform.localScale.x < 0) transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            else if (transform.localScale.x > 0) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(TagConsts.ROCK))
        {
            if(m_isDead) return;    

            Rock rock = collision.gameObject.GetComponent<Rock>();  
            if(rock && !rock.IsGrounded)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (m_anim) m_anim.SetTrigger("dead");
        AudioController.Ins.PlaySound(AudioController.Ins.loseSound);
        GameManger.Ins.ShowGameOverUI();
    }
}
