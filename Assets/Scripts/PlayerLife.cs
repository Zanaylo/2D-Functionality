using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    
    [SerializeField]private CharacterStates controller; // Resgate de componente

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Quando colidir com Atackes de inimigos chame a methodo DIE
        if (collision.gameObject.CompareTag("EnemyAttack"))
        {
            controller.Die();
        }

    }

    public void PlayerDie()
    {
        controller.Die();
    }
}
