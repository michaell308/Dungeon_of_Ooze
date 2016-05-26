using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public int dmg = 25; //damage done by fireball
    public AudioClip oozeHitSound;
    public AudioClip oozeDeathSound;
    int destroyTime = 10;
    void Update() {
        Invoke("destroyTimer", destroyTime); //destroys fireball after destroyTime seconds
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ooze") { //if fireball touches ooze
            ((Ooze)other.gameObject.GetComponent(typeof(Ooze))).health -= dmg; //oozes loses health
            if (((Ooze)other.gameObject.GetComponent(typeof(Ooze))).health == 0) { //if ooze is dead
                Destroy(other.gameObject); //destroy ooze
                GetComponent<AudioSource>().PlayOneShot(oozeDeathSound, 1);
            }
            GetComponent<AudioSource>().PlayOneShot(oozeHitSound, 1);
        }
        if (other.tag != "Player") { //fireball spawns in player, so only destroy if touches non-player object
            //disable collider and destroy particle effect so fireball "disappears", but sound still plays
            GetComponent<SphereCollider>().enabled = false; 
            Destroy(transform.GetChild(0).gameObject);
            Destroy(gameObject,oozeHitSound.length); //after sound plays, destroy object completely
        }
    }
    void destroyTimer() {
        Destroy(gameObject);
    }
}
