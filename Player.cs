using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    public int jumpForce;   
    public Vector2 move;
    private Vector2 positionPS;
    public GameObject darkBall;
    public GameObject fxCloud;
    public GameObject fx;
    public GameObject target;
    public GameObject theEnd;
    public GameObject pause;
    public AudioClip jumpCloud;
    public AudioClip gameOverSfx;
    public AudioSource AS;
    public bool isPause;
    public float speed;
    private bool readyToDown;

    public int score;
    public Text scoreText;
    private float tempScore;


    void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        anim = darkBall.GetComponent<Animator>();
        sr = darkBall.GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
        

    }
  
    void Update()
    {
        Vector2 dir = new Vector2(target.transform.position.x, darkBall.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if (transform.position.y > 0)
        {
            darkBall.transform.position = new Vector2(transform.position.x, 0);
            GetComponent<CircleCollider2D>().enabled = false;

            tempScore += Time.deltaTime * 10;
            if (tempScore > 1)
            {
                score++;
                scoreText.text = score.ToString();
                tempScore = 0;
            }
        }

        if (transform.position.y < 0)
        {
            GetComponent<CircleCollider2D>().enabled = true;          
        }
       
    }     
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud"))
        {
            
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(0, 10);
            AS.clip = jumpCloud;
            AS.Play();

            anim.SetTrigger("Jump");           
            var c = Instantiate(fxCloud, new Vector2(transform.position.x,collision.transform.position.y), Quaternion.identity) as GameObject;
            c.transform.SetParent(collision.transform);
            Destroy(c, 0.5f);
            
            
        }
        if (collision.gameObject.CompareTag("brokenCloud"))
        {
            AS.clip = jumpCloud;
            AS.Play();
            GameObject c = Instantiate(fx, collision.transform.position, Quaternion.identity) as GameObject;
            Destroy(c, 0.5f);
            Destroy(collision.gameObject);     
            
        }
        if (collision.gameObject.CompareTag("destroyer"))
        {          
            Time.timeScale = 0.0001f;
            theEnd.SetActive(true);
            AS.clip = gameOverSfx;
            AS.Play();
            int tempHS = PlayerPrefs.GetInt("HS", 0);
            if (tempHS < score)
            {
                PlayerPrefs.SetInt("HS", score);
            }
            
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Pause()
    {
        if (!isPause)
        {
            pause.SetActive(true);
            Time.timeScale = 0.0001f;
            isPause = true;
        }
        else if (isPause)
        {
            pause.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
    }
    


}
