using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class npcCollect : npc {

    private float health = 100;
    private GameObject itemToDrop;
	private Transform target;

    private void Start() {
		selectCharacteristics("npcCollect");
		this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
		move(this.target, 10, 5);
        if(this.health < 0) {
            die(100, this.itemToDrop);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        health = damageCalculator(collision, this.health);
    }

}