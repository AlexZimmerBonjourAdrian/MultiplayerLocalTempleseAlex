using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFpsController :CBaseController
{
    // Start is called before the first frame update

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
  protected override void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        MovementPlayer();
    }

    protected override void MovementPlayer()
    {
        base.MovementPlayer();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        

        Vector3 move = transform.right * Horizontal + transform.forward * Vertical;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
       
    }
}
