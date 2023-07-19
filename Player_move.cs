using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public static float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public CapsuleCollider2D capcol;
    public Transform PlayerTransform;
    public int rightCheck = 0;
    public static int reverseCheck = 0;

    public static bool isGrounded;
    public Transform groundCheckCollider;
    public Transform groundCheckColliderHead;
    public LayerMask groundLayer;
    const float groundCheckRadius = 0.2f;

    public static bool lightIdle;
    public static bool rightWalking;
    public static bool lightReverse;

    const float capcolDown = -0.1752148f;
    const float capcolUp = 0.1752148f;

    public VectorValue pos;

    public static int damage;
    public static bool damaged;
    private float movement;

    public static bool walking;
    public static bool running;
    public static bool gravityChangedWater;
    public static bool gravityChangedFood;

    /*public static float gravityValue;
    public static float gravityToLoad;
    public static bool flippedY;
    public static bool flippedYToLoad;*/

    public static bool destinyGained;
 
    void Start() 
    {
        isGrounded = false;
        lightIdle = true;
        rightWalking = false;
        transform.position = pos.initialValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        capcol = GetComponent<CapsuleCollider2D>();
        damage = 0;
        running = false;
        walking = false;
        gravityChangedWater = false;
        gravityChangedFood = false;
        /*gravityValue = rb.gravityScale;*/
        /*flippedY = sr.flipY;*/
    }

    void Update() 
    {
        GroundCheck();

        Movement();

        GravityChange();

        Run();

        DestinyCheck();

        /*Loaded();*/
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        Collider2D[] collidersHead = Physics2D.OverlapCircleAll(groundCheckColliderHead.position, groundCheckRadius, groundLayer);
        if(colliders.Length > 0 | collidersHead.Length > 0)
        {
            isGrounded = true;
        }
    }

    void Movement()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if ((Input.GetKey(KeyCode.D)) & (Input.GetKey(KeyCode.A)))
        {
            movement = 0;
            speed = 0;
            walking = false;
        }
        if ((Input.GetKey(KeyCode.A)) & (Input.GetKeyUp(KeyCode.D)))
        {
            sr.flipX = false;
            rightCheck = 0;
            rightWalking = false;
            walking = true;
        }
        else if ((Input.GetKey(KeyCode.D)) & (Input.GetKeyUp(KeyCode.A)))
        {
            sr.flipX = true;
            rightCheck = 1;
            rightWalking = true;
            walking = true;
        }
        else if(Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = 6;
            sr.flipX = true;
            rightCheck = 1;
            rightWalking = true;
            walking = true;
        }
        else if((rightCheck == 1) && (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            speed = 6;
            sr.flipX = false;
            rightCheck = 0;
            rightWalking = false;
            walking = true;
        }

        if (movement == 0)
        {
            anim.SetBool("isWalking", false);
            lightIdle = true;
            speed = 0;
            walking = false;
        }
        else
        {
            anim.SetBool("isWalking", true);
            lightIdle = false;
            speed = 6;
            walking = true;
        }

        
    }

    private void Run()
    {
        if ((movement != 0) && Input.GetKey(KeyCode.LeftShift) && (Stamina.stamina >= 1) && ((Input.GetKey(KeyCode.D)) | (Input.GetKey(KeyCode.A))))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", true);
            lightIdle = false;
            speed = 7.5f;
            /*speed = 7.5f;*/
            running = true;
            walking = false;
            if (Input.GetKey(KeyCode.D))
            {
                rightWalking = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rightWalking = false;
            }
        }
        else if ((Input.GetKeyUp(KeyCode.LeftShift)) | (Stamina.stamina <= 0))
        {
            anim.SetBool("isRunning", false);
            lightIdle = false;
            running = false;
            speed = 6f;
            StartCoroutine(RunCoroutine());
        }
        else if ((Input.GetKey(KeyCode.LeftShift)) & (Stamina.stamina <= 0))
        {
            anim.SetBool("isRunning", false);
            lightIdle = false;
            running = false;
            speed = 6f;
            StartCoroutine(RunCoroutine());
        }
        else if ((movement == 0) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
            lightIdle = true;
            running = false;
        }
    }

    void GravityChange()
    {
        if(isGrounded == false)
        {
            if(rb.gravityScale > 0)
            {
                rb.gravityScale += (Time.deltaTime * 5);
                /*gravityValue = rb.gravityScale;*/
            }
            else if(rb.gravityScale < 0)
            {
                rb.gravityScale -= (Time.deltaTime * 5);
                /*gravityValue = rb.gravityScale;*/
            }
        }
        else if(isGrounded == true)
        {
            if(rb.gravityScale > 0)
            {
                lightReverse = false;
                if ((rb.gravityScale >= 7.5) & (rb.gravityScale < 8))
                {
                    damage = 5;
                }
                else if ((rb.gravityScale >= 8) & (rb.gravityScale < 9.5))
                {
                    damage = 10;
                }
                else if ((rb.gravityScale >= 9.5) & (rb.gravityScale < 11))
                {
                    damage = 30;
                }
                else if (rb.gravityScale >= 11)
                {
                    damage = 100;
                }
                rb.gravityScale = 3;
                /*gravityValue = rb.gravityScale;*/
            }
            else if (rb.gravityScale < 0)
            {
                lightReverse = true;
                if ((rb.gravityScale <= -7.5) & (rb.gravityScale > -8))
                {
                    damage = 5;
                }
                else if ((rb.gravityScale <= -8) & (rb.gravityScale > -9.5))
                {
                    damage = 10;
                }
                else if ((rb.gravityScale <= -9.5) & (rb.gravityScale > -11))
                {
                    damage = 30;
                }
                else if ((rb.gravityScale <= -11))
                {
                    damage = 100;
                }
                rb.gravityScale = -3;
                /*gravityValue = rb.gravityScale;*/
            }
        }

        if((isGrounded == true) && (reverseCheck == 0) && Input.GetKeyDown(KeyCode.Space))
        {
            gravityChangedWater = true;
            gravityChangedFood = true;
            sr.flipY = true;
            /*flippedY = sr.flipY;*/
            rb.gravityScale = -3;
            /*gravityValue = rb.gravityScale;*/
            reverseCheck = 1;
            StartCoroutine(ColliderCoroutineUp());
        }
        else if((isGrounded == true) &&  (reverseCheck == 1) && (Input.GetKeyDown(KeyCode.Space)))
        {
            gravityChangedWater = true;
            gravityChangedFood = true;
            sr.flipY = false;
            /*flippedY = sr.flipY;*/
            rb.gravityScale = 3;
            /*gravityValue = rb.gravityScale;*/
            reverseCheck = 0;
            StartCoroutine(ColliderCoroutineDown());
        }
    }


    IEnumerator ColliderCoroutineDown()
    {
        yield return new WaitForSeconds(0.15f);
        capcol.offset = new Vector2(0, capcolDown);
    }

    IEnumerator ColliderCoroutineUp()
    {
        yield return new WaitForSeconds(0.15f);
        capcol.offset = new Vector2(0, capcolUp);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        damaged = true;
    }


    /*public void Loaded()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            rb.gravityScale = gravityToLoad;
            transform.position = AllData.positionToLoad;
            sr.flipY = flippedYToLoad;
        }
    }*/

    public void DestinyCheck()
    {
        if(DestinyFinal.destiny == true)
        {
            destinyGained = true;
        }
    }

    IEnumerator RunCoroutine()
    {
        yield return new WaitForSeconds(1f);
    }

}
