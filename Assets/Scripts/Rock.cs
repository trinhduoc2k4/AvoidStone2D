using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed;
    Rigidbody2D m_rb;
    bool m_isGrounded;
    public bool IsGrounded { get => m_isGrounded; set => m_isGrounded = value; }

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        if(m_rb)
        {
            m_rb.velocity = Vector3.down * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagConsts.GROUND))
        {
            m_isGrounded = true;    
            Destroy(gameObject, 1f);
            AudioController.Ins.PlaySound(AudioController.Ins.hitGround);
        }
    }
}
