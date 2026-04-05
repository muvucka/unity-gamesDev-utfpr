using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRespawn : MonoBehaviour
{
    public Transform alvoPc; // Referência ao transform do jogador (arraste no Inspector)
    private float altura;
    private float largura;
    public GameObject npcLich;
    // Start is called before the first frame update
    void Start()
    {

        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;
        // criar um inimigo
        InvokeRepeating("respawnar", 8, 13);

    }

    private void respawnar()
    {
        float posX = Random.Range(-largura, largura);
        Vector2 pos = new Vector2(posX, 5);
        GameObject novoNPC = Instantiate(npcLich, pos, Quaternion.identity);

        // Define o alvo do NPC como o jogador
        scriptLich lichScript = novoNPC.GetComponent<scriptLich>();
        if (lichScript != null)
        {
            lichScript.alvo = alvoPc;
        }
    }

}
