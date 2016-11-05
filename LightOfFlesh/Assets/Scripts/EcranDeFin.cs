using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EcranDeFin : MonoBehaviour {
    [SerializeField]
    string destination;
	// Use this for initialization
	void Start () {
        StartCoroutine(Example());
	
	}


    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(10);
        SceneManager.LoadScene(destination);
    }
}
