using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPause : MonoBehaviour
{
    private bool pausa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }
            else 
            { 
                Time.timeScale = 0;
                pausa = true;
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
        }
    }
}
