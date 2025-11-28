using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    
    private Animator anim;
    private SpriteRenderer spr;
    private float mouv;
    private Rigidbody2D rgb;

    public Slider slider ;
    public int speed , forcejump;
    private bool jump , grounded;
    private int score ; 

    public Text scoreText; 
    private int bestScore ;


    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rgb = GetComponent<Rigidbody2D>();
        jump = false;
        grounded = false ; 
        slider.value = 10; 
        anim.SetInteger("mort", 0);
        score = 0 ;
        PlayerPrefs.SetInt("score" , score);
        scoreText.text = ""+score;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("hoob") || collision.collider.CompareTag("hoobmoy") || collision.collider.CompareTag("hoobdif") )
        {
            //Debug.Log("Le joueur touche l'ennemi !");
            slider.value -= 1;
            if(slider.value <= 0 ){
                anim.SetInteger("mort", 1);
                //SceneManager.LoadScene("Gameover");
                //Time.timeScale = 0f; 
                StartCoroutine(WaitAndGameOver()); 

            }
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            score = score + 1 ;
            PlayerPrefs.SetInt("score" , score);
            bestScore = PlayerPrefs.GetInt("BestScore",0);
            scoreText.text =  ""+score ;
            if (score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", score);

            }

            Destroy(collision.gameObject);
        }
    }



    public IEnumerator WaitAndGameOver()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Gameover");
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
