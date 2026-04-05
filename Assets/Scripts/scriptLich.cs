using UnityEngine;
using System.Collections;

public interface IMorrivel
{
    void Morrer();
}

public class scriptLich : MonoBehaviour, IMorrivel
{
    public LayerMask mascara;
    public GameObject peLich;
    public float vel = 3;
    [SerializeField] public Transform alvo;
    [SerializeField] private Rigidbody2D rbd;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public float distMin;
    private bool chao;

    // Variáveis para flutuação
    public float distanciaFlutuacao = 12f; // Distância desejada do chão
    public float forcaFlutuacao = 20f;     // Força da flutuação

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rbd.gravityScale = 0; // Desativa a gravidade para permitir flutuação
    }

    void Update()
    {
        if (alvo == null) return;

        Vector2 posicaoAlvo = alvo.position;
        Vector2 posicaoAtual = transform.position;
        float dist = Vector2.Distance(posicaoAtual, posicaoAlvo);

        // Movimento horizontal
        if (dist >= distMin)
        {
            Vector2 direcao = (posicaoAlvo - posicaoAtual).normalized;
            float velocidadeHorizontal = direcao.x * vel;
            rbd.linearVelocity = new Vector2(velocidadeHorizontal, rbd.linearVelocity.y);
            spriteRenderer.flipX = (direcao.x > 0);
        }
        else
        {
            rbd.linearVelocity = new Vector2(0, rbd.linearVelocity.y);
        }

        // Flutuação com Raycast
        RaycastHit2D hit = Physics2D.Raycast(peLich.transform.position, Vector2.down, distanciaFlutuacao * 2f, mascara);
        Debug.DrawRay(peLich.transform.position, Vector2.down * distanciaFlutuacao * 2f, Color.red);

        if (hit.collider != null)
        {
            float distanciaDoChao = hit.distance;
            float erroAltura = distanciaFlutuacao - distanciaDoChao;

            // Força proporcional ao erro de altura
            float velocidadeVertical = erroAltura * forcaFlutuacao;
            rbd.linearVelocity = new Vector2(rbd.linearVelocity.x, velocidadeVertical);

            chao = true;
        }
        else
        {
            // Caso não haja chão detectado, desce lentamente
            rbd.linearVelocity = new Vector2(rbd.linearVelocity.x, -1f);
            chao = false;
        }

        // Destroi se sair da tela
        if (transform.position.y < -Camera.main.orthographicSize)
            Morrer();
    }

    public void Morrer()
    {
        StartCoroutine(MorteCoroutine());
    }

    private IEnumerator MorteCoroutine()
    {
        yield return new WaitForSeconds(0.620f);
        Destroy(gameObject);
    }
}
