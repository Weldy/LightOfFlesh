using UnityEngine;
using System.Collections;

public class Obstacle : Item {
    AudioClip sound;
    
    void Start()
    {
        
        sound = Resources.Load("Sounds/cat") as AudioClip;
        itemType = ItemType.Obstacle;
        
    }

    public void obstacleCollide(AudioSource source)
    {

        source.PlayOneShot(sound, 1);
    }
}
