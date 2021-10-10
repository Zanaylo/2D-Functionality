using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Chamada do componente CharacterStates para movimentação do personagem
    public CharacterStates controller;
    //Chamada para o componente Animator
    public Animator animator;
    float horizontalMoviment = 0f;
    bool jump = false;
    public float runSpeed = 40f;


    void Update()
    {
        //Resgatando a Direção e Adicionando força
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMoviment));
        //Resgatando caso o Botão "Space" seja apertado
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jumping", true);
            jump = true;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    void FixedUpdate()
    {
        //Adicionando Força para o Methodo Move, separando as funções e metodos das entradas do player.
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jump);
        jump = false;
    }


}
