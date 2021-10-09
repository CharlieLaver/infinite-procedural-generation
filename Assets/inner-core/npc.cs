using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {
    
    private Vector3 pos;

    public void move(Transform target, Transform currPos, float howClose, float speed) {
        float distToTarget = Vector3.Distance(target.position, currPos.position);
        float distToPos = Vector3.Distance(pos, currPos.position);
        if(distToPos < 5) {
            randomPos(currPos);
        }
        if(distToTarget <= howClose) {
            pos = target.position;
        }
        transform.LookAt(pos);
        transform.position = Vector3.MoveTowards(currPos.position, pos, speed * Time.deltaTime); 
    }   

    public void randomPos(Transform currPos) {
        float x = Random.Range((currPos.position.x - 30), (currPos.position.x + 30));
        float z = Random.Range((currPos.position.z - 30), (currPos.position.z + 30));
        pos = new Vector3(x, 5, z);
    } 

    public float damageCalculator(Collision collision, float health) {
        if (collision.relativeVelocity.magnitude > 100) {
            health -= 50;
        }
        else if (collision.relativeVelocity.magnitude > 60) {
            health -= 30;
        }
        else if (collision.relativeVelocity.magnitude > 40) {
            health -= 20;
        }
        else if (collision.relativeVelocity.magnitude > 20) {
            health -= 10;
        }
        return health;
    }

    public void die(int dropAmount, GameObject itemToDrop) {
        Destroy(gameObject);
        for (int i = 0; i < dropAmount; i++) {
            Instantiate(itemToDrop, transform.position, transform.rotation);
        }
    }

}