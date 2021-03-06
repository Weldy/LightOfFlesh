﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum eventTypes { a, b }

public class GameManager : MonoBehaviour
{

    private Queue<eventTypes> events;
    private List<GameObject> items;

    [SerializeField]
    string destination;

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

    [SerializeField]
    float looseDistance;

    [SerializeField]
    AudioClip sound;

    [SerializeField]
    float cooldown;

    float cooldownCounter;

    [SerializeField]
    GameObject bloodStains;

    public void addEvent(eventTypes newEvent)
    {
        events.Enqueue(newEvent);
    }

    // Use this for initialization
    void Start()
    {
        events = new Queue<eventTypes>();
        cooldownCounter = cooldown;

    }

    public void preStart()
    {
        items = new List<GameObject>();

    }
    public void initialize()
    {
        foreach (var item in items)
        {
            item.GetComponent<Renderer>().enabled = false;

        }
    }

    void Update()
    {
        if (victime.isBleeding)
        {
            create(bloodStains, victime.transform.localPosition);
        }
        testBonusVisibility();

        testHunterVisibility();
    }

    public void create(GameObject objectToCreate, Vector3 position)
    {
        GameObject obj = (GameObject)Instantiate(objectToCreate, position, Quaternion.identity);

        items.Add(obj);

    }
    void testBonusVisibility()
    {
        float lightX = Input.GetAxis("RSX");
        float lightY = Input.GetAxis("RSY");


        foreach (var item in items)
        {
            if (item != null)
            {
                float distance = Vector3.Distance(item.transform.position, victime.transform.position);

                float itemX = item.transform.position.x - victime.transform.position.x;
                float itemY = item.transform.position.y - victime.transform.position.y;


                float angle = Vector2.Angle(new Vector2(lightX, lightY), new Vector2(itemX, itemY));

                if (distance < victimeViewDistance || (distance < torchLight.range - 2 && angle < torchLight.spotAngle))
                    item.GetComponent<Renderer>().enabled = true;
                else
                {
                    item.GetComponent<Renderer>().enabled = false;
                }

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
            if (cooldownCounter < 0)
            {
                AudioSource source = victime.GetComponent<AudioSource>();
                source.PlayOneShot(sound, 1-distance/hunterViewDistance);
                cooldownCounter =cooldown;
            }
        }
        else
        {
            hunterCam.cullingMask = -258;

        }
        cooldownCounter -= Time.deltaTime;
        if (distance < looseDistance)
        {
            Debug.Log("LOSE");
            SceneManager.LoadScene(destination);
        }
        

    }
}