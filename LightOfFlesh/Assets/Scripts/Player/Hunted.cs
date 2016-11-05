using UnityEngine;
using System.Collections;

public class Hunted : Player {
    [SerializeField]
    Light torchlight;

    private bool isOn;


	// Use this for initialization
	void Start () {
        isOn = false;
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

        torchlight.range = 10 * Input.GetAxis("Action");

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
    }
}

