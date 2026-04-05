using UnityEngine;

public class scriptSoco : MonoBehaviour
{
    [SerializeField] private scriptConfigAtq[] configsAtq;
    [SerializeField] private scriptPc Pc;
    private scriptConfigAtq configAtqEscolhida;
    private bool atacando;


    void Start()
    {
        atacando = false;
        SelecionarAtaque();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !atacando)
            Atacar();
    }

    

    public bool Atacando
    {
        get { return atacando; }
    }

    private void Atacar()
    {
        atacando = true;
        configAtqEscolhida.IniciarAtq();
    }

    public void AplicarDano()
    {
        configAtqEscolhida.AplicarDano(Pc.direcaoMovimento);
    }
    public void EncerrarAtaque()
    {
        atacando = false;
        SelecionarAtaque();
    }
    private void SelecionarAtaque()
    {
        int numAnim = Random.Range(0, configsAtq.Length);
        configAtqEscolhida = configsAtq[numAnim];
    }
}
