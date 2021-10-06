using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float MovementSpeed; //Quantidade de Força adicionada quando o Jogador andar
    
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Movement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    
}
