using UnityEngine;
using System.Collections;

public class Hunter : Player {

    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float sprintDistance;
    [SerializeField]
    private float sprintDeviate;
    //   [SerializeField]
    //    private float maxSpeed;

    private float currentSpeed;
    private float sprintCounterX, sprintCounterY;
    private float sensH, sensV;

    private Animator animator;

    // Use this for initialization
    void Start () {
        sensH = 1;
        sensV = 1;
        sprintCounterX = 0;
        sprintCounterY = 0;

        animator = GetComponent<Animator>();
    }

    void animate()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animator.SetInteger("moving", 0);

            if (animator.GetInteger("movingDirection") == 0)
            {
                animator.SetInteger("LightDirection", 0);
            }
            else if (animator.GetInteger("movingDirection") == 1)
                animator.SetInteger("LightDirection", 1);
            else if (animator.GetInteger("movingDirection") == 2)
                animator.SetInteger("LightDirection", 2);
        }
        else
        {
            animator.SetInteger("moving", 1);

            if (Input.GetAxis("Vertical") > 0)
            {
                animator.SetInteger("movingDirection", 0);
                
            }
            else if (Input.GetAxis("Horizontal") > 0)
                animator.SetInteger("movingDirection", 1);
            else 
                animator.SetInteger("movingDirection", 2);
        }
    }

    void MoveHunter()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (sprintCounterX+sprintCounterY > sprintDistance)
        {
            currentSpeed += (sprintCounterX+sprintCounterY - sprintDistance) * sprintSpeed;
       
        }
        else
        {
            currentSpeed = Speed;
        }
        Position += new Vector2(x, y) * currentSpeed * Time.deltaTime;

        if (x * sensH > 0)
        {
            if ((y < sprintDeviate && y >= 0) || (y > -sprintDeviate && y < 0))
            {
                sprintCounterX++;
            }

            else
            {
                sprintCounterX = 0;
               
            }
        }
        else
        {
            sensH *= -1;

            sprintCounterX = 0;
        }
    
        if (y * sensV > 0)
        {
            if ((x < sprintDeviate && x >= 0) || (x > -sprintDeviate && x < 0))
            {
                sprintCounterY++;
            }

            else
            {
                sprintCounterY = 0;
            }
        }
        else
        {
            sensV *= -1;

            sprintCounterY = 0;
        }

        animate();
    }
    // Update is called once per frame
    void Update () {
        MoveHunter();
    }
}
