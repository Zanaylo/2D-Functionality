using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public CharacterStates states;
    public float bounceForce = 15f;
    public Animator anm;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            states.Bounce(bounceForce);
            anm.SetTrigger("Death");
        }
    }
    public void DieEnemy()
    {
        Destroy(transform.gameObject);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
