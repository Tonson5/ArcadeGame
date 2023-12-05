using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public Rigidbody rb;
    public float shootingForce;
    public GameManager manager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * shootingForce, ForceMode.Impulse);
        Destroy(gameObject ,5.0f);
        manager = GameObject.Find("game manager").GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            manager.score += 1;
            manager.enemies -= 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
