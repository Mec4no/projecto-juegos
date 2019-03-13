using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    public float projectileSpeedX;
    public float projectileSpeedY;
    private Rigidbody2D myRigidbody;
    private PlayerTwoController player;
    public float rotationSpeed;
    public int damageToGive;
    public float lifeTime;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerTwoController>();
        if (player.transform.localScale.x < 0f)
        {
            projectileSpeedX = -projectileSpeedX;
            rotationSpeed = -rotationSpeed;
        }
        myRigidbody.velocity = new Vector2(projectileSpeedX, projectileSpeedY);
        myRigidbody.angularVelocity = rotationSpeed;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
