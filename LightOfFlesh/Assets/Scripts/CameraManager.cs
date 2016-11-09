using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


    [SerializeField]
    bool follow;

    [SerializeField]
    Transform target;

    [SerializeField]
    float maxX;
    [SerializeField]
    float maxY;
    [SerializeField]
    float minX;
    [SerializeField]
    float minY;

    Camera thisCamera;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;



    void Start () {
        thisCamera = this.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        if (follow)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            if (targetPosition.x > maxX)
                targetPosition.x = maxX;
            if (targetPosition.x < minX)
                targetPosition.x = minX;
            if (targetPosition.y > maxY)
                targetPosition.y = maxY;
            if (targetPosition.y < minY)
                targetPosition.y = minY;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        if (Input.GetButtonDown("F5"))
        {
            
            if (thisCamera.targetDisplay == 0)
            {
                thisCamera.targetDisplay = 1;
            }
            else if (thisCamera.targetDisplay == 1)
            {
                thisCamera.targetDisplay = 0;
            }
            
        }

    }
}
