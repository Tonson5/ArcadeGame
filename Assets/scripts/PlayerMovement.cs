using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed = 50;
    public float rotateSpeed;
    private float horizontalAxis;
    private float verticalAxis;
    public float rotate;
    public float dashVelocity;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject player;
    public bool dashable = true;
    public GameManager manager;
    public Rigidbody rb;
    public GameObject spawn;
    void Start()
    {
        dashable = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!manager.isPlayerDead)
        {

            if (Input.GetButtonDown("Dash") && dashable == true)
            {
                dashVelocity = dashSpeed;
                StartCoroutine(dashCoolDown(1));
            }


            dashVelocity -= 60 * Time.deltaTime;
            if (dashVelocity < 0)
            {
                dashVelocity = 0;
            }

            if (manager.gameStarted)
            {
                rotate = Input.GetAxis("rotate");
                horizontalAxis = Input.GetAxis("Horizontal");
                verticalAxis = Input.GetAxis("Vertical");
                rb.AddForce(Vector3.forward * moveSpeed * verticalAxis);
                rb.AddForce(Vector3.right * moveSpeed * horizontalAxis);
                transform.Rotate(Vector3.up * rotateSpeed * rotate * Time.deltaTime);
                rb.AddRelativeForce(Vector3.forward * dashVelocity, ForceMode.Impulse);
                if (Input.GetButtonDown("Shoot"))
                {
                    Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                }
            }
        }
        if (manager.isPlayerDead)
        {
            player.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    IEnumerator dashCoolDown(int time)
    {
        dashable = false;
        yield return new WaitForSeconds(time);
        dashable = true;
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("door"))
        {
            Debug.Log("touched door");
            if (manager.enemies == 0)
            {
                manager.NewRoom();
                transform.position = spawn.transform.position;
            }
        }
    }
}
