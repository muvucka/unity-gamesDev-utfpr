using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject Pc;
    private float offsetY = 2f;
    public float delayAfterKeyPress = 1f;

    private bool keyWasPressed = false;
    private float timer = 0f;
    private bool shouldFollow = false;

    void Update()
    {
        if (!keyWasPressed && Input.anyKeyDown)
        {
            keyWasPressed = true; // Jogador apertou alguma tecla
        }

        if (keyWasPressed && !shouldFollow)
        {
            timer += Time.deltaTime;
            if (timer >= delayAfterKeyPress)
            {
                shouldFollow = true; // Agora pode seguir o jogador
            }
        }

        if (shouldFollow)
        {
            transform.position = new Vector3(
                Pc.transform.position.x,
                Pc.transform.position.y + offsetY,
                -10f
            );
        }
    }
}
