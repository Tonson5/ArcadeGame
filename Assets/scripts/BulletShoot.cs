using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public Rigidbody rb;
    public float shootingForce;
    public GameManager manager;
    public GameObject enemyDeath;
    public GameObject sparks;
    public AudioSource audioSource;
    public AudioClip death;
    public AudioClip hit;
    public AudioClip casing;
    void Start()
    {
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * shootingForce, ForceMode.Impulse);
        Destroy(gameObject ,5.0f);
        manager = GameObject.Find("game manager").GetComponent<GameManager>();
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSource.PlayOneShot(casing);
    }
    private void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            manager.score += 1;
            manager.enemies -= 1;
            Instantiate(enemyDeath, transform.position, transform.rotation);
            audioSource.PlayOneShot(death);
        }
        else
        {
            audioSource.PlayOneShot(hit);
            Destroy(gameObject);
        }
    }
}
