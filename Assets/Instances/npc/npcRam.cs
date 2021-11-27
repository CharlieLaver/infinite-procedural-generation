using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO -> ramPower method that makes the npcRam GO collide with the target when in certain dist
class npcRam : npc {

    private float health = 10;
	private float speed = 20;
	private Transform target;
    private string npcType = "npcRam";

    private void Start() {
        selectCharacteristics(this.npcType);        
		this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
		move(this.target, 10, this.speed, true);
        if(this.health < 0) {
            die(100, this.npcType);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        this.health = damageCalculator(collision, this.health);
    }

}