using UnityEngine;

public class fundoUm : MonoBehaviour
{
    public float vel;
    private Rigidbody2D rbd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 0.3f;
        rbd = GetComponent<Rigidbody2D>();
        rbd.linearVelocity = new Vector2(-vel, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < - 19.2) 
            transform.position = new Vector2(19, -2.24f);
    }
}