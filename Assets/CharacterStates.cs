using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f; //Quantidade de For�a aplicada ao pular.
    [SerializeField] private Transform m_GroundCheck; //MACA��O de Verifica��o caso o Objeto estiver no ch�o.
    [SerializeField] private LayerMask m_WhatIsGround; //Mask para definir o layer que � "ch�o" ou Grounded.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; //Aplicar fluidez na movimenta��o

    const float k_GroundedRadius = .3f; // Raio de verifica��o de Solo
    private bool m_Grounded; //Defini se o Objeto est� ou n�o no ch�o
    private Rigidbody2D m_Rigidbody2D; //Resgata o componente Rigidbody
    private bool m_Facing = true; // Verifica se o Jogador est� olhando para a Esquerda(False) ou Direita(True)
    private Vector2 m_Velocity = Vector2.zero; // atualiza��o da Velocidade Atual para chegar na Nova Velocidade

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Flip()
    {

        //Troca para a Dire��o contraria na qual o Objeto est� olhando
        m_Facing = !m_Facing;
        //Multiplicar por -1 o scale do objeto da a impress�o que ele virou :)
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    public void Move(float move, bool jump)
    {
        //Variavel para Mover o Objeto de uma Velocidade at� a proxima Velocidade. TGT = Target
        Vector2 tgtVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        //Aplicando uma movimenta��o mais fluida para o Objeto
        m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, tgtVelocity, ref m_Velocity, m_MovementSmoothing); //Posi��o inicial, Velocidade Esperada, Velocidade Atual, Tempo para chegar na Velocidade Esperada;

        //Caso o objeto estiver movimentando-se para esquerda ent�o vire o mesmo para a Direita
        if (move > 0 && !m_Facing)
        {
            Flip();
        }
        //Caso o Objeto estiver movimentando-se para a direita ent�o vire o mesmo para a esquerda
        else if (move < 0 && m_Facing)
        {
            Flip();
        }
        // Se o jogador Pular e Estiver no solo
        if (m_Grounded && jump)
        {
            //Aplique uma For�a Vertical
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        //O objeto estar� no ch�o quando o Raio acertar algum objeto considerado "Solo"
        //Sim, poderia realizar o collider com os Layers do Proprio Unity 3d, p�rem esse metodo n�o sobrescreve as configura��es do projeto caso novos assets e camadas sejam adicionados depois;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
        
    }

}
