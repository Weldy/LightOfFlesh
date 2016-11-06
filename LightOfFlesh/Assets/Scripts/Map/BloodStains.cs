using UnityEngine;
using System.Collections;

public class BloodStains : Item {

    //AudioClip sound;
    
    [SerializeField]
    private float lifespan;
    private float lifespanCounter;

    void Start()
    {
        lifespanCounter = lifespan;
        //sound = Resources.Load("Sounds/cat") as AudioClip;
        itemType = ItemType.BloodStains;

    }


    void Update()
    {
        lifespanCounter -= Time.deltaTime;
        if (lifespanCounter < 0)
        {
            Destroy(this.gameObject);
        }
    }
}

