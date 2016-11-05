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
    Hunted victime;

    [SerializeField]
    float victimeViewDistance;

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
	
	// Update is called once per frame
	void Update () {
        testBonusVisibility();
	}

    void testBonusVisibility()
    {
        foreach(var item in bonus)
        {
            float distance = Vector3.Distance(item.transform.position, victime.transform.position);

            Debug.Log(distance);

            if (distance > victimeViewDistance)
                item.GetComponent<Renderer>().enabled = false;
            else
            {
                item.GetComponent<Renderer>().enabled = true;
            }

        }
    }
}
