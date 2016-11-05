using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class selectLevel : MonoBehaviour {

    [SerializeField]
    public string destination;
    public void loadLevel()
    {
        SceneManager.LoadScene(destination);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
