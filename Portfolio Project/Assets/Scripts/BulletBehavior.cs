using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    Rigidbody rb;
    public GameObject explosion;
    public float speed;
    public Transform playerTransform;
    public AudioSource src;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        playerTransform = GameObject.Find("MainCamera").transform;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(speed*playerTransform.forward);
    }

    private void OnCollisionEnter(Collision other) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        src.PlayOneShot(clip);
        Destroy(this.gameObject);
    }
}
