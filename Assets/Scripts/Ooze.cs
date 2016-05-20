using UnityEngine;
using System.Collections;

public class Ooze : MonoBehaviour {
    public GameObject Player;
    public float moveSpeed = 0.2f;
    public int health = 5;
    public float rotationSpeed = 5.0f;
	// Use this for initialization
	void Start () {
       // transform.rotation = new Quaternion(45, 0, 0, 0);

    }

    // Update is called once per frame
    void Update () {
        Vector3 lookAtPos = Player.transform.position;
        lookAtPos.y = transform.position.y;
        transform.LookAt(lookAtPos);
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
    }
}
