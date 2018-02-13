using UnityEngine;
using System.Collections;

public class PlatformerCharacter2D : MonoBehaviour 
{
	public bool facingRight = true;						// For determining which way the player is currently facing.
	private float gravity = 20.0f;
	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 400.0f;						// Amount of force added when the player jumps.	
	Vector3 bombSpawn;
	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
	public bool airControl = false;						// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	public bool grounded = false;								// Whether or not the player is grounded.
	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	public Animator anim;										// Reference to the player's animator component.
	Transform playerGraphics;							// Reference the player's graphics
	public bool isAlive = true;							// Bool for to check if the player is alive. Used to trigger death animation
	public Transform bombPrefab;						//bomb
	public Transform burgerPrefab;						//burger
	public int equipped;								//id of item equipped
	public bool hasJetPack = false;						// Checks for a jetpack
	public bool hasBomb = false;						// Checks for a bomb
	public bool hasGun = false;							// Checks for a gun
	public float speed;									// Player's movement speed
	bool gunEquipped = false;
	public bool hasBurger = false;						//check for burger
	public bool hasTM = false;							//check for time machine
	
	Vector3 movement;

	private Vector3 moveDirection = Vector3.zero;

	
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();		
	}

	private IEnumerator WaitXTime() {
		gunEquipped = true;
		anim.SetBool("gunEquipped", gunEquipped);
		yield return new WaitForSeconds (0.5f);
		gunEquipped = false;
		anim.SetBool("gunEquipped", gunEquipped);
	}
	
	
	void Update()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

		anim.SetBool("Ground", grounded);

		// Set the vertical animation
		anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		
		anim.SetBool("hasJetPack", hasJetPack);
		
		anim.SetBool("isAlive", isAlive);

		if (!isAlive) {

			Destroy(gameObject, 3.0f);

		}

		if (equipped == 1) {
			
			GetComponent<Rigidbody2D>().gravityScale = 1;
			moveDirection.y -= gravity * Time.deltaTime;
			airControl = true;
			hasJetPack = true;
			jumpForce = 800;
		}

		if (equipped != 1) {
			hasJetPack = false;
			airControl = false;

		}

		if (equipped == 2 && Input.GetButtonDown ("Fire1")) {
			bombDrop();
		}

		if (equipped == 5 && grounded && speed == 0 && Input.GetButtonDown ("Fire1")) {
			StartCoroutine(WaitXTime());
		}

		if(equipped == 3 && Input.GetButtonDown ("Fire1")){
			burgerDrop();
		}

		if (equipped != 5)
			gunEquipped = false;

		if (equipped == 4 && Input.GetButtonDown ("Fire1"))
						Application.LoadLevel ("scene9");
	}
	
	public void Move(float move, bool crouch, bool jump)
	{
		
		
		// If crouching, check to see if the character can stand up
		if(!crouch && anim.GetBool("Crouch"))
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if( Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
				crouch = true;
		}
		
		// Set whether or not the character is crouching in the animator
		anim.SetBool("Crouch", crouch);
		
		//only control the player if grounded or airControl is turned on
		if(grounded || airControl)
		{
			// Reduce the speed if crouching by the crouchSpeed multiplier
			move = (crouch ? move * crouchSpeed : move);
			speed = Mathf.Abs(move);
			
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", speed);
			
			// Move the character
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if(move > 0 && !facingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(move < 0 && facingRight)
				// ... flip the player.
				Flip();
		}
		
		// If the player should jump...
		if (grounded && jump) {
			// Add a vertical force to the player.
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void bombDrop(){
		if(facingRight)
			bombSpawn = new Vector3 (transform.position.x + 1.5f, transform.position.y, transform.position.z);
		if(!facingRight)
			bombSpawn = new Vector3 (transform.position.x - 1.5f, transform.position.y, transform.position.z);
		Transform bombClone  = (Transform) Instantiate (bombPrefab, bombSpawn, transform.rotation);
		bombClone.GetComponent<bomb>().armed = true;
		if(hasBomb)
			Destroy(bombClone.gameObject, 2.2f);
		if (hasBomb == false)
			Destroy (bombClone.gameObject);
	}

	void burgerDrop(){
		if(facingRight)
			bombSpawn = new Vector3 (transform.position.x + 1.5f, transform.position.y, transform.position.z);
		if(!facingRight)
			bombSpawn = new Vector3 (transform.position.x - 1.5f, transform.position.y, transform.position.z);
		Transform burgerClone = (Transform)Instantiate (burgerPrefab, bombSpawn, transform.rotation);
		Destroy (burgerClone.gameObject, 2.0f);
	}
}
