using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed = 50;
    public float rotateSpeed;
    public float horizontalAxis;
    public float verticalAxis;
    public float rotate;
    public float dashVelocity;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashVelocity = dashSpeed;
        }
        dashVelocity -= 60 * Time.deltaTime;
        if (dashVelocity < 0)
        {
            dashVelocity = 0;
        }
        rotate = Input.GetAxis("rotate");
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * verticalAxis * Time.deltaTime);
        transform.Translate(Vector3.right * moveSpeed * horizontalAxis * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * rotate * Time.deltaTime);
        transform.Translate(Vector3.forward * dashVelocity * Time.deltaTime);
    }
}
