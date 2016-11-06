using UnityEngine;
using System.Collections;

enum TrapType {BearTrap, Gravel };
public class Trap : Item {

    [SerializeField]
    TrapType trapType;

    [SerializeField]
    SonarLight sonarPrefab;

    SonarLight sonar;

    AudioClip sound;

        // Use this for initialization
    void Start () {
        itemType = ItemType.Trap;
        sound = Resources.Load("Sounds/cat") as AudioClip;
        sonar = Instantiate(sonarPrefab);
        sonar.transform.position = this.transform.position;
    }
    void setTrapType(int i)
    {
        switch (i) {
            case 0:
                trapType = TrapType.BearTrap;
                sound = Resources.Load("Sounds/cat") as AudioClip;
                break;
            case 1:
                trapType = TrapType.Gravel;
                sound = Resources.Load("Sounds/cat") as AudioClip;
                break;
            default:
                trapType = TrapType.BearTrap;
                sound = Resources.Load("sounds/BearTrap") as AudioClip;
                break;
        }

       

    }

    public void Activate(AudioSource source)
    {
        source.PlayOneShot(sound, 1);

        sonar.startEffect();
        
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
