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

    public bool digging;

    public float damage;

    private int dirtStash;

    public GameObject objecto;

    // Use this for initialization
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        playerTouchingGround = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, GroundLayer);

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

        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
                Debug.Log(hit.transform.name);
                if (hit.collider != null && hit.transform.tag == "Ground")
                {
                    DestroyTerrain target = hit.transform.GetComponent<DestroyTerrain>();
                    if (target != null)
                    {
                        target.TakeDamage(damage);
                        dirtStash += 1;
                    }
                }

            }
        }

        if (dirtStash > 0 && Input.GetKey(KeyCode.R)) {
            if (Input.GetMouseButtonDown(1)) {
                Instantiate(objecto, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Quaternion.identity);
                dirtStash -= 1;
            }
        }

    }

}
    

