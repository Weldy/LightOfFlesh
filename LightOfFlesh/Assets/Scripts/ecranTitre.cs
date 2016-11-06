using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ecranTitre : MonoBehaviour
{   [SerializeField]
    public string scene;
    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(200, 100, 400, 400), "Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(300, 150, 200, 100), "Jouer"))
        {
            SceneManager.LoadScene(scene);
        }

        // Make the second button.
        if (GUI.Button(new Rect(300, 250, 200, 100), "Quiter"))
        {
            Application.Quit();
        }
    }

}