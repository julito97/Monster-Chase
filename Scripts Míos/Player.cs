using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    [SerializeField]
    private Rigidbody2D myBody;
    private Animator myAnimator;
    private string walkAnimation = "Walk"; // Same name as the state in the animator section
    private string ground_tag = "Ground"; //To now allow the player to jump twice at the same time
    private SpriteRenderer sr; // For the flip property
    private bool isGrounded;

    // Allows the player to move
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        myBody.AddForce(new Vector2(2, 2));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerKeyMovement();
        AnimatePlayer();
    }

    private void FixedUpdate() // Not called every frame
    {
        PlayerJump();
    }

    void PlayerKeyMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //or GetAxis
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer() //Move hands while moving
    {
        // We're going to the right side
        if(movementX > 0) {
            myAnimator.SetBool(walkAnimation, true);
            sr.flipX = false;
        }

        else if(movementX < 0)
        {
            myAnimator.SetBool(walkAnimation, true);
            sr.flipX = true;
        }

        else
        {
            myAnimator.SetBool(walkAnimation, false);
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(ground_tag))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

       }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    }

