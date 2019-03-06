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

    public Transform firePoint;
    public GameObject projectile;

    public float shotDelay;
    private float shotDelayCounter;

    public float knockback;
    public float knockbackCount;
    public float knockbackLenght;
    public bool knockFromRight;

    private Animator anim;

    public bool godMode = false;

    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		playerTouchingGround = Physics2D.OverlapCircle (GroundCheckPoint.position, GroundCheckRadius, GroundLayer);

        if (knockbackCount <= 0)
        {
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
        else
        {
            if (knockFromRight)
            {
                myRigidbody.velocity = new Vector2(-knockback, knockback);
            }
            if (!knockFromRight)
            {
                myRigidbody.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }
        if (Input.GetKey(KeyCode.E)) {
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0) {
                shotDelayCounter = shotDelay;
                Instantiate(projectile, firePoint.position, firePoint.rotation);
            }
        }

        if (anim.GetBool("CollarOn"))
        {
            anim.SetBool("CollarOn", false);
        }

        if (Input.GetKey(KeyCode.R)) {
            anim.SetBool("CollarOn", true);
        }

        if (godMode) {
            spriteRenderer.color = Color.blue;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            godMode = true;
        }

        if (other.tag == "Enemy" && godMode) {
            Destroy(other.gameObject);
        }
    }
}