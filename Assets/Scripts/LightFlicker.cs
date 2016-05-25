using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
    Light lightComp;
    float minIntensity = 3.0f;
    float maxIntensity = 8.0f;
    float offset = 6; //amount of flicker
	// Use this for initialization
	void Start () {
        lightComp = gameObject.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        float newIntensity = Mathf.Clamp(Random.Range(lightComp.intensity - offset, lightComp.intensity + offset),minIntensity, maxIntensity);
        lightComp.intensity = Mathf.Lerp(lightComp.intensity, newIntensity, Time.deltaTime*2);
    }
}
