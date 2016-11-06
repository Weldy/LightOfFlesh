using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : Item {
    public bool isOpening;
    public bool isOpen;
    AudioClip sound;
    [SerializeField]
    private float openingWindow;
    [SerializeField]
    private float openingTime;

    Animator animator;

    private float counterOpeningWindow;
    private float counterOpeningTime;
    // Use this for initialization
    void Start () {
        isOpen = false;
        isOpening = false;
        counterOpeningWindow=openingWindow;
        counterOpeningTime=openingTime;
        sound = Resources.Load("Sounds/door") as AudioClip;

        animator = GetComponent<Animator>();
    }
    public void doorCollide(Hunted victime, AudioSource source)
    {
        if (isOpen)
        {
            SceneManager.LoadScene("scene_victoire");
        }
        else {
            if (victime.gotKey)
            {
                if (!isOpening) { source.PlayOneShot(sound, 1.2f); }
                isOpening = true;
                animator.SetInteger("Ouverture", 1);
            }

           
        }
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
                animator.SetInteger("Ouverte", 1);
            }
        }
        if(isOpen)
        {
            counterOpeningWindow -= Time.deltaTime;
            if (counterOpeningWindow < 0)
            {
                isOpen = false;
                counterOpeningWindow = openingWindow;;
                animator.SetInteger("Ouverture", 0);
                animator.SetInteger("Ouverte", 0);
            }
        }
    }
}
