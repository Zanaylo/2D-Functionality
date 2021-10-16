using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]private CharacterStates controller; //Chamada do componente CharacterStates para movimentação do personagem
    [SerializeField]private VerticalPlataform plataform;
    private float horizontalMoviment = 0f; //Variaveis para aplicar física
    private bool jump = false; //Verifica se o jogador pulou
    [SerializeField] private float runSpeed = 40f; //Quantidade de força aplicada na corrida
    [SerializeField] private float jumpForce = 700f;// Quantidade de forla aplicada no pulo



    private void Update()
    {
        
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed; //Resgatando os Inputs do Jogador
        if (Input.GetButtonDown("Jump"))
        {
            jump = true; // retorna para o methodo Move Verdadeiro
        }

        if (Input.GetButtonDown("Vertical"))
        {
            plataform.PlataformOneWay(); // Chama a Função de plataforma
            jump = false;
        }
        
    }

   

    //Fixed Update para a realização de calculos físicos precisos.
    private void FixedUpdate()
    {
        controller.UpdateAnimationState(horizontalMoviment * Time.fixedDeltaTime); // Controle de animação
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jumpForce, jump); //Adicionando Força para o Methodo Move, separando as funções e metodos das entradas do player.
        jump = false;
    }

    

}
