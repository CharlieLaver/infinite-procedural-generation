using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {
    
    private Vector3 pos;

    private void Start() {
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
        transform.LookAt(pos);
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }
    
    private void randomPos() {
        float x = Random.Range((transform.position.x - 30), (transform.position.x + 30));
        float z = Random.Range((transform.position.z - 30), (transform.position.z + 30));
        pos = new Vector3(x, 5, z);
    } 
}