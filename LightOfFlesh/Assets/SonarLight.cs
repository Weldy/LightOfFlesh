using UnityEngine;
using System.Collections;

public class SonarLight : MonoBehaviour {

    Light sonar;

    private bool isActivated;
    private float timer;

	void Start () {
        sonar = GetComponent<Light>();
        sonar.range = 0;
        timer = 0;
        
    }
	
	// Update is called once per frame
	void Update () {

        if(isActivated )
        {
         
            if (timer < 1.5)
            {
                sonar.range = 2 * Mathf.Abs(Mathf.Cos(2*Time.fixedTime));
                sonar.intensity = 1.5f * Mathf.Abs(Mathf.Cos((Mathf.PI) / 2 + Time.fixedTime));
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                isActivated = false;
                sonar.range = 0;
            }
            
        }
        

    }

    public void startEffect()
    {
        isActivated = true;
    }
}
