using UnityEngine;
using System.Collections;

public class Ooze : MonoBehaviour {
    public GameObject Player;
    public float moveSpeed = 0.2f;
    public float returnToPatrolSpeed = 0.1f;
    public int health = 5;
    public int damage = 10;
    public float rotationSpeed = 5.0f;
    public float range = 5.0f;
    public Vector3 patrolCenter;
    private Vector3 lastPos;
    private float resetAttackTimer = 1.0f; // 1 second
    // Use this for initialization
    void Start () {
        patrolCenter = transform.position;
    }

    // Update is called once per frame
    void Update () {
        // update reset attack timer
        resetAttackTimer -= Time.deltaTime;

        // destroy if no health
        if (health <= 0) {
            Destroy(this.gameObject);
        }

        Vector3 lookAtPos = Player.transform.GetComponent<Renderer>().bounds.center;
        lookAtPos.y = 0;
        // sense player
        if (isWithinRange(lookAtPos, range)) { // in range
            transform.LookAt(lookAtPos);
            transform.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
        } else { // not in range so patrol
            lookAtPos = transform.position;
            float speed = moveSpeed;
            if (!isWithinRange(patrolCenter, range)) { // back to patrol
                lookAtPos = patrolCenter;
                speed = returnToPatrolSpeed;
            } else { // random path in patrol area
                int dir = Random.Range(0, 4);
                if (dir == 0) { // right
                    lookAtPos = Vector3.right;
                } else if (dir == 1) { // back
                    lookAtPos = Vector3.back;
                } else if (dir == 2) { // left
                    lookAtPos = Vector3.left;
                } else if (dir == 3) { // forward
                    lookAtPos = Vector3.forward;
                }
            }
            lookAtPos.y = 0;
            transform.LookAt(lookAtPos);
            transform.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }

    bool isWithinRange(Vector3 pos, float range) {
        if (Mathf.Abs(pos.x - transform.position.x) > transform.GetComponent<Renderer>().bounds.size.x * range)
            return false;
        else if (Mathf.Abs(pos.y - transform.position.y) > transform.GetComponent<Renderer>().bounds.size.y * range)
            return false;
        else if (Mathf.Abs(pos.z - transform.position.z) > transform.GetComponent<Renderer>().bounds.size.z * range)
            return false;
        else
            return true;
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.Equals(Player.gameObject) && resetAttackTimer <= 0) { // do damage to player if colliding
            // should probably encapsulate this in player class
            ((Player)Player.gameObject.GetComponent(typeof(Player))).health -= damage;
            resetAttackTimer = 1.0f;
        }
    }
}
