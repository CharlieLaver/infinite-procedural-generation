using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* add script to every prefab -> destroys the gameObj is too far away from player */
public class destroyGameObj : MonoBehaviour {
    private Transform target;
    private float dist;
    private float howclose = 80f;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        dist = Vector3.Distance(target.position, transform.position);
        if(dist > howclose) {
            InfiniteProceduralGeneration.blockContainer.Remove(transform.position);
            Destroy(gameObject);
        }

    }
}
