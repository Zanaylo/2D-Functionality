using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Chamada da class CharacterStates para movimenta��o do personagem
    public CharacterStates controller;
    float horizontalMoviment = 0f;
    bool jump = false;
    public float runSpeed = 40f;


    void Update()
    {
        //Resgatando a Dire��o e Adicionando for�a
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Resgatando caso o Bot�o "Space" seja apertado
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
     void FixedUpdate()
    {
        //Adicionando For�a para o Methodo Move, separando as fun��es e metodos das entradas do player.
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jump);
        jump = false;
    }


}
