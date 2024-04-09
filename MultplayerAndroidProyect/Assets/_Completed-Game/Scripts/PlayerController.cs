using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour, IChange, IAttack {
    [Header("Movement")]
    // Create public variables for player speed, and for the Text UI game objects
    [SerializeField] protected  float speed;
    [SerializeField] protected float _rotationspeed;
    protected Text countText;
	protected Text winText;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	protected Rigidbody rb;
    public int _PlayerCount = 0;
    protected int count;
	protected int Control;
	protected Vector3 movement;
    [SerializeField] protected GameObject Attack_1_GameObject;
    [SerializeField] protected GameObject Attack_2_GameObject;
    [SerializeField] protected GameObject Attack_GameObject;
    [SerializeField] protected Transform Attack_Pos;

    [SerializeField] protected float _ForceJump;
	
    protected Vector2 moveVector; 
	
    public Action OnAsignateController;
	// At the start of the game..
	private InputAction _MoveAction;
	private InputAction _JumpAction;
	private InputAction _Attack_1Action;
	private InputAction _Attack_2Action;
	private InputAction _ChangeForms_Action;
	private CInputSystemMultiplayer _defaultPlayerAction;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float _currentVelocity;
    
    private Vector3 _direction;
    public object MoveVector { get; private set; }
    public Vector3 movementDirection;
    
    [Header("Combo System")]
    
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private Vector3 _Box;
    [SerializeField] private float DamagePunch;

    public ComboInput _comboInput;
    

    private void Awake()
    {
        _defaultPlayerAction = new CInputSystemMultiplayer();
    }
    public virtual void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

        _Box = new Vector3(1, 1, 1);

		// Run the SetCountText function to update the UI (see below)
		//SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		//winText.text = "";
	
	}

    public virtual void SetPlayerController(int PlayerCount)
    {
        _PlayerCount = PlayerCount;
    }
	
	// Each physics step..
	public virtual void FixedUpdate ()
	{
        // Set some local float variables equal to the value of our Horizontal and Vertical Inputs
        if(_PlayerCount == 0)
        {
            MoveVector = _MoveAction.ReadValue<Vector2>();
          //  Debug.Log($"move: {MoveVector}");
        }

        Move();
     


	
        

    }
    public virtual void P1Controller()
    {



        //moveVector = _MoveAction.ReadValue<Vector2>();
        //movement = new Vector3(moveVector.x, 0.0f, moveVector.y);
        //var movementDirection = new Vector3(movement.x, 0.0f, movement.y);
        //movementDirection.Normalize();
        //movement.Normalize();
        //moveVector = _MoveAction.ReadValue<Vector2>();
        //movement = new Vector3(moveVector.x, 0.0f, moveVector.y);
        //var movementDirection = new Vector3(moveVector.x, 0.0f, moveVector.y);
        //movementDirection.Normalize();
        //// Debug.Log("Player 2 Controller");

        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationspeed /** 2 *Time.deltaTime*/);
        //}
    }
    public virtual void Move()
	{
        //float moveHorizontal;
        //float moveVertical;
        //bool Jump;
        
		switch (_PlayerCount)
		{
			case 0:
				// Debug.Log("Player 1");
                moveVector = _MoveAction.ReadValue<Vector2>();
                movement = new Vector3(moveVector.x, 0.0f, moveVector.y);
                var movementDirection = new Vector3(moveVector.x, 0.0f, moveVector.y);
                movementDirection.Normalize();

                if (movementDirection != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationspeed /** 2 *Time.deltaTime*/);
                }
                //Vector3 movementDirection = new Vector3(movement.x, 0, movement.y);
                //transform.Translate(movement * speed * Time.deltaTime, Space.World);

                //if (movementDirection != Vector3.zero)
                //{


                // Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); ;
                //  transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, speed);

                //}
                //Vector3 movementDirection = new Vector3(movement.x, 0, movement.y);
                //movementDirection.Normalize();

                //if (movementDirection != Vector3.zero)
                //{
                //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 20 * Time.deltaTime);
                //}
                break;

            case 1:
              
                P2Controller();
                //_MoveAction = _defaultPlayerAction.Player.Move;
                //_MoveAction.Enable();

                //_JumpAction = _defaultPlayerAction.Player.Jump;
                //_JumpAction.Enable();

                //_ChangeForms_Action = _defaultPlayerAction.Player.ChangeForm;
                //_ChangeForms_Action.Enable();

                //_Attack_1Action = _defaultPlayerAction.Player.Attack1;
                //_Attack_1Action.Enable();

                //_Attack_2Action = _defaultPlayerAction.Player.Attack2;
                //_Attack_2Action.Enable();


                //_defaultPlayerAction.Player.Jump.performed += OnJump;
                //_defaultPlayerAction.Player.Move.performed += OnMove;
                //_defaultPlayerAction.Player.ChangeForm.performed += OnChangeForm;
                break;
            case 2:
               // Debug.Log("Player 3");
                P3Controller();
                //moveHorizontal= Input.GetAxis("HorizontalPlayer2");
                //moveVertical=Input.GetAxis("VerticalPlayer2");
                //movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                //rb.AddForce(movement * speed);
                break;

            case 3:
                P4Controller();
               // Debug.Log("Player 4");


                break;
            default:
				Debug.LogError("El control no se asigno");
				break;
		}



        //      float moveHorizontal;
        //      float moveVertical;


        //      moveHorizontal = Input.GetAxis("Horizontal");
        //moveVertical = Input.GetAxis("Vertical");
        //movement = new Vector3(moveVector.x, 0.0f, moveVector.y);
      

		//Jump = Input.GetKeyDown('Jump');

		//if (Input.GetButtonDown("Jump"))
  //      {
  //                rb.AddForce(Vector3.up * _ForceJump,ForceMode.Impulse);
  //      }
      //  rb.AddForce(movement * speed);


    }

    public virtual void EspecialHability()
	{
		KeyCode Attack_1 = KeyCode.Mouse0;
		KeyCode Attack_2 = KeyCode.Mouse1;

		if (Input.GetKeyDown(Attack_1))
		{
		CBulletManager.Inst.SpawnAttack_1( Attack_Pos.position, Attack_1_GameObject);
        }

		else if(Input.GetKeyDown(Attack_2))
		{
            CBulletManager.Inst.SpawnAttack_2(Attack_Pos.position, Attack_2_GameObject);
        }
       


    }
	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void  OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			//SetCountText ();
		}
	}

	public virtual void AsignControll()
	{
		_PlayerCount += 1;
	}
   
    private void OnEnable()
    {
        //Pulir
        switch (_PlayerCount)
        {
            case 0:
                //Debug.Log("Player 1");

                _MoveAction = _defaultPlayerAction.Player.Move;
                _MoveAction.Enable();

                //_JumpAction = _defaultPlayerAction.Player.Jump;
                //_JumpAction.Enable();

                //_ChangeForms_Action = _defaultPlayerAction.Player.ChangeForm;
                //_ChangeForms_Action.Enable();

                //_Attack_1Action = _defaultPlayerAction.Player.Attack1;
                //_Attack_1Action.Enable();

                //_Attack_2Action = _defaultPlayerAction.Player.Attack2;
                //_Attack_2Action.Enable();


                //_defaultPlayerAction.Player.Jump.performed += OnJump;
                //_defaultPlayerAction.Player.Move.performed += OnMove;
                //_defaultPlayerAction.Player.ChangeForm.performed += OnChangeForm;
                break;

            case 1:
              //  Debug.Log("Player 2");
                P2Controller();
                //_MoveAction = _defaultPlayerAction.Player.Move;
                //_MoveAction.Enable();

                //_JumpAction = _defaultPlayerAction.Player.Jump;
                //_JumpAction.Enable();

                //_ChangeForms_Action = _defaultPlayerAction.Player.ChangeForm;
                //_ChangeForms_Action.Enable();

                //_Attack_1Action = _defaultPlayerAction.Player.Attack1;
                //_Attack_1Action.Enable();

                //_Attack_2Action = _defaultPlayerAction.Player.Attack2;
                //_Attack_2Action.Enable();


                //_defaultPlayerAction.Player.Jump.performed += OnJump;
                //_defaultPlayerAction.Player.Move.performed += OnMove;
                //_defaultPlayerAction.Player.ChangeForm.performed += OnChangeForm;
                break;
            case 2:
              //  Debug.Log("Player 3");
                P3Controller();
                //moveHorizontal= Input.GetAxis("HorizontalPlayer2");
                //moveVertical=Input.GetAxis("VerticalPlayer2");
                //movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                //rb.AddForce(movement * speed);
                break;

            case 3:
                P4Controller();
              //  Debug.Log("Player 4");


                break;
            default:
             //   Debug.LogError("El control no se asigno");
                break;
        }


        //_defaultPlayerAction.Player.Attack1.performed += OnAttack1;
        //_defaultPlayerAction.Player.Attack2.performed += OnAttack2;

    }

    private void OnDisable()
    {
        if(_PlayerCount == 0)
        {

        
            _MoveAction.Disable();
            //_JumpAction.Disable();
            //_ChangeForms_Action.Disable();
            //_Attack_1Action.Disable();
            //_Attack_2Action.Disable();
        }
        //_defaultPlayerAction.Player.Horizontal.Disable();
        //_defaultPlayerAction.Player.Vertical.Disable();
        //_defaultPlayerAction.Player.Jump.Disable();
        //_defaultPlayerAction.Player.ChangeForm.Disable();
        //_defaultPlayerAction.Player.Attack1.Disable();
        //_defaultPlayerAction.Player.Attack2.Disable();
    }
   
	
    public virtual void P2Controller()
    {

        float moveHorizontal;
        float moveVertical;

       // Debug.Log("Player 2 Controller");
        moveHorizontal = Input.GetAxisRaw("HorizontalP2");
      //  Debug.Log("Horizontal: "+ moveHorizontal);
        moveVertical = Input.GetAxis("VerticalP2");
       // Debug.Log("Horizontal: " + moveHorizontal);
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement.Normalize();
        var movementDirection = new Vector3(movement.x, 0.0f, movement.z);
        movementDirection.Normalize();

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationspeed /** 2 *Time.deltaTime*/);
        }

        //if(Input.GetButtonDown("P2SoftPunch"))
        //{
        //    //Debug.Log("Entra en Soft Punch");
        //     Attack_GameObject.SetActive(true);
        //    //Debug.Log(Attack_GameObject.activeSelf);
        //    Golpe();
        //}
       
        //else if (Input.GetButtonDown("P2HardPunch"))
        //{
        //    // Debug.Log("Entra en Hard Punch");
        //    Attack_GameObject.SetActive(true);
        //    Golpe();
        //}
        
        //else
        //{
        //    //Attack_GameObject.SetActive(false);
        //    Invoke("DesactiveHit", 5f);
        //}
      
        ////else if (Input.GetButtonUp("P2HardPunch"))
        ////{
        ////    // Debug.Log("Entra en Hard Punch");
        ////    Attack_GameObject.SetActive(false);
        ////}

    }
    public void DesactiveHit()
    {
        if (Attack_GameObject.activeSelf==true)
        { 
            Attack_GameObject.SetActive(false);
        }
    }

    public virtual void P3Controller()
    {

        float moveHorizontal;
        float moveVertical;

        moveHorizontal = Input.GetAxis("HorizontalP3");
        moveVertical = Input.GetAxis("VerticalP3");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       

    }
    public virtual void P4Controller()
    {

        float moveHorizontal;
        float moveVertical;


        moveHorizontal = Input.GetAxis("HorizontalP4");
        moveVertical = Input.GetAxis("VerticalP4");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
      
    }

    public int GePlayerCount()
    {
        return _PlayerCount;
    }

    private void OnJump(InputAction.CallbackContext context)
	{
		Debug.Log("Jump");
	}

	private void OnMove(InputAction.CallbackContext context)
	{


       Vector2 MoveVector_P = _MoveAction.ReadValue<Vector2>();
       // Debug.Log($"move: {MoveVector_P}");
    }
    private void OnChangeForm(InputAction.CallbackContext context)
    {
		//Debug.Log("ChangeForm");
        bool changeForm;
		changeForm = _ChangeForms_Action.ReadValue<bool>();
    }
  //  private void OnAttack1(InputAction.CallbackContext context)
  //  {
		//Debug.Log("Attack1");
  //      bool Attack1;
  //      Attack1 = _Attack_1Action.ReadValue<bool>();
  //  }
  //  private void OnAttack2(InputAction.CallbackContext context)
  //  {
		//Debug.Log("Attack2");
  //      bool Attack2;
  //      Attack2 = _Attack_2Action.ReadValue<bool>();
  //  }

    public virtual void AndroidControllerTest()
    {
      
       
    }

    public virtual void OnChange()
    {
       
    }

    public virtual void Golpe() 
    {
        Collider[] objetos = Physics.OverlapBox(controladorGolpe.position, _Box, controladorGolpe.rotation);
        
        foreach(Collider collisionador in objetos)
        {
            if(collisionador.CompareTag("Player") && collisionador.gameObject != gameObject)
            {
                collisionador.transform.GetComponent<CTestEnemy>().TakeDamage(DamagePunch);
            }
        }
    }
    public void OnAttack()
    {
        throw new NotImplementedException();
    }
}