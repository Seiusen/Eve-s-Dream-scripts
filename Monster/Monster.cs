using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform startPoint;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] BoxCollider2D boxCol;
    public Transform player;
    public float foundPlayer;

    public float speed;
    public int positionOfPatrol;
    public bool walkingRight;
    public bool patroling;
    public static bool chasing;
    public bool goBack;
    public float boxColDown;
    public float boxColUp;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        patroling = true;
        chasing = false;
        goBack = false;
        speed = 4;
        foundPlayer = 10;
        boxColDown = -2.200336f;
        boxColUp = 2.222674f;
    }


    private void Update()
    {

        if((Vector2.Distance(transform.position, startPoint.position) < positionOfPatrol) && (chasing == false))
        {
            patroling = true;
        }

        if(Vector2.Distance(transform.position, player.position) < foundPlayer)
        {
            chasing = true;
            patroling = false;
            goBack = false;
            speed = 6.5f;
        }

        if(Vector2.Distance(transform.position, player.position) > foundPlayer)
        {
            goBack = true;
            chasing = false;
            speed = 4;
        }

        if(patroling == true)
        {
            Patroling();
        }
        else if(chasing == true)
        {
            Chasing();
        }
        else if(goBack == true)
        {
            GoBack();
        }
    }

    private void Patroling()
    {
        if(transform.position.x > startPoint.position.x + positionOfPatrol)
        {
            walkingRight = false;
        }
        else if(transform.position.x < startPoint.position.x - positionOfPatrol)
        {
            walkingRight = true;
        }

        if(walkingRight == true)
        {
            transform.position = new Vector2(transform.position.x + 1 * speed * Time.deltaTime, transform.position.y);
            sr.flipX = false;
        }
        else if(walkingRight == false)
        {
            transform.position = new Vector2(transform.position.x - 1 * speed * Time.deltaTime, transform.position.y);
            sr.flipX = true;
        }
    }

    private void Chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, 1 * speed * Time.deltaTime);

        if(transform.position.x > player.position.x)
        {
            walkingRight = false;
        }
        else if(transform.position.x < player.position.x)
        {
            walkingRight = true;
        }

        if(walkingRight == true)
        {
            sr.flipX = false;
        }
        else if(walkingRight == false)
        {
            sr.flipX = true;
        }
    }

    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, 1 * speed * Time.deltaTime);

        if(transform.position.x > startPoint.position.x + positionOfPatrol)
        {
            walkingRight = false;
        }
        else if(transform.position.x < startPoint.position.x - positionOfPatrol)
        {
            walkingRight = true;
        }

        if(walkingRight == true)
        {
            transform.position = new Vector2(transform.position.x + 1 * speed * Time.deltaTime, transform.position.y);
            sr.flipX = false;
        }
        else if(walkingRight == false)
        {
            transform.position = new Vector2(transform.position.x - 1 * speed * Time.deltaTime, transform.position.y);
            sr.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Wall")
        {
            StartCoroutine(GravityChangeCooldown());
        }

        if (other.gameObject.tag == "Player")
        {
            Health.hp = 0;
        }
    }

    IEnumerator GravityChangeCooldown()
    {
        yield return new WaitForSeconds(1);
        GravityChange();
    }

    private void GravityChange()
    {
        if(rb.gravityScale == -3)
        {
            rb.gravityScale = 3;
            sr.flipY = false;
            StartCoroutine(MonsterColliderCoroutineDown());
            
        }
        else if(rb.gravityScale == 3)
        {
            rb.gravityScale = -3;
            sr.flipY = true;
            StartCoroutine(MonsterColliderCoroutineUp());
        }
    }

    IEnumerator MonsterColliderCoroutineDown()
    {
        yield return new WaitForSeconds(0.15f);
        boxCol.offset = new Vector2(0, boxColDown);
    }

    IEnumerator MonsterColliderCoroutineUp()
    {
        yield return new WaitForSeconds(0.15f);
        boxCol.offset = new Vector2(0, boxColUp);
    }
}
