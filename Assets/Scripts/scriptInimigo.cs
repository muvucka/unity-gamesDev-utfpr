using UnityEngine;


public class scriptInimigo : MonoBehaviour
{

    [SerializeField]
    private int vidas;
    [SerializeField]
    private Animator anim;

    public void ReceberDano()
    {
        vidas--;
        if (vidas <= 0)
        {

            // Destroy(gameObject);
            anim.SetBool("Morte", true);
            IMorrivel morrivel = GetComponent<IMorrivel>();
            if (morrivel != null)
                morrivel.Morrer();
        }
        else
        {
            anim.SetTrigger("RecDano");
        }
    }
}
