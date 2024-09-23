using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour  {
	
	// Create public variables for player speed, and for the Text UI game objects
	[SerializeField] protected  float speed;
	

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	protected Rigidbody rb;
	public int _PlayerCount=0;
	protected int count;
	protected int Control;
    //protected Text countText;
   // protected Text winText;
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
		Vector3 movement;
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
		rb.AddForce(movement * speed);


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
		//	count = count + 1;

			// Run the 'SetCountText()' function (see below)
			//SetCountText ();
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	
	
	
	public virtual void AsignControll()
	{
		_PlayerCount += 1;
	}

	
}