using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    [SerializeField]
    private Vector2 speed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private Light torchlight;

    private bool isOn = true;

    public float MaxSpeed
    {
        get
        {
            return this.maxSpeed;
        }
        private set
        {
            this.maxSpeed = value;
        }
    }

    public Vector2 Speed
    {
        get;
        set;
    }

    public Vector2 Position
    {
        get
        {
            return transform.position;
        }
        private set
        {
            transform.position = value;
        }
    }

    void Update()
    {
        Speed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector2 newPosition = Position + MaxSpeed * Speed * Time.deltaTime;

        Position = newPosition;

        float x = Input.GetAxis("RSX");
        float y = Input.GetAxis("RSY");
        
        if(x == 0 && y == 0)
        {
            torchlight.transform.eulerAngles = new Vector3(
            torchlight.transform.eulerAngles.x,
            -90,
            90
            );
        }else
        {
            torchlight.transform.eulerAngles = new Vector3(
            Mathf.Atan2(-y, -x) * Mathf.Rad2Deg,
            -90,
            90
            );
        }

        if (Input.GetButton("Action"))
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
                
        }
        
    }
}
