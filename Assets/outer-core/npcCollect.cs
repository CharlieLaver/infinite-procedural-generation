using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class npcCollect : npc {

    private float health = 100;
    private GameObject itemToDrop;

    private void Start() {
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
        if(health < 0) {
            die(100, itemToDrop);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        health = damageCalculator(collision, health);
    }

}