
using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9f;
    public float jumpHeight = 3;
    public float xplayerjump = 0;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    
    private Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    
    void Update()
   {
    if(Input.GetButtonDown("Jump"))
     {
         
    mAnimator.SetTrigger("jumpt");
    
       
    }
    
    if(Input.GetButtonDown("Vertical"))
    {
    mAnimator.SetTrigger("trig");
     
    }
    if(Input.GetButtonUp("Vertical"))
     {
       mAnimator.SetTrigger("stoprun");
    }
    	  if(Input.GetButtonDown("Horizontal"))
    {
    mAnimator.SetTrigger("trig");
    }
    if(Input.GetButtonUp("Horizontal"))
    {
       mAnimator.SetTrigger("stoprun");
    }
     if (Input.GetKeyDown(KeyCode.LeftShift))
    {
            speed = 9;
            mAnimator.SetTrigger("sprintt");
    }
    if(Input.GetKeyUp(KeyCode.LeftShift))
    {
        speed = 6;
       mAnimator.SetTrigger("stoprun");
    }
        
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }

}