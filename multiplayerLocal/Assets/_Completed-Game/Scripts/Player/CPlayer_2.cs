using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer_2 : PlayerController
{
    public Rigidbody _rigidbodyA;
    private Animator animatorController;

    [Header("Test Attributes")]
    public float AnimationSpeed = 0;
    public bool ISjumpAnimation = false;
    public bool IsPunchAnimation = false;

    //TempDebug
    //public int [] ListAttackListEnum = {(int)Eplayer2Attacks.Punch_Up, (int)Eplayer2Attacks.Down_Punch, (int)Eplayer2Attacks.Kick_Single, (int)Eplayer2Attacks.Doble_Kick, (int)Eplayer2Attacks.Final_Smash };
    [Header("Test List")]
    //public List<List<CAttack>> ChainAttack;


    [SerializeField] public List<CAttack> _attackList;
    [SerializeField] public List<CAttack> _attackTempList= new List<CAttack>();

    [SerializeField] private List<CComboAttack> _comboList;
    [SerializeField] private List<CComboAttack> _comboTempList = new List<CComboAttack>();
    [SerializeField] private bool isTestAnimation = false;
    
    public CPlayer_2()
    {

    }
    // Start is called before the first frame update

  
    public override void Start()
    {
        base.Start();
        _rigidbodyA = GetComponent<Rigidbody>();
        animatorController = GetComponent<Animator>();
        //_comboInput.GetComponent<ComboInput>();
        animatorController.Play("Idle");
        //_comboInput.LoadComboResources();


    }

    // Update is called once per frame


    // Start is called before the first frame update

    // Start is called before the first frame update
    //public void Update()
    //{

    //   // ControllerAnimation();
    //}

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if(isTestAnimation == true)
        {
            ControllerAnimationTest();
        }
        else
        {
            ControllerAnimation();
        }
    }
    /*
    public override void SetCountText()
    {
        base.SetCountText();
    }
    */
    //public override void Move()
    //{
    //    base.Move();
    //    //rb.AddForce(movement * speed);
    //   // _rigidbodyA.constraints = RigidbodyConstraints.FreezeRotation;


    //    //Dar habilidades especiales
    //    //Pensar en que hacer 
    //}

    

    public override void EspecialHability()
    {
        base.EspecialHability();

    }
    public override void AsignControll()
    {
        base.AsignControll();

    }
    public override void P2Controller()
    {
        base.P2Controller();
        //_rigidbodyA.AddForce(movement * speed);
        _rigidbodyA.velocity = (movement * speed);
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

    //public void Atacar(GameObject enemigo)
    //{
    //    GetComponent<Animation>().Play(animacion.name);
    //}

    public void ControllerAnimationTest()
    {
        if (Input.GetKey(KeyCode.V))
        {
            AnimationSpeed = 1;
            animatorController.SetFloat("Speed", AnimationSpeed);
        }
        else
        {
            if (AnimationSpeed > 0)
            {
                AnimationSpeed -= 0.10f;
                animatorController.SetFloat("Speed", AnimationSpeed);
            }

            else if (AnimationSpeed <= 0)
            {
                AnimationSpeed = 0;
                animatorController.SetFloat("Speed", AnimationSpeed);
            }


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

        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           IsPunchAnimation = true;
           animatorController.SetBool("IsPunch", IsPunchAnimation);
           
        }

        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsPunchAnimation = false;
            animatorController.SetBool("IsPunch", IsPunchAnimation);
        }



    }



}



