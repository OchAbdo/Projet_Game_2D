using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : MonoBehaviour
{

    public Animator anim;      
    public GameObject enemy;     
    public GameObject enemymoy;
    public GameObject enemydif;

    public AudioSource audioSource;
    public AudioClip attackSound;


    void Start()
    {
    
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hoob"))
        {
            Destroy(enemy);
        }

        if (collision.CompareTag("hoobmoy"))
        {
            Destroy(enemymoy);
        }

        if (collision.CompareTag("hoobdif"))
        {
            Destroy(enemydif);
        }
    } 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            audioSource.PlayOneShot(attackSound);
             anim.SetBool("att", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            anim.SetBool("att", false);
        }
        
    }

    
}
