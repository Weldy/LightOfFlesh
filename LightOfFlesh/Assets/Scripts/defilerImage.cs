using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class defilerImage : MonoBehaviour
{
    public string destination;
    public GameObject texture1;
    public GameObject texture2;
    private int timer;
    private bool lastWas1;
    

    void Start()
    {
        timer = 50;
        Texture.Instantiate(texture1, new Vector2(0, 0), Quaternion.identity);
        lastWas1 = true;
        
    }

    void Update()
    {
        timer--;
        if (timer == 0)
        {
            if (lastWas1 == true)
            {
                Instantiate(texture2, new Vector2(0, 0), Quaternion.identity);
                lastWas1 = false;
            }
            else
            {
                Instantiate(texture1, new Vector2(0, 0), Quaternion.identity);
                lastWas1 = true;
            }
            timer = 50;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(destination);
        }

    }


}