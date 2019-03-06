using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	private Rigidbody2D myRigidbody;

	public Transform GroundCheckPoint;
	public float GroundCheckRadius;
	public LayerMask GroundLayer;
	public bool playerTouchingGround;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		playerTouchingGround = Physics2D.OverlapCircle (GroundCheckPoint.position, GroundCheckRadius, GroundLayer);

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
                transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1f, 1f);
            }
            else
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Jump") > 0.5f && playerTouchingGround == true)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Jump") * jumpSpeed);

            }
            if (!playerTouchingGround && moveSpeed < 30f)
            {
                moveSpeed += 0.05f;
            }
            else if (!playerTouchingGround && moveSpeed >= 30f)
            {
                moveSpeed = 30f;
            }
            else
            {
                moveSpeed = 5f;
            }

        }




    }

