using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : inventory {

    private void Start(){
        projectileCountUI();
        gameObject.AddComponent<sniperGun>();
    }

    private void Update() {
        pickUp();
    }

}