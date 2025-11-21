using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    
    private Animator anim;
    private SpriteRenderer spr;
    private float mouv;
    private Rigidbody2D rgb;

    public int speed , forcejump;
    private bool jump , grounded;


    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rgb = GetComponent<Rigidbody2D>();
        jump = false;
        grounded = false ; 

    }

    // Update is called once per frame
    void Update()
    {


        mouv = Input.GetAxis("Horizontal");
        Flip();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(grounded)
                jump = true;
               
        }
        
    }
    //utiliser quand on a un movement pour prend le temps comme critere pour etre plus de reels (frame de meme temps)
    void FixedUpdate()
    {
        rgb.velocity = new Vector2(mouv * speed, rgb.velocity.y);
        anim.SetFloat("Speed", Math.Abs(mouv));

        if (rgb.velocity.y == 0)
        {
            grounded = true;
        }

        if (jump)
        {
            
            rgb.AddForce(transform.up * forcejump);
            jump = false;
            grounded = false;
        }

    }


    void Flip()
    {
        if (mouv < 0)
        {
            spr.flipX = true;
        }
        else
        {
            spr.flipX = false; 
        }    
    }
}
