using UnityEngine;
using System.Collections;


public class Hunted : Player {
    [SerializeField]
    Light torchlight;

    [SerializeField]
    float torchlightRange;
    
    public Bonus bonus;
    
    public bool gotKey;

    [SerializeField]
    public float invulnerableCooldown;
    public bool invulnerable;
    public float invulnerableCounter;

    [SerializeField]
    public float isTrappedCooldown;
    public bool isTrapped;
    public float isTrappedCounter;

    [SerializeField]
    public float isBleedingCooldown;
    public bool isBleeding;
    public float isBleedingCounter;

    private Animator animator;

    // Use this for initialization
    void Start () {
        gotKey = false;
        animator = GetComponent<Animator>();

        invulnerableCounter = invulnerableCooldown;
        isTrappedCounter = isTrappedCooldown;
        isBleedingCounter = isBleedingCooldown;
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
    {if(!isTrapped)
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
    void Update()
    {
        MoveHunted();

        //TODO déplacement progressif
        TorchlightControl();

        animate();

        if (!invulnerable)
        {

            invulnerableCounter = invulnerableCooldown;
        }
        else
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter < 0)
            {
                invulnerable = false;

                invulnerableCounter = invulnerableCooldown;

            }
        }
        if (Input.GetKey("x") && bonus)
        {
            bonus.UseBonus(gameObject.GetComponent<AudioSource>());
        }

        if (!isTrapped)
        {
            isTrappedCounter = isTrappedCooldown;
        }
        else
        {
            isTrappedCounter -= Time.deltaTime;
            if (isTrappedCounter < 0)
            {
                isTrapped = false;

                isTrappedCounter = isTrappedCooldown;
            }
        }
        if (!isBleeding)
        {
            isBleedingCounter = isBleedingCooldown;
        }
        else
        {
            isBleedingCounter -= Time.deltaTime;
            if (isBleedingCounter < 0)
            {
                isBleeding = false;
                isBleedingCounter = isBleedingCooldown;
            }
        }
    }
    }

