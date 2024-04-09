using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer_4 : PlayerController
{
    // Start is called before the first frame update
    public Rigidbody _rigidbodyA;
    private Animator animatorController;
    public float AnimationSpeed = 0;
    public bool ISjumpAnimation = false;
    public CPlayer_4()
    {

    }
    public override void Start()
    {
        base.Start();
        _rigidbodyA = GetComponent<Rigidbody>();
        animatorController = GetComponent<Animator>();
        animatorController.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
         //ControllerAnimation();
    }

    //public override void P4Controller()
    //{
    //    base.P4Controller();
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

    //Todo: Implementar Despues no es importante
}
