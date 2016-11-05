using UnityEngine;
using System.Collections;

enum BonusType { Cat, Bottle}
public class Bonus : Item {
    BonusType bonusType;
	// Use this for initialization
	void Start () {
        itemType = ItemType.Bonus;
    }
    void setBonusType(int i)
    {
        switch (i)
        {
            case 0:
                bonusType = BonusType.Cat;
                break;
            default:
                bonusType = BonusType.Bottle;
                break;
        }

    }

    public void PickUpBonus()
    {
        if (Input.GetButton("w"))
        {
            //TODO UI

        }
    }

    public void UseBonus()
    {
        AudioClip sound;
        AudioSource source = GetComponent<AudioSource>();
        switch (bonusType)
        {
            case BonusType.Cat:
                sound = Resources.Load("sounds/cat") as AudioClip;
                
                source.PlayOneShot(sound, 1);
                //animation
                break;
            default:
                sound= Resources.Load("sounds/bottle") as AudioClip;
                source.PlayOneShot(sound, 1);
                //animation
                break;
        }
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
