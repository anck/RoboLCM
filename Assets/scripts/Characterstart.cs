using UnityEngine;
using System.Collections;

public class Characterstart : MonoBehaviour
{

	public bool _run = false;				// Condition for whether the player should jump.	
	//public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	public bool gamestarted = false;


	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	//the moment our character hits the ground we set the grounded to true 
	void OnCollisionEnter2D(Collision2D hit)
	{
		grounded = true;
	}

	//the game start but we set the value of gamestarted to false to set our character s
	void Start()
	{
		gamestarted = false;
	}

	void Update()
	{

			if(Input.GetButtonDown("Fire1"))
			{		

				// If the run button is pressed and the player is grounded and the character is running forward then the player should jump.
		     	if((gamestarted == true))						
				{
					anim.SetBool("run",true);
					_run = true;
				}
			    // if the game is set now to start the character will start to run forward in the FixedUpdate
				else
				{
					gamestarted = true;
				}
				
			}
			else if(Input.GetButtonUp("Fire1"))
			{		
			
				// If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
				if((gamestarted == true))						
				{
					anim.SetBool("run",false);
					_run = false;
					//grounded = false;
				}
				// if the game is set now to start the character will start to run forward in the FixedUpdate
				else
				{
					gamestarted = true;
				}
				
		}
	}


	//everything in the physics we set in the fixupdate 
	void FixedUpdate ()
	{
		// if game is started we move character forward...
		if (_run == true) 
		{
			//anim.SetFloat("run", 11f);
			rigidbody2D.velocity = new Vector2( 10 , rigidbody2D.velocity.y  );
		}
		else if(_run == false)
		{
			rigidbody2D.velocity = new Vector2( 0 , rigidbody2D.velocity.y  );
		}


		// If jump is set to true we are now adding quickly aforce to push the character up
		/**if(run == true)
		{
		
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(1f, jumpForce));

			// We set to false otherwise the ridig2D addforce would keep adding force
			run = false;


		}*/

	}
	
}
