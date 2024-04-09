using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer_1 : PlayerController
{
    // Start is called before the first frame update

    // Start is called before the first frame update
    public Rigidbody _rigidbodyA;
    private Animator animatorController;
    public float AnimationSpeed = 0;
    public bool ISjumpAnimation = false;

    
    public CPlayer_1()
    {

    }
    public override void Start()
    {
        //base.Start();
        //_rigidbodyA = GetComponent<Rigidbody>();
        base.Start();
        _rigidbodyA = GetComponent<Rigidbody>();
        animatorController = GetComponent<Animator>();
        animatorController.Play("Idle");
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        
            ControllerAnimation();
        
    }
    /*
    public override void SetCountText()
    {
        base.SetCountText();
    }
    */
    public override void Move()
    {
        base.Move();
       // rb.AddForce(movement * speed);
        _rigidbodyA.velocity = (movement * speed);
        //_rigidbodyA.constraints = RigidbodyConstraints.FreezeRotation;
        

        //Dar habilidades especiales
        //Pensar en que hacer 
    }

    public override void EspecialHability()
    {
        base.EspecialHability();

    }
    public override void AsignControll()
    {
        base.AsignControll();

    }
    public void Update()
    {

        ControllerAnimation();
    }

    public void ControllerAnimation()
    {

        animatorController.SetFloat("Speed", movement.magnitude);


        if (AnimationSpeed > 0)
        {
            AnimationSpeed -= 0.10f;
            animatorController.SetFloat("Speed", movement.magnitude);
        }

        else if (AnimationSpeed <= 0)
        {
            AnimationSpeed = 0;
            animatorController.SetFloat("Speed", movement.magnitude);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            ISjumpAnimation = true;
            animatorController.SetBool("IsJump", ISjumpAnimation);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ISjumpAnimation = false;
            animatorController.SetBool("IsJump", ISjumpAnimation);

        }

    }
}




