using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class CharacterStates : MonoBehaviour
{

    [SerializeField] private Transform m_GroundCheck; //Componente de Verifica��o caso o Objeto estiver no ch�o.
    [SerializeField] private LayerMask m_WhatIsGround; //Mascara para definir o layer que � "ch�o" ou Grounded.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; //Aplicar fluidez na movimenta��o
    private Animator animator;  //Chamada para o componente Animator
    [SerializeField] private GameObject End_Screen; //Chamada para UI End_Screen
    

    const float k_GroundedRadius = .3f; // Raio de verifica��o de Solo
    private bool m_Grounded; //Defini se o Objeto est� ou n�o no ch�o
    private Rigidbody2D m_Rigidbody2D; //Resgata o componente Rigidbody
    private bool m_Facing = true; // Verifica se o Jogador est� olhando para a Esquerda(False) ou Direita(True)
    private Vector2 m_Velocity = Vector2.zero; // atualiza��o da Velocidade Atual para chegar na Nova Velocidade

    //Enum para Aplicar as anima��es condicionais ao personagem | 0 - Parado | 1 - Correndo | 2 - Pulando | 3 - Caindo.
    private enum MovementState { idle, running, jumping, falling }

    //Ativado Antes do primeiro frame do jogo
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Controle de Anima��o para separar os Inputs das anima��es.
    public void UpdateAnimationState(float move)
    {
        MovementState state;

        if (move != 0f) // Se a for�a aplicada ao Eixo-X for Diferente de 0 ent�o o personagem ir� entrar na anima��o de "Correndo" caso contr�rio entrar� na anima��o de "Parado"
            state = MovementState.running;

        else
            state = MovementState.idle;

        if (m_Rigidbody2D.velocity.y > .1f) // Se a Velocidade em Y estiver positiva ent�o o personagem entrar� na anima��o de "Pulando" caso seja negativa entre na de "Caindo"
            state = MovementState.jumping;

        else if (m_Rigidbody2D.velocity.y < -.1f)
            state = MovementState.falling;

        animator.SetInteger("PlayerState", (int)state); // Variavel respons�vel para alterar o estado de anima��o;
    }

    //Controle de Dire��o
    private void Flip()
    {

        
        m_Facing = !m_Facing; //Troca para a Dire��o contraria na qual o Objeto est� olhando
        
        Vector2 localScale = transform.localScale; 
        localScale.x *= -1;
        transform.localScale = localScale;

    }

   
    //Controle de Movimenta��o
    public void Move(float move,float jumpMove , bool jump)
    {
        
        Vector2 tgtVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y); //Variavel para Mover o Objeto de uma Velocidade at� a proxima Velocidade. TGT = Target
        m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, tgtVelocity, ref m_Velocity, m_MovementSmoothing); //Aplicando uma movimenta��o mais fluida para o componente

        
        if (move > 0 && !m_Facing)
        {
            Flip(); //Caso o objeto estiver movimentando-se para esquerda ent�o vire o mesmo para a Direita
        }
        
        else if (move < 0 && m_Facing)
        {
            Flip(); //Caso o Objeto estiver movimentando-se para a direita ent�o vire o mesmo para a esquerda
        }
        
        if (m_Grounded && jump && m_Rigidbody2D.velocity.y > -.1f) // Se o Estiver no Solo e Pular e n�o estiver caindo (Evitar alguns Bugs indesejados)
        {
            //Aplique uma For�a Vertical
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, jumpMove));
        }
    }


    public void Die()
    {
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death"); // Chama a aniama��o de death que cont�m o evento que reinicia a Cena 
    }


    public void GameWin(int fruit) 
    {

        if (fruit == 12)
        {
            Debug.Log("GameWin!");
            End_Screen.gameObject.SetActive(true); //Chama a Tela de Parab�ns
        }

    }

    public void Bounce(float bounce)
    {
        m_Rigidbody2D.AddForce(transform.up * bounce, ForceMode2D.Impulse);
    }

    public void Resetlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reinicia a Cena
    }

    private void FixedUpdate()
    {
        m_Grounded = false;

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); //O objeto estar� no ch�o quando o Raio acertar algum objeto considerado "Solo"
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                
                m_Grounded = true;
                
            }
        }
        
    }

   
}
