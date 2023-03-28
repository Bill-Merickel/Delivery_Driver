using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void Update()
    {
        // Utilize Time.deltaTime so that driver moves the same speed across all computers regardless of framerate
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Boost the driver speed if it runs over a boost trigger
        if (other.tag == "Boost")
        {
            Debug.Log("Boost!");
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Slow down the driver if it collides with an obstacle
        if (other.gameObject.tag == "Bump")
        {
            Debug.Log("Bump!");
            moveSpeed = slowSpeed;
        }
    }
}
