using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class npcCollect : npc {

    private float health = 1;
	private float speed = 10;
	private Transform target;
    private string npcType = "npcCollect";

    private void Start() {
        selectCharacteristics(this.npcType);        
		this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
		this.powerCollect(transform.position, this.speed);
		move(this.target, 10, this.speed);
        if(this.health < 0) {
            die(100, this.npcType);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        this.health = damageCalculator(collision, this.health);
    }

	private void powerCollect(Vector3 center, float radius) {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.GetComponent<Rigidbody>() != null && hitCollider.name != this.name && hitCollider.tag != "Player") {
                float distToPos = Vector3.Distance(hitCollider.transform.position, transform.position);
                if (distToPos < 3) {
                    Destroy(hitCollider.gameObject);
                }
            }
        }
    }

}