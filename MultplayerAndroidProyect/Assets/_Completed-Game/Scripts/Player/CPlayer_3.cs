using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer_3 : PlayerController
{
    public Rigidbody _rigidbodyA;
    private Animator animatorController;
    public float AnimationSpeed = 0;
    public bool ISjumpAnimation = false;
    // Start is called before the first frame update
    public CPlayer_3()
    {

    }
    public override void Start()
    {
        base.Start();
        _rigidbodyA = GetComponent<Rigidbody>();
        animatorController = GetComponent<Animator>();
        animatorController.Play("Idle");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public void Update()
    {

     //   ControllerAnimation();
      
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
        // _rigidbodyA.constraints = RigidbodyConstraints.None;
       // P3Controller();
        //P3Controller();
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
    //public override void P3Controller()
    //{
    //    base.P3Controller();
    //    _rigidbodyA.velocity = (movement * speed);
    //}

    //public void ControllerAnimation()
    //{
    //    if (Input.GetKey(KeyCode.V))
    //    {
    //        AnimationSpeed = 1;
    //        animatorController.SetFloat("Speed", AnimationSpeed);
    //    }
    //    else
    //    {
    //        if (AnimationSpeed > 0)
    //        {
    //            AnimationSpeed -= 0.10f;
    //            animatorController.SetFloat("Speed", AnimationSpeed);
    //        }

    //        else if (AnimationSpeed <= 0)
    //        {
    //            AnimationSpeed = 0;
    //            animatorController.SetFloat("Speed", AnimationSpeed);
    //        }


    //    }
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {

    //        ISjumpAnimation = true;
    //        animatorController.SetBool("IsJump", ISjumpAnimation);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        ISjumpAnimation = false;
    //        animatorController.SetBool("IsJump", ISjumpAnimation);

    //    }
    //}
}
