using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using System;

public class PlayerController : MonoBehaviour, IChange {
	
	// Create public variables for player speed, and for the Text UI game objects
	[SerializeField] protected  float speed;
	protected Text countText;
	protected Text winText;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	protected Rigidbody rb;
	public int _PlayerCount=0;
	protected int count;
	protected int Control;
	protected Vector3 movement;
    [SerializeField] protected GameObject Attack_1_GameObject;
    [SerializeField] protected GameObject Attack_2_GameObject;

    [SerializeField] protected Transform Attack_Pos;

    [SerializeField] protected float _ForceJump;

	public Action OnAsignateController;
    // At the start of the game..
    public virtual void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		//SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		//winText.text = "";
	
	}
	
	// Each physics step..
	public virtual void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs

		Move();
		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
	
	}
	
	protected virtual void Move()
	{
		float moveHorizontal;
		float moveVertical;
		//bool Jump;
		/*
		switch (_PlayerCount)
		{
			case 1:
				moveHorizontal = Input.GetAxis("Horizontal");
				moveVertical = Input.GetAxis("Vertical");
				movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
				rb.AddForce(movement * speed);
				break;
			case 2:
				moveHorizontal= Input.GetAxis("HorizontalPlayer2");
				moveVertical=Input.GetAxis("VerticalPlayer2");
				movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
				rb.AddForce(movement * speed);
				break;
			default:
				Debug.LogError("El control no se asigno");
				break;
		}
			
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		*/
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Jump = Input.GetKeyDown('Jump');

        if(Input.GetButtonDown("Jump"))
        {
                  rb.AddForce(Vector3.up * _ForceJump,ForceMode.Impulse);
        }
      //  rb.AddForce(movement * speed);


    }

    protected virtual void EspecialHability()
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

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	/*
	public virtual void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}
	*/
	public virtual void AsignControll()
	{
		_PlayerCount += 1;
	}

    public void OnChange()
    {
       
    }
}