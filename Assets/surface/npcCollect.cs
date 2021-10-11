using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class npcCollect : npc {

    private float health = 1;
	private Transform target;
    private string npcType = "npcCollect";

    private void Start() {
        selectCharacteristics(this.npcType);        
		this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
		move(this.target, 10, 5);
        if(this.health < 0) {
            die(100, this.npcType);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        this.health = damageCalculator(collision, this.health);
    }

}