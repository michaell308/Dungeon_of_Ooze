using UnityEngine;
using System.Collections;

public class FunnyOoze : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 0.2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        Vector3 lookAtPos = Player.transform.GetComponent<Renderer>().bounds.center;
        lookAtPos.y = transform.position.y;
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
    }
}