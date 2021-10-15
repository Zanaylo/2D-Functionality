using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]private CharacterStates controller; //Chamada do componente CharacterStates para movimentação do personagem
    
    private float horizontalMoviment = 0f; //Variaveis para aplicar física
    private bool jump = false;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private float jumpForce = 700f;

    private void Update()
    {
        
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed; //Resgatando os Inputs do Jogador
        if (Input.GetButtonDown("Jump"))
            jump = true;

    }


    //Fixed Update para a realização de calculos físicos precisos.
    private void FixedUpdate()
    {
        controller.UpdateAnimationState(horizontalMoviment * Time.fixedDeltaTime); // Controle de animação
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jumpForce, jump); //Adicionando Força para o Methodo Move, separando as funções e metodos das entradas do player.
        jump = false;
    }

    

}
