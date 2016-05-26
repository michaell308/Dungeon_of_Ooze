using UnityEngine;
using System.Collections;

public class ShootFireball : MonoBehaviour {
    public GameObject fireballPrefab;
    public GameObject arm;
    public float fireballSpeed = 13.0f;
    public AudioSource audioS;
    public AudioClip fireballSound;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1")) { //if mouse click
            GameObject fireball = (GameObject)Instantiate(fireballPrefab, arm.transform.position, arm.transform.rotation); //make fireball
            fireball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * fireballSpeed, ForceMode.Impulse); //shoot forward
            audioS.PlayOneShot(fireballSound, 1); //play fireball sound
        }
    }
}
