using UnityEngine;
using System.Collections;

public class Key : Item {

    AudioClip sound;
    
    // Use this for initialization
    void Start () {
        sound = Resources.Load("Sounds/key") as AudioClip;
    }
	//on collision play sound+change bool in player+destroykey
    public void keyCollide(Hunted victime, AudioSource source)
    {
        source.PlayOneShot(sound, 0.5f);
        victime.gotKey = true;

        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
