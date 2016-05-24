using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public int dmg = 50;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ooze") {
            Debug.Log(((Ooze)other.gameObject.GetComponent(typeof(Ooze))).health);
            ((Ooze)other.gameObject.GetComponent(typeof(Ooze))).health -= dmg;
            if (((Ooze)other.gameObject.GetComponent(typeof(Ooze))).health == 0) {
                Destroy(other.gameObject);
            }
        }
        if (other.tag != "Player") {
            Destroy(gameObject);
        }
    }
}
