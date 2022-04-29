using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

public Rigidbody2D bodyCharacter;

private float direction;
public float speed;
public float jump;

private bool isGrounded;
public Transform groundCheck;
public LayerMask whatIsGround;

private bool isLookingRight = true;
private int doubleJump = 2;

public Animator animator;

    void Update() 
    {
        Move();
        Jump();
    }

    void Move() 
    {
        CheckFloor();
        animator.SetFloat("speed", Mathf.Abs(direction));
        direction = Input.GetAxisRaw("Horizontal");
        bodyCharacter.velocity = new Vector2(direction * speed, bodyCharacter.velocity.y);

        if ((direction < 0 && !isLookingRight) || (direction > 0 && isLookingRight)) {
            isLookingRight = !isLookingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Jump() 
    {
        CheckFloor();
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speedY", bodyCharacter.velocity.y);

        if (doubleJump > 0 && Input.GetKeyDown(KeyCode.Space)) {
            doubleJump--;
            bodyCharacter.velocity = Vector2.up * jump;
        }  
    }

    void CheckFloor() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, whatIsGround);
        if (isGrounded) {
            doubleJump = 2;
        }
    }
}
