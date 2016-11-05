using UnityEngine;
using System.Collections;

public class Hunted : Player {
    [SerializeField]
    Light torchlight;

    [SerializeField]
    float torchlightRange;

    Bonus bonus;
    public bool gotKey;

    private Animator animator;

    // Use this for initialization
    void Start () {
        gotKey = false;
        animator = GetComponent<Animator>();
    }

    void animate()
    {
        if(Input.GetAxis("XBoxHorizontal") == 0 && Input.GetAxis("XBoxVertical") == 0)
        {
            animator.SetInteger("moving", 0);

            if (Input.GetAxis("RSY") > 0)
            {
                animator.SetInteger("LightDirection", 0);
            }
            else if (Input.GetAxis("RSX") > 0)
                animator.SetInteger("LightDirection", 1);
            else if(Input.GetAxis("RSX") < 0)
                animator.SetInteger("LightDirection", 2);
        }
        else
        {
            animator.SetInteger("moving", 1);

            if (Input.GetAxis("XBoxVertical") > 0)
            {
                animator.SetInteger("movingDirection", 0);
            }
            else if (Input.GetAxis("XBoxHorizontal") > 0)
                animator.SetInteger("movingDirection", 1);
            else if (Input.GetAxis("XBoxHorizontal") < 0)
                animator.SetInteger("movingDirection", 2);
        }
    }
   void MoveHunted()
    {
        Position += new Vector2(Input.GetAxis("XBoxHorizontal"), Input.GetAxis("XBoxVertical")) * Speed * Time.deltaTime;

    }
    void TorchlightControl()
    {
        float x = Input.GetAxis("RSX");
        float y = Input.GetAxis("RSY");

        if (x == 0 && y == 0)
        {
            torchlight.transform.eulerAngles = new Vector3(
            torchlight.transform.eulerAngles.x,
            -90,
            90
            );
        }
        else
        {
            torchlight.transform.eulerAngles = new Vector3(
            Mathf.Atan2(-y, -x) * Mathf.Rad2Deg,
            -90,
            90
            );
        }

        torchlight.range = torchlightRange * Input.GetAxis("Action");

       /* if (Input.GetAxis("Action") == 1)
        {
            if (isOn)
            {
                torchlight.range = 0;
                isOn = false;
            }
            else
            {
                torchlight.range = 10;
                isOn = true;
            }

        }*/
    }
    
    // Update is called once per frame
    void Update () {
        MoveHunted();

        //TODO déplacement progressif
        TorchlightControl();

        animate();
        /*if (Input.GetButton("w") && !bonus)
        {
            bonus.PickUpBonus();
        }
        if (Input.GetButton("w") && bonus)
        {
            bonus.UseBonus();
        }*/
    }
}

