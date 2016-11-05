using UnityEngine;
using System.Collections;

enum BonusType { Cat, Bottle}
public class Bonus : Item {
    [SerializeField]
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

    public void PickUpBonus(Hunted hunted, AudioSource source)
    {
        if (Input.GetKey("w") && !hunted.bonus)
        {

            hunted.bonus = this ;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    public void UseBonus(AudioSource source)
    {
        AudioClip sound;
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
