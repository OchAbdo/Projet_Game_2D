using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator anim;               


    void Start()
    {
    
            anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hoob"))
        {
            Debug.Log("nagiss dam");
        }
    } 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
             anim.SetBool("att", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            anim.SetBool("att", false);
        }
        
    }

    
}
