using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]private CharacterStates controller; //Chamada do componente CharacterStates para movimenta��o do personagem
    
    private float horizontalMoviment = 0f; //Variaveis para aplicar f�sica
    private bool jump = false;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private float jumpForce = 700f;

    private void Update()
    {
        
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed; //Resgatando os Inputs do Jogador
        if (Input.GetButtonDown("Jump"))
            jump = true;

    }


    //Fixed Update para a realiza��o de calculos f�sicos precisos.
    private void FixedUpdate()
    {
        controller.UpdateAnimationState(horizontalMoviment * Time.fixedDeltaTime); // Controle de anima��o
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jumpForce, jump); //Adicionando For�a para o Methodo Move, separando as fun��es e metodos das entradas do player.
        jump = false;
    }

    

}
