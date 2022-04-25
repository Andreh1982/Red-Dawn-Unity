using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Rigidbody2D bodyCharacter;

    private float direction;
    public float speed;
    public float jump;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool isLookingRight = true;

    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, whatIsGround);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speedY", bodyCharacter.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(direction)); 

        direction = Input.GetAxisRaw("Horizontal");
        bodyCharacter.velocity = new Vector2(direction * speed, bodyCharacter.velocity.y);

        if ((direction < 0 && isLookingRight) || (direction > 0 && !isLookingRight))
        {
            isLookingRight = !isLookingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            bodyCharacter.velocity = Vector2.up * jump;
        }

    }
}
