using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private int contFruit = 0; // Contador de Frutas

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Fazer as serem destruidas e adicionar ao contador.
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            contFruit++;
            Debug.Log("Frutas coletadas: " + contFruit);
        }
    }

}