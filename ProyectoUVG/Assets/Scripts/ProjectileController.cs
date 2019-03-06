using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float projectileSpeed;
    private Rigidbody2D myRigidbody;
    private PlayerController player;
    public GameObject enemyDeathEffect;
    public float rotationSpeed;
    public int damageToGive;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        if (player.transform.localScale.x < 0f)
        {
            projectileSpeed = -projectileSpeed;
            rotationSpeed = -rotationSpeed;
        }

    }
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(projectileSpeed, myRigidbody.velocity.y);
        myRigidbody.angularVelocity = rotationSpeed;

	}

    void Awake() {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
        }
        else if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
