using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaController1 : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    public float moveSpeed;
    public PlayerController player;
    public float damage;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("HorPala1") > 0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("HorPala1") * moveSpeed, myRigidbody.velocity.y);
            
        }
        else if (Input.GetAxisRaw("HorPala1") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("HorPala1") * moveSpeed, myRigidbody.velocity.y);

        }
        else if (Input.GetAxisRaw("VerPala1") > 0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("VerPala1") * moveSpeed);
        }
        else if (Input.GetAxisRaw("VerPala1") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("VerPala1") * moveSpeed);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0f, 0f);
        }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(transform.position).x, Camera.main.ScreenToWorldPoint(transform.position).y), Vector2.zero, 0f);
                Debug.Log(hit.transform.name);
                if (hit.collider != null && hit.transform.tag == "Ground")
                {
                    DestroyTerrain target = hit.transform.GetComponent<DestroyTerrain>();
                    if (target != null)
                    {
                         target.TakeDamage(damage);
                }
                }

            }
        
    }
}
