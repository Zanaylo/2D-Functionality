using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Chamada da class CharacterStates para movimentação do personagem
    public CharacterStates controller;
    float horizontalMoviment = 0f;
    bool jump = false;
    public float runSpeed = 40f;


    void Update()
    {
        //Resgatando a Direção e Adicionando força
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Resgatando caso o Botão "Space" seja apertado
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
     void FixedUpdate()
    {
        //Adicionando Força para o Methodo Move, separando as funções e metodos das entradas do player.
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jump);
        jump = false;
    }


}
