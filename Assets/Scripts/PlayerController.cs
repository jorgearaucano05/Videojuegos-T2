using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocityX = 10;
    public float jumpforce = 50;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator _animator;
    
    
    private ScoreController game;
    
    public GameObject rightBall;
    public GameObject leftBall;
    public GameObject rightBallMed;
    public GameObject leftBallMed;
    private bool isDead = false;

    private float chargeTime = 0;
    private float chargeTime2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        game = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            _animator.SetInteger("Estado",0);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity=new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                _animator.SetInteger("Estado",1);
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity=new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                _animator.SetInteger("Estado",1);
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
                _animator.SetInteger("Estado",2);
                
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.right*velocityX;
                sr.flipX = false;
                _animator.SetInteger("Estado", 3);
            }

            if (Input.GetKey(KeyCode.S))
            {
                chargeTime += Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (chargeTime<1)
                {
                    //QUIETO DISPARAR
                    _animator.SetInteger("Estado", 4);
                    Debug.Log("BALAAAAAAAAAAAA CHICA");
                    var bullet = sr.flipX ? leftBall : rightBall;
                    var position = new Vector2(transform.position.x,transform.position.y);
                    var rotation = rightBall.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                
                else if (chargeTime<5)
                {
                    //DISPARAR BALA GRANDE
                
                    _animator.SetInteger("Estado", 4);
                    Debug.Log("BALAAAAAAAAAAAA MEDIA");
                    var bullet = sr.flipX ? leftBallMed : rightBallMed;
                    var position = new Vector2(transform.position.x,transform.position.y);
                    var rotation = rightBallMed.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                chargeTime = 0;

            }
            
            if (Input.GetKey(KeyCode.C))
            {
                chargeTime2 += Time.deltaTime;
            }
            
            if (Input.GetKeyUp(KeyCode.C))
            {
                if (chargeTime2 < 1)
                {
                    _animator.SetInteger("Estado", 5);
                    Debug.Log("BALAAAAAAAAAAAA CHICA");
                    var bullet = sr.flipX ? leftBall : rightBall;
                    var position = new Vector2(transform.position.x,transform.position.y);
                    var rotation = rightBall.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                else if (chargeTime2<5)
                {
                    //DISPARAR BALA GRANDE
                
                    _animator.SetInteger("Estado", 5);
                    Debug.Log("BALAAAAAAAAAAAA MEDIA");
                    var bullet = sr.flipX ? leftBallMed : rightBallMed;
                    var position = new Vector2(transform.position.x,transform.position.y);
                    var rotation = rightBallMed.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                chargeTime2 = 0;
            }
            
            
            /*if (Input.GetKeyDown(KeyCode.A))
            {
                //DISPARAR BALA GRANDE
                
                _animator.SetInteger("Estado", 4);
                Debug.Log("BALAAAAAAAAAAAA MEDIA");
                var bullet = sr.flipX ? leftBallMed : rightBallMed;
                var position = new Vector2(transform.position.x,transform.position.y);
                var rotation = rightBallMed.transform.rotation;
                Instantiate(bullet, position, rotation);
                
            }*/
            
            
            /*if (Input.GetKey((KeyCode.RightArrow))&&(Input.GetKey(KeyCode.C)))
            {
                //CORRER Y DISPARAR
                rb.velocity=new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                _animator.SetInteger("Estado", 5);
                
            }*/
            
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(0, 0);
                _animator.SetInteger("Estado", 6);
                
            }
            
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            game.LoseLife();
        }
        
        if(collision.gameObject.name=="LLAVE")
        {
            SceneManager.LoadScene("Scena02");
        }


    }
}
