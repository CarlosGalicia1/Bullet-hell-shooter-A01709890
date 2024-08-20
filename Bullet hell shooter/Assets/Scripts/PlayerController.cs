using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 40.0f;
    public float zRange = 40.0f;
    public float topBound = 12f;
    public float lowerBound = -33f;
    public float slowSpeed = 10f;
    public GameObject projectilePrefab;
    public float fireRate = 0.1f;
    private float nextFireTime = 0f; // Tiempo para el siguiente disparo


    // Update is called once per frame
    void Update()
    {
        // Constraint player's z movement
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        // Constraint player's x movement
        if (transform.position.x < lowerBound)
        {
            transform.position = new Vector3(lowerBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x> topBound)
        {
            transform.position = new Vector3(topBound, transform.position.y, transform.position.z);
        }

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? slowSpeed : speed;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * currentSpeed);
        transform.Translate(Vector3.left * verticalInput * Time.deltaTime * currentSpeed);

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            //Launch projectile from the player
            Instantiate(projectilePrefab, transform.position + new Vector3(-2.5f,1f,0f), projectilePrefab.transform.rotation);
            BulletCounter bulletCounter = FindObjectOfType<BulletCounter>();
            bulletCounter.IncrementBulletCount();
        }
    }
}
