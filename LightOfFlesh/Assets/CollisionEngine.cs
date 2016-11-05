using UnityEngine;
using System.Collections;

public class CollisionEngine : MonoBehaviour
{

    private bool hasObstacleTop;
    private bool hasObstacleRight;
    private bool hasObstacleLeft;
    private bool hasObstacleBottom;

    //[SerializeField]
    //private GameObject victime;

    [SerializeField]
    private Transform rightCheck;
    [SerializeField]
    private Transform leftCheck;
    [SerializeField]
    private Transform topCheck;
    [SerializeField]
    private Transform bottomCheck;
    [SerializeField]
    private Transform centerCheck;

    private RaycastHit hitTop;
    private RaycastHit hitLeft;
    private RaycastHit hitRight;
    private RaycastHit hitBottom;


    private float distanceToBottom;
    private float distanceToRight;
    private float distanceToLeft;
    private float distanceToTop;

    


    // Use this for initialization
    void Start()
    {
        float x = centerCheck.transform.position.x - rightCheck.transform.position.x;
        float y = centerCheck.transform.position.y - bottomCheck.transform.position.y;
        
    }

    void LateUpdate()
    {

        hasObstacleTop = Physics.Linecast(centerCheck.position, topCheck.position, out hitTop, 1 << 0);
        hasObstacleRight = Physics.Linecast(centerCheck.position, rightCheck.position, out hitRight, 1 << 0);
        hasObstacleLeft = Physics.Linecast(centerCheck.position, leftCheck.position, out hitLeft, 1 << 0);
        
        hasObstacleBottom = Physics.Linecast(centerCheck.position, bottomCheck.position, out hitBottom, 1 << 0);


        /*if (hitUp.collider != null)
        {
            Plateform plateform = hitUp.collider.GetComponent<Plateform>();

            if (plateform.type == Plateform.TYPE.Obstacle || plateform.type == Plateform.TYPE.MoovingHoriObstacle)
                hasObstacleUp = true;
            else
                hasObstacleUp = false;

        }
        if (hitGround.collider != null)
        {
            Plateform plateform = hitGround.collider.GetComponent<Plateform>();

            if (plateform.type == Plateform.TYPE.HorizontalMooving || plateform.type == Plateform.TYPE.MoovingHoriObstacle)
            {
                isOnMoovingPlateform = true;
                MoovingPlateform moovingPlateform = hitGround.collider.GetComponent<MoovingPlateform>();
                plateformSpeed = moovingPlateform.getHorizontalSpeed();
            }
            else
            {
                isOnMoovingPlateform = false;

            }
        }*/


       
        distanceToTop = hitTop.distance;
        
        distanceToRight = hitRight.distance;
        
        distanceToLeft = hitLeft.distance;

        distanceToBottom = hitBottom.distance;

        float x = centerCheck.transform.position.x - leftCheck.transform.position.x ;  
        float y = centerCheck.transform.position.y - bottomCheck.transform.position.y;  
        
        if (hasObstacleBottom)
        {
            float offset = Mathf.Abs(y - distanceToBottom);
            transform.position += (new Vector3(0.0f, offset, 0));
        }
        
        if (hasObstacleRight)
        {
            float offset = Mathf.Abs(x - distanceToRight);
            this.transform.Translate(new Vector2(-offset, 0.0f));
        }

        if (hasObstacleLeft)
        {
            float offset = Mathf.Abs(x- distanceToLeft);
            this.transform.Translate(new Vector2(offset, 0.0f));
        }

        if (hasObstacleTop)
        {
            float offset = Mathf.Abs(y - distanceToTop);
            this.transform.Translate(new Vector2(0.0f, -offset));
        }

       
    }

}
