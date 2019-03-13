using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float moveSpeed;
    public float remindSpeed;
    public float jumpSpeed;
    private Rigidbody2D myRigidbody;

    public Transform GroundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    public bool playerTouchingGround;

    public bool digging;

    public float damage;

    public static int dirtStash;

    public GameObject objecto;

    public GameObject projectil;
    public Transform firePoint;

    public float shotDelay;
    private float shotDelayCounter;

    // Use this for initialization
    void Start()
    {
        remindSpeed = moveSpeed;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log(myRigidbody.velocity);

        playerTouchingGround = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, GroundLayer);

        if (Input.GetAxisRaw("Horizontal_p2") > 0.5f)
        {
            Debug.Log("p2 horizontal press");
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal_p2") * moveSpeed, myRigidbody.velocity.y);
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal_p2") - 0.567924f, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetAxisRaw("Horizontal_p2") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal_p2") * moveSpeed, myRigidbody.velocity.y);
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal_p2") + 0.567924f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Jump_p2") > 0.5f && playerTouchingGround == true)
            //  jump
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Jump_p2") * jumpSpeed);

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
            moveSpeed = remindSpeed;
        }

        if (Input.GetKey(KeyCode.P))
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

        if (dirtStash > 0 && Input.GetKey(KeyCode.R))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(objecto, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Quaternion.identity);
                dirtStash -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(projectil, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }
        if (Input.GetKey(KeyCode.B))
        {
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(projectil, firePoint.position, firePoint.rotation);
            }
        }

    }
}
