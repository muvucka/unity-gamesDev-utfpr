using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{

    private Vector2 posIni;
    public float deslocamento = 1;
    private float cont = 0;
    public float larg = 1;
    public float alt = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posIni = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(cont) * larg;
        float y = Mathf.Sin(cont) * alt;

        transform.position = new Vector2(posIni.x + x, posIni.y +y);
        cont = cont + deslocamento * Time.deltaTime;

        if (cont > 2 * Mathf.PI) cont = cont -  2 * Mathf.PI;



    }
}
