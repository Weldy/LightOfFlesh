using UnityEngine;
using System.Collections;

public class CollisionEngine : MonoBehaviour
{

    private bool hasObstacleTop;
    private bool hasObstacleRight;
    private bool hasObstacleLeft;
    private bool hasObstacleBottom;

    [SerializeField]
    private Hunted victime;

    [SerializeField]
    private bool pasUneVictime;

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
        
    }

    void LateUpdate()
    {

        hasObstacleTop = Physics.Linecast(centerCheck.position, topCheck.position, out hitTop, 1 << 0);
        hasObstacleRight = Physics.Linecast(centerCheck.position, rightCheck.position, out hitRight, 1 << 0);
        hasObstacleLeft = Physics.Linecast(centerCheck.position, leftCheck.position, out hitLeft, 1 << 0);
        
        hasObstacleBottom = Physics.Linecast(centerCheck.position, bottomCheck.position, out hitBottom, 1 << 0);

        bool colliding = false;

        if (hitBottom.collider != null)
        {

            Item item = hitBottom.collider.GetComponent<Item>();
            if (item)
            {
                
                if (item.itemType == ItemType.Trap && !pasUneVictime)
                {
                   
                    Trap trap = (Trap)item;
                    trap.Activate(victime, victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Bonus && !pasUneVictime)
                {
                    Bonus bonus = (Bonus)item;
                    bonus.PickUpBonus(victime, victime.GetComponent<AudioSource>());
                }


                if (item.itemType == ItemType.Key && !pasUneVictime)
                {
                    Key key = (Key)item;
                    key.keyCollide(victime, victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Door && !pasUneVictime)
                {
                    Door door = (Door)item;

                    door.doorCollide(victime, victime.GetComponent<AudioSource>());
                }
                if (item.itemType == ItemType.Obstacle)
                {
                    colliding = true;
                }
                
            }
           
          
        }

        if (hitTop.collider != null)
        {


            Item item = hitTop.collider.GetComponent<Item>();
            if (item)
            {
                if (item.itemType == ItemType.Trap && !pasUneVictime)
                {
                    Trap trap = (Trap)item;
                    trap.Activate(victime,  victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Bonus && !pasUneVictime)
                {
                    Bonus bonus = (Bonus)item;
                    bonus.PickUpBonus(victime, victime.GetComponent<AudioSource>());
                }


                if (item.itemType == ItemType.Key && !pasUneVictime)
                {
                    Key key = (Key)item;
                    key.keyCollide(victime, victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Door && !pasUneVictime)
                {
                    Door door = (Door)item;

                    door.doorCollide(victime, victime.GetComponent<AudioSource>());
                }
                if (item.itemType == ItemType.Obstacle)
                {
                    colliding = true;
                }
            }
            
        }

        if (hitLeft.collider != null)
        {


            Item item = hitLeft.collider.GetComponent<Item>();
            if (item)
            {
                if (item.itemType == ItemType.Trap && !pasUneVictime)
                {
                    Trap trap = (Trap)item;
                    trap.Activate(victime,  victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Bonus && !pasUneVictime)
                {
                    Bonus bonus = (Bonus)item;
                    bonus.PickUpBonus(victime, victime.GetComponent<AudioSource>());
                }


                if (item.itemType == ItemType.Key && !pasUneVictime)
                {
                    Key key = (Key)item;
                    key.keyCollide(victime, victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Door && !pasUneVictime)
                {
                    Door door = (Door)item;

                    if (!door.isOpen)
                        colliding = true;
                    door.doorCollide(victime, victime.GetComponent<AudioSource>());
                }
                if (item.itemType == ItemType.Obstacle)
                {
                    colliding = true;
                }
            }

            
        }

        if (hitRight.collider != null)
        {


            Item item = hitRight.collider.GetComponent<Item>();
            if (item)
            {
                if (item.itemType == ItemType.Trap && !pasUneVictime)
                {
                    Trap trap = (Trap)item;
                    trap.Activate(victime,  victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Bonus && !pasUneVictime)
                {
                    Bonus bonus = (Bonus)item;
                    bonus.PickUpBonus(victime, victime.GetComponent<AudioSource>());
                }


                if (item.itemType == ItemType.Key && !pasUneVictime)
                {
                    Key key = (Key)item;
                    key.keyCollide(victime, victime.GetComponent<AudioSource>());

                }
                if (item.itemType == ItemType.Door && !pasUneVictime)
                {
                    Door door = (Door)item;

                    door.doorCollide(victime, victime.GetComponent<AudioSource>());
                }
                if (item.itemType == ItemType.Obstacle)
                {
                    colliding = true;
                }
            }
            
        }



        if (colliding)
        {

            distanceToTop = hitTop.distance;

            distanceToRight = hitRight.distance;

            distanceToLeft = hitLeft.distance;

            distanceToBottom = hitBottom.distance;

            float x = centerCheck.transform.position.x - leftCheck.transform.position.x;
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
                float offset = Mathf.Abs(x - distanceToLeft);
                this.transform.Translate(new Vector2(offset, 0.0f));
            }

            if (hasObstacleTop)
            {
                float offset = Mathf.Abs(y - distanceToTop);
                this.transform.Translate(new Vector2(0.0f, -offset));
            }
        }

    }

}
