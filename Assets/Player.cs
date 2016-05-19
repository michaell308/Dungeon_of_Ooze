using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float mouseSensitivity = 5.0f;
    public float moveLR = 0; //move left/right
    public float moveFB = 0; //move forwards/backwards
    public float turnLR = 0; //turn left/right
    public float turnUD = 0; //turn up/down
    public float limitUD = 70.0f; //limit how far player can look up or down
    public float vertVel = 0.0f; //vertical velocity for gravity
    public float jumpSpeed = 6.0f;
    CharacterController cc;
    // Use this for initialization
    void Start () {
        //Screen.loc
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        //get all input
        getInput();

        //Rotate
        transform.Rotate(0, turnLR, 0);
        turnUD = Mathf.Clamp(turnUD, -limitUD, limitUD);
        Camera.main.transform.localRotation = Quaternion.Euler(turnUD, 0, 0);

        //Movement
        vertVel += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            vertVel = jumpSpeed;
        }
        Vector3 speed = new Vector3(moveLR, vertVel, moveFB);
        cc.Move(transform.rotation * speed * Time.deltaTime);
	}
    void getInput() {
        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;
        turnLR = Input.GetAxis("Mouse X") * mouseSensitivity;
        turnUD -= Input.GetAxis("Mouse Y") * mouseSensitivity;
    }
    void FixedUpdate() {
        //Run();
    }
}
