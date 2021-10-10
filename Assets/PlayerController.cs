using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Chamada do componente CharacterStates para movimenta��o do personagem
    public CharacterStates controller;
    //Chamada para o componente Animator
    public Animator animator;
    float horizontalMoviment = 0f;
    bool jump = false;
    public float runSpeed = 40f;


    void Update()
    {
        //Resgatando a Dire��o e Adicionando for�a
        horizontalMoviment = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMoviment));
        //Resgatando caso o Bot�o "Space" seja apertado
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
        //Adicionando For�a para o Methodo Move, separando as fun��es e metodos das entradas do player.
        controller.Move(horizontalMoviment * Time.fixedDeltaTime, jump);
        jump = false;
    }


}
