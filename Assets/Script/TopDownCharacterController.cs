using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownCharacterController : MonoBehaviour
{
    public VariableJoystick joystick;
    public float speed = 2f;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector2 direction;
    private float horizontal, vertical = 0f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = joystick.Horizontal != 0 ? joystick.Horizontal: Input.GetAxisRaw("Horizontal");
        vertical = joystick.Vertical != 0 ? joystick.Vertical: Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Magnitude", direction.magnitude);

        if (horizontal != 0 || vertical != 0){
            animator.SetFloat("LastHorizontal", horizontal);
            animator.SetFloat("LastVertical", vertical);
        }  
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move(){
        rigidbody2D.velocity = direction * speed;
    }
}
