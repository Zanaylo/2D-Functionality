using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]private CharacterStates controller;
    private int contFruit = 0; // Contador de Frutas
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Faz os objetos "Collectable" serem destruidas e adiciona ao contador.
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            contFruit++;
            Debug.Log("Frutas coletadas: " + contFruit);
            controller.GameWin(contFruit);
        }
    }

    

}
