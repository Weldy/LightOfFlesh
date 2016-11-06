using UnityEngine;
<<<<<<< HEAD
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
=======
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
>>>>>>> d66cc9901a2a92e656f0f708cdbe4f274c71a3e5
    }
}
