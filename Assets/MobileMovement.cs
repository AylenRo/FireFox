using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MobileMovement : MonoBehaviour
{
    private SoundManager soundManager;
    [SerializeField]private bl_Joystick Joystick;

    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Animator animator;

    public Transform orientation;

    public bool pressed = false;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    //metodo para el sonido
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public enum MovementState
    {
        walking,
        sprinting,
        air,
        idle
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();


        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        if(pressed == true){
            MovePlayer();
           
        }
    }

    public void PressButton(){
        pressed = true;
        soundManager.SeleccionAudio(1, 3f);
    }
    public void NoPressButton(){
        pressed = false;
        
    }

    private void MyInput()
    {

        // when to jump
        if(SimpleInput.GetButtonDown("Jump") && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();
            soundManager.SeleccionAudio(0, 3f);

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }  

    private void StateHandler()
    {

        // Mode - Sprinting
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        // Mode - Walking
        else if (grounded && pressed == true) 
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
            animator.SetBool("EstaEnMovimiento", true);
        }

        // Mode - Air
        else if(!grounded)
        {
            state = MovementState.air;
            animator.SetBool("EstaSaltando", true);
        }

        else
        {
            state = MovementState.idle;
            animator.SetBool("EstaEnMovimiento", false);
            //animator.SetBool("EstaSaltando", false);
        }
    }

    public void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward ;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        animator.SetBool("EstaSaltando", false);
        readyToJump = true;

    }

}
