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
        sound = Resources.Load("Sounds/cat") as AudioClip;
        break;
            case TrapType.Gravel:
        sound = Resources.Load("Sounds/walk") as AudioClip;
        break;
            case TrapType.Glass:
        sound = Resources.Load("Sounds/cat") as AudioClip;
        break;
            case TrapType.Hole:
        sound = Resources.Load("Sounds/cat") as AudioClip;
        break;
        default:
                
        sound = Resources.Load("Sounds/cat") as AudioClip;
        break;
    }
}/*
    void setTrapType(int i)
    {
        switch (i) {
            case 0:
                trapType = TrapType.BearTrap;
                sound = Resources.Load("Sounds/cat") as AudioClip;
                break;
            case 1:
                trapType = TrapType.Gravel;
                sound = Resources.Load("Sounds/walk") as AudioClip;
                break;
            case 2:
                trapType = TrapType.Glass;
                sound = Resources.Load("Sounds/cat") as AudioClip;
                break;
            case 3:
                trapType = TrapType.Hole;
                sound = Resources.Load("Sounds/cat") as AudioClip;
                break;
            default:
                trapType = TrapType.BearTrap;
                sound = Resources.Load("Sounds/cat") as AudioClip;
                break;
        }

    }*/

    public void Activate(Hunted victime, AudioSource source)
    {
        source.PlayOneShot(sound, 1);
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
                
                break;
            default:
                
                break;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
