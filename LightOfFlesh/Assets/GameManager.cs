using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum eventTypes { a,b}

public class GameManager : MonoBehaviour {

    private Queue<eventTypes> events;
    private List<GameObject> bonus;

    [SerializeField]
    GameObject test1;
    [SerializeField]
    GameObject test2;

    [SerializeField]
    Light torchLight;

    [SerializeField]
    Hunted victime;

    [SerializeField]
    Hunter hunter;

    [SerializeField]
    Camera hunterCam;

    [SerializeField]
    Camera huntedCam;

    [SerializeField]
    float victimeViewDistance;

    [SerializeField]
    float hunterViewDistance;

    public void addEvent(eventTypes newEvent)
    {
        events.Enqueue(newEvent);
    }

    // Use this for initialization
    void Start () {
        events = new Queue<eventTypes>();
        bonus = new List<GameObject>();

        bonus.Add(test1);
        bonus.Add(test2);

        foreach (var item in bonus)
        {
                item.GetComponent<Renderer>().enabled = false;

        }

    }
	
	void Update () {
        testBonusVisibility();

        testHunterVisibility();
	}

    void testBonusVisibility()
    {
        float lightX = Input.GetAxis("RSX");
        float lightY = Input.GetAxis("RSY");

        foreach (var item in bonus)
        {
            float distance = Vector3.Distance(item.transform.position, victime.transform.position);

            float itemX = item.transform.position.x - victime.transform.position.x;
            float itemY = item.transform.position.y - victime.transform.position.y;


            float angle = Vector2.Angle(new Vector2(lightX, lightY), new Vector2(itemX, itemY));

            if (distance < victimeViewDistance || (distance < torchLight.range -2 && angle < torchLight.spotAngle) )
                item.GetComponent<Renderer>().enabled = true;
            else
            {
                item.GetComponent<Renderer>().enabled = false;
            }

        }
    }

    void testHunterVisibility()
    {
        float lightX = Input.GetAxis("RSX");
        float lightY = Input.GetAxis("RSY");

        float distance = Vector3.Distance(hunter.transform.position, victime.transform.position);

        float hunterX = hunter.transform.position.x - victime.transform.position.x;
        float hunterY = hunter.transform.position.y - victime.transform.position.y;


        float angle = Vector2.Angle(new Vector2(lightX, lightY), new Vector2(hunterX, hunterY));

        if (distance < hunterViewDistance || (distance < torchLight.range - 2 && angle < torchLight.spotAngle))
        {
            
            torchLight.cullingMask = -1;
            huntedCam.cullingMask = -1;
        }
        else
        {
            torchLight.cullingMask = -513;
            huntedCam.cullingMask = -513;
        }

        if (distance < hunterViewDistance)
        {
            hunterCam.cullingMask = -257;
            
        }
        else
        {
            hunterCam.cullingMask = -258;
          
        }

    }
}
