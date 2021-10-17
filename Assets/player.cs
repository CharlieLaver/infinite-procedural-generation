using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : inventory {

    private void Start(){
        projectileCountUI();
        gameObject.AddComponent<shotgun>();
    }

    private void Update() {
        pickUp();
    }

}