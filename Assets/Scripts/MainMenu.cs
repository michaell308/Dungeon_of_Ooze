using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("scene1");
    }
}
