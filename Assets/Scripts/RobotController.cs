using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {
	//This will be the maximum speed
	public float maxSpeed = 2f;
	//a boolean value to represent whether the character is facing left or not
	bool facingLeft = true;
	//a value to represent the Animator
	Animator anim;
	//to check ground and to have a jumpforce that can be changed in the editor
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	
	// Use this for initialization
	void Start () {
		//set anim to animator
		anim = GetComponent <Animator>();
		
	}
	
	
	void FixedUpdate () {
		//set vSpeed
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		//set grounded bool
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//set ground in Animator to match grounded
		anim.SetBool ("Ground", grounded);
		
		
		float move = Input.GetAxis ("Horizontal");//Gives us of one if we are moving via the arrow keys
		//move Player's rigidbody
		rigidbody2D.velocity = new Vector3 (move * maxSpeed, rigidbody2D.velocity.y);	
		//set speed
		anim.SetFloat ("Speed",Mathf.Abs (move));
		//if the player is moving left but not facing left flip, and vice versa
		if (move < 0 && !facingLeft) {
			
			Flip ();
		} else if (move > 0 && facingLeft) {
			Flip ();
		}
	}
	
	void Update(){
		//if the player is on the ground and the space bar was pressed, change the ground state and add an upward force
		if(grounded && Input.GetKeyDown (KeyCode.Space)){
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce (new Vector2(0,jumpForce));
		}
		
		
	}
	
	//flip if needed
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}