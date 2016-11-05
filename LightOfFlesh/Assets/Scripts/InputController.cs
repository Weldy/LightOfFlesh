using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    [SerializeField]
    private Vector2 speed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private Light torchlight;


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
        

        torchlight.transform.eulerAngles = new Vector3(
            Mathf.Atan2(y, x) * Mathf.Rad2Deg,
            -90,
            90
            );

        /*print(torchlight.transform.eulerAngles.x);
        print(torchlight.transform.eulerAngles.y);
        print(torchlight.transform.eulerAngles.z);*/
    }
}
