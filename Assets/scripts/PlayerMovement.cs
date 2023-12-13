using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

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
    public GameObject dashParticleSystem;
    public AudioSource audioSource;
    public AudioClip door;
    public AudioClip shoot;
    public AudioClip dash;
    public AudioClip death;
    public bool deathPlayed = false;
    public Animator animator;
    public GameObject laser;
    public GameObject animations;
    void Start()
    {
        dashable = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        
        manager.playerDash = dashable;
        if (!manager.isPlayerDead)
        {
            animator.SetFloat("speed", Mathf.Abs(horizontalAxis + verticalAxis));
            animations.transform.position = transform.position;
            if (Input.GetButtonDown("Dash") && dashable == true)
            {
                dashVelocity = dashSpeed;
                audioSource.PlayOneShot(dash);
                StartCoroutine(dashCoolDown(1));
                Instantiate(dashParticleSystem, transform.position,laser.transform.rotation);
            }


            dashVelocity -= 60 * Time.deltaTime;
            if (dashVelocity < 0)
            {
                dashVelocity = 0;
            }
            if (Input.GetButtonDown("Shoot") && manager.gameStarted)
            {
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                audioSource.PlayOneShot(shoot,.50f);
                animator.SetTrigger("shoot");
            }

        }
        if (manager.isPlayerDead)
        {
            player.GetComponent<MeshRenderer>().enabled = false;
            if (!deathPlayed)
            {
                audioSource.PlayOneShot(death, 1.5f);
                deathPlayed = true;
                Destroy(animations.gameObject);
            }
            
        }
    }
    private void FixedUpdate()
    {
        if (!manager.isPlayerDead)
        {
            if (manager.gameStarted)
            {
                rotate = Input.GetAxis("rotate");
                horizontalAxis = Input.GetAxis("Horizontal");
                verticalAxis = Input.GetAxis("Vertical");
                rb.AddForce(Vector3.forward * moveSpeed * verticalAxis);
                rb.AddForce(Vector3.right * moveSpeed * horizontalAxis);
                transform.Rotate(Vector3.up * rotateSpeed * rotate * Time.deltaTime);
                rb.AddForce(laser.transform.forward * dashVelocity, ForceMode.Impulse);
            }
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
                audioSource.PlayOneShot(door);
            }
        }
    }
}
