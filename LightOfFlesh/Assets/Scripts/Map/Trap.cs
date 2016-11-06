using UnityEngine;
using System.Collections;

enum TrapType {BearTrap, Gravel, Glass, Hole };
public class Trap : Item {

    [SerializeField]
    TrapType trapType;
    AudioClip sound;
    [SerializeField]
    SonarLight sonarPrefab;

    SonarLight sonar;

    // Use this for initialization
    void Start () {
        itemType = ItemType.Trap;
        sonar = Instantiate(sonarPrefab);
        sonar.transform.position = this.transform.position;
        switch (trapType) {
            case TrapType.BearTrap:
        sound = Resources.Load("Sounds/bearTrap") as AudioClip;
        break;
            case TrapType.Gravel:
        sound = Resources.Load("Sounds/gravel") as AudioClip;
        break;
            case TrapType.Glass:
        sound = Resources.Load("Sounds/glass") as AudioClip;           
        break;
            case TrapType.Hole:
        sound = Resources.Load("Sounds/hole") as AudioClip;
        break;
        default:
                
        sound = Resources.Load("Sounds/cat") as AudioClip;
        break;
    }
}
    public void Activate(Hunted victime, AudioSource source)
    {
        if (!victime.invulnerable)
        {
          
            source.PlayOneShot(sound, 1);
            victime.invulnerable = true;
            sonar.startEffect();
            switch (trapType)
            {
                case TrapType.BearTrap:
                    victime.isTrapped = true;
                    victime.isBleeding = true;
                    Destroy(gameObject);
                    break;
                case TrapType.Gravel:

                    break;
                case TrapType.Glass:
                    Destroy(gameObject);
                    break;
                case TrapType.Hole:

                    victime.isTrapped = true;
                    break;
                default:

                    break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
