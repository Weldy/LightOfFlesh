using UnityEngine;
using System.Collections;

public class SonarLight : MonoBehaviour {

    Light sonar;

	void Start () {
        sonar = GetComponent<Light>();
        sonar.range = 0;
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void startEffect()
    {
        float timer = 0;
        while(timer < 3)
        {
            sonar.range = 3 * Mathf.Abs(Mathf.Cos(Time.fixedTime));
            sonar.intensity = 2 * Mathf.Abs(Mathf.Cos((Mathf.PI) / 2 + Time.fixedTime));
            timer += Time.deltaTime;
        }

        sonar.range = 0;
    }
}
