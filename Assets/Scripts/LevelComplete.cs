using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    
    [SerializeField]private CharacterStates controller; // Chamada do Componente

    private void Start()
    {
        controller.GetComponent<CharacterStates>(); // resgatando o componente
    }

    private void ResetLevel()
    {
        controller.Resetlevel(); //Metodo para Leitura de Termino de Cena
    }
}
