using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinna : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead = false;

    private Animator anim;
    
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isDead == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D()
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
