using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    [SerializeField]
    Transform target;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
