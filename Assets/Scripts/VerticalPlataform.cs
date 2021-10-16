using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlataform : MonoBehaviour
{

    [SerializeField]private PlatformEffector2D effector;
    public bool coll;
    
    // Start is called before the first frame update
    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>(); //Resgata o Componente
    }

    public void PlataformOneWay()
    {
        if (coll)
        {
            effector.surfaceArc = 0f; //Faz com que o arco da superfice não exista quando apertar para baixo e esperar
            StartCoroutine(Wait());
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        coll = true; //Ao colidir faz com que a superfice esteja disponivel para desaparecer
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        coll = false; //quando falso a superfice não pode desaparecer
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.33f);
        effector.surfaceArc = 135f; //Após esperar a plataforma volta para a Superfice correta
    }
}
