using UnityEngine;
using System.Collections;

public class scriptMedusa : MonoBehaviour, IMorrivel
{
    public LayerMask mascara;
    public GameObject peMedusa;
    public float vel = 3;
    [SerializeField]
    private float raioVisao;
    private Transform alvo;
    [SerializeField]
    private Rigidbody2D rbd;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    public float distMin;
    [SerializeField]
    private LayerMask layerAreaVisao;
    private bool chao;
    private Animator anim;
    [SerializeField]
    private float distMaxAtq;
    [SerializeField]
    private float interAtqSegundos;

    private float tempoEsperaAtqSegundos;

    private bool morto = false; // controle de estado

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tempoEsperaAtqSegundos = interAtqSegundos;
    }
    private void VerificarPossibilidadeAtq()
    {
        scriptPc Pc = alvo.GetComponent<scriptPc>();
        if (!Pc.Derrotado)
        {
            float dist = Vector3.Distance(transform.position, alvo.position);
            if (dist <= distMaxAtq)
            {
                tempoEsperaAtqSegundos -= Time.deltaTime;
                if (tempoEsperaAtqSegundos <= 0)
                {
                    tempoEsperaAtqSegundos = interAtqSegundos;
                    Atacar();
                }
            }
        }
    }

    private void Atacar()
    {
        anim.SetTrigger("Atacando");
    }
    public void AplicarDano()
    {
        scriptPc Pc = alvo.GetComponent<scriptPc>();
        Pc.ReceberDano();
    }

    void Update()
    {
        if (morto) return;

        ProcurarPc();

        if (alvo != null)
        {
            Vector2 posicaoAlvo = alvo.position;
            Vector2 posicaoAtual = transform.position;
            posicaoAlvo.y = posicaoAtual.y;

            float dist = Vector2.Distance(posicaoAtual, posicaoAlvo);
            if (dist >= distMin)
            {
                Vector2 direcao = (posicaoAlvo - posicaoAtual).normalized;
                rbd.linearVelocity = direcao * vel;

                spriteRenderer.flipX = rbd.linearVelocity.x < 0;

                anim.SetBool("movendo", true);
            }
            else
            {
                PararMovimento();
            }

            // Verifica o chão
            RaycastHit2D hit = Physics2D.Raycast(peMedusa.transform.position, Vector2.down, 5f, mascara);
            chao = hit.collider != null;

            VerificarPossibilidadeAtq();
        }
        else
        {
            PararMovimento(); // Para se o alvo sair da visão
        }
    }

    private void PararMovimento()
    {
        rbd.linearVelocity = Vector2.zero;
        anim.SetBool("movendo", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioVisao);
    }

    private void ProcurarPc()
    {
        Collider2D colisor = Physics2D.OverlapCircle(transform.position, raioVisao, layerAreaVisao);

        if (colisor != null)
        {
            alvo = colisor.transform;
        }
        else
        {
            alvo = null;
        }
    }

    public void Morrer()
    {
        if (morto) return;
        morto = true;

        anim.SetBool("Morte", true);
        rbd.linearVelocity = Vector2.zero;
        rbd.bodyType = RigidbodyType2D.Kinematic;

        foreach (Collider2D col in GetComponentsInChildren<Collider2D>())
        {
            col.enabled = false;
        }

        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        // StartCoroutine(DestruirDepoisDeMorrer());
    }

    // private IEnumerator DestruirDepoisDeMorrer()
    // {
    //     yield return new WaitForSeconds(1.2f);
    //     Destroy(gameObject);
    // }
}