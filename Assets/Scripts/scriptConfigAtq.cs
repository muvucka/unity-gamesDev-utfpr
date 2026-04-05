using UnityEngine;

public class scriptConfigAtq : MonoBehaviour
{
    [SerializeField]
    private Transform pontoSocoDir;
    [SerializeField]
    private Transform pontoSocoEsq;
    [SerializeField]
    private float raioAtq;
    [SerializeField]
    private LayerMask layersAtq;
    [SerializeField]
    private scriptPc animPc;
    [SerializeField] private int numAtq;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if (pontoSocoDir != null)
        {
            Gizmos.DrawWireSphere(pontoSocoDir.position, raioAtq);
        }
        if (pontoSocoEsq != null)
        {
            Gizmos.DrawWireSphere(pontoSocoEsq.position, raioAtq);
        }
        /* Transform pontoAtq;
         if (animPc.direcaoMovimento == DirecaoMovimento.Direita)
             pontoAtq = pontoSocoDir;
         else
         {
             pontoAtq = pontoSocoEsq;
         }
             Gizmos.color = Color.red;
             Gizmos.DrawWireSphere(pontoAtq.position, raioAtq);*/

    }
    // Update is called once per frame
    public void IniciarAtq()
    {
        animPc.Atacar(numAtq);

    }

    public void AplicarDano(DirecaoMovimento direcao)
    {
        // Correção aqui
        Transform pontoAtual;
        if (direcao == DirecaoMovimento.Direita)
        {
            pontoAtual = pontoSocoDir;
        }
        else
        {
            pontoAtual = pontoSocoEsq;
        }

        Debug.Log("Atacando com o lado " + pontoAtual.name);
        Collider2D[] collidersInimigos = Physics2D.OverlapCircleAll(pontoAtual.position, raioAtq, layersAtq);

        foreach (Collider2D colliderInimigo in collidersInimigos)
        {
            scriptInimigo inimigo = colliderInimigo.GetComponent<scriptInimigo>();
            if (inimigo != null)
            {
                Debug.Log("Atacando Inimigo " + colliderInimigo.name);
                inimigo.ReceberDano();
            }
        }
    }

}