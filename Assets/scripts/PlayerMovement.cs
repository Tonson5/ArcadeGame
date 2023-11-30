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
    void Start()
    {
        dashable = true;
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


            rotate = Input.GetAxis("rotate");
            horizontalAxis = Input.GetAxis("Horizontal");
            verticalAxis = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * moveSpeed * verticalAxis * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * horizontalAxis * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateSpeed * rotate * Time.deltaTime);
            transform.Translate(Vector3.forward * dashVelocity * Time.deltaTime);
            if (Input.GetButtonDown("Shoot"))
            {
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
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
}
