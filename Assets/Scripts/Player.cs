using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int health = 100;
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
    public Slider healthBarSlider;
    public Text gameOverText;
    public Text gameOverUnderText;
    public Image gameOverBackDrop;
    // Use this for initialization
    void Start () {
        gameOverText.enabled = false;
        gameOverUnderText.enabled = false;
        gameOverBackDrop.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        //scale healthbar
        healthBarSlider.value = health;

        // end game if needed
        if (health <= 0) {
            health = 0;
            gameOverScreenUpdate();
            return;
        }

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

    void gameOverScreenUpdate() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverText.enabled = true;
        gameOverUnderText.enabled = true;
        gameOverBackDrop.enabled = true;
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
