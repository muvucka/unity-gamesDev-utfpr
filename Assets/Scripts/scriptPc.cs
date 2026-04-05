using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System.Collections;

public class scriptPc : MonoBehaviour
{
    public LayerMask mascara;
    public GameObject pe;
    [SerializeField] private Rigidbody2D rbd;
    private Animator anim;
    [SerializeField] public float vel;
    public float pulo;
    private bool direita = true;
    private bool chao;
    private int contadorPulo;
    public int maxPulos = 2;
    [SerializeField] private scriptSoco ataqueJogador;
    public DirecaoMovimento direcaoMovimento;
    private bool tentouPular;
    public float horizontal;
    private bool usandoDash = false;
    [SerializeField] private float duracao = 0.2f;
    [SerializeField] private float forcaDash = 10f;
    private float contDuracao;
    [SerializeField]
    private int vidas;
    [SerializeField]
    public TextMeshProUGUI textoVidas;
    private bool travadoAoPousar = false;
    private bool tomandoDano = false;


    private void Awake()
    {
        RefreshScreen();
    }
    void Start()
    {
        vel = 4;
        rbd = GetComponent<Rigidbody2D>();
        pulo = 550;
        anim = GetComponent<Animator>();
        direcaoMovimento = DirecaoMovimento.Direita;
        contDuracao = 0;
        RefreshScreen();
    }

    public bool Derrotado
    {
        get
        {
            return (vidas <= 0);
        }
    }
    private IEnumerator MorteCoroutine()
    {
        yield return new WaitForSeconds(1.9f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

    }
    public void ReceberDano()
    {
        if (tomandoDano) return;
        vidas--;
        Debug.Log("Total de Vidas: " + vidas);
        RefreshScreen();
        if (Derrotado)
        {
            anim.SetBool("Derrotado", true);
            StartCoroutine(MorteCoroutine());
        }
        else
        {
            tomandoDano = true;
            anim.ResetTrigger("recebendoDano");
            anim.SetTrigger("recebendoDano");
            // SetLife(-1);
        }
    }
    void Update()
    {
        if (Derrotado) return;
        // Se estiver atacando ou usando dash, ignora input
        if (ataqueJogador.Atacando || usandoDash || tomandoDano)
        {
            tentouPular = false;
            horizontal = 0;
        }
        else
        {
            // Entrada de movimento e pulo
            tentouPular = Input.GetKeyDown(KeyCode.Space);
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        // Dash
        if (Input.GetMouseButtonDown(1) && !usandoDash && !ataqueJogador.Atacando)
        {
            usandoDash = true;
            contDuracao = 0;

            float direcao = direita ? 1 : -1;
            rbd.linearVelocity = new Vector2(direcao * forcaDash, 0);
            anim.SetTrigger("Dash");
        }

        if (usandoDash)
        {
            contDuracao += Time.deltaTime;
            if (contDuracao >= duracao)
            {
                usandoDash = false;
                contDuracao = 0;
                rbd.linearVelocity = Vector2.zero;
                // tentouPular = false;
            }

            return; // Ignora o restante do Update durante dash
        }

        // Atualiza direção
        if (horizontal > 0 && !direita)
            Virar(true);
        else if (horizontal < 0 && direita)
            Virar(false);

        // Verifica chão
        RaycastHit2D hit = Physics2D.Raycast(pe.transform.position, Vector2.down, 0.3f, mascara);
        bool estavaNoAr = !chao;
        chao = hit.collider != null;
        if (!chao) transform.parent = null;
        if (chao) transform.parent = hit.collider.transform;

        if (chao && estavaNoAr)
        {
            contadorPulo = 0;
            anim.SetBool("Pulo", false);
            travadoAoPousar = true;
            anim.SetTrigger("Pouso");
        }
    }

    void LateUpdate()
    {
        if (usandoDash || tomandoDano)
            return;

        // Travar movimento enquanto ataca
        if (!ataqueJogador.Atacando || !travadoAoPousar)
        {
            rbd.linearVelocity = new Vector2(horizontal * vel, rbd.linearVelocity.y);
            anim.SetBool("movendo", horizontal != 0);
        }
        else
        {
            rbd.linearVelocity = new Vector2(0, rbd.linearVelocity.y);
            anim.SetBool("movendo", false);
        }

        // Pulo
        if (!ataqueJogador.Atacando && tentouPular && contadorPulo < maxPulos)
        {
            rbd.linearVelocity = new Vector2(rbd.linearVelocity.x, 0);
            rbd.AddForce(new Vector2(0, pulo));
            anim.SetBool("Pulo", true);
            contadorPulo++;
        }
    }

    private void Virar(bool paraDireita)
    {
        direita = paraDireita;

        Vector3 escala = transform.localScale;
        escala.x = Mathf.Abs(escala.x) * (direita ? 1 : -1);
        transform.localScale = escala;

        direcaoMovimento = direita ? DirecaoMovimento.Direita : DirecaoMovimento.Esquerda;
    }

    public bool EstaViradoParaDireita() => direita;

    public void SetLife(int vida)
    {
        vidas += vida;
        if (vidas >= 0)
            RefreshScreen();
    }

    public void RefreshScreen()
    {
        textoVidas.text = vidas.ToString();
    }

    public void Atacar(int numAtq)
    {
        if (usandoDash) return; // Bloqueia ataque durante o dash

        string nomeParam = "Soco" + numAtq;
        anim.SetTrigger(nomeParam);
    }

    public void DestravarAposPouso()
    {
        travadoAoPousar = false;
    }
    public void FimAnimacaoRecebendoDano()
    {
        Debug.Log("Fim da animação de dano");
        tomandoDano = false;
    }
}