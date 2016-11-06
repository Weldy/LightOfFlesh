using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    [RequireComponent(typeof(AudioSource))]

public class video : MonoBehaviour {

        [SerializeField]
        public string destination;

    public MovieTexture movie;

    public AudioSource audio;

	// Use this for initialization
	void Start () 
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(destination);
        }
    }

}
