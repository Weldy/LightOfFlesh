using UnityEngine;
using System.Collections;

enum TrapType {BearTrap, Gravel };
public class Trap : Item {


    TrapType trapType;
    AudioClip sound;
    private AudioSource source;
    

        // Use this for initialization
        void Start () {
        itemType = ItemType.Trap;
        source = GetComponent<AudioSource>();
    }
    void setTrapType(int i)
    {
        switch (i) {
            case 0:
                trapType = TrapType.BearTrap;
                sound = Resources.Load("sounds/BearTrap") as AudioClip;
                break;
            case 1:
                trapType = TrapType.Gravel;
                sound = Resources.Load("sounds/Gravel") as AudioClip;
                break;
            default:
                trapType = TrapType.BearTrap;
                sound = Resources.Load("sounds/BearTrap") as AudioClip;
                break;
        }

    }

    void Activate()
    {
        source.PlayOneShot(sound, 1);
        //animation
        switch (trapType)
        {
            case TrapType.BearTrap:
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
