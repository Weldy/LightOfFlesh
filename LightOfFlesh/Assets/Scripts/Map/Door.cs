using UnityEngine;
using System.Collections;

public class Door : Item {
    public bool isOpening;
    public bool isOpen;
    AudioClip sound;
    [SerializeField]
    private float openingWindow;
    [SerializeField]
    private float openingTime;

    private float counterOpeningWindow;
    private float counterOpeningTime;
    // Use this for initialization
    void Start () {
        isOpen = false;
        isOpening = false;
        counterOpeningWindow=openingWindow;
        counterOpeningTime=openingTime;
        sound = Resources.Load("Sounds/cat") as AudioClip;
    }
	
    public void startOpen(AudioSource source)
    {
        //if player has key
        source.PlayOneShot(sound, 1);
        isOpening = true;
    }
    //on collision,if open win, if got key startopen()
	// Update is called once per frame
	void Update () {
        if (isOpening)
        {
            counterOpeningTime -= Time.deltaTime;

            if (counterOpeningTime < 0)
            {
                isOpen = true;
                isOpening = false;
                counterOpeningTime = openingTime;
            }
        }
        if(isOpen)
        {
            counterOpeningWindow -= Time.deltaTime;
            if (counterOpeningWindow < 0)
            {
                isOpen = false;
                counterOpeningWindow = openingWindow;
            }
        }
    }
}
