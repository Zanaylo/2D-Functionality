using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrip : MonoBehaviour
{
    public PlayerLife life;
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            Destroy(gameObject);
            life.PlayerDie();
        }
            
    }
}
