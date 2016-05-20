using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public GameObject fireballPrefab;
    public GameObject arm;
    public float fireballSpeed = 70.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1")) {
            GameObject fireball = (GameObject)Instantiate(fireballPrefab, arm.transform.position, arm.transform.rotation);
            fireball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * fireballSpeed, ForceMode.Impulse);
        }
	}
}
