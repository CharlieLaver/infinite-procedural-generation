using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : weapon {

    private string weaponName = "shotgun";
    private float weaponPower = 4000;

    private void Start() {
        getFirePos();
    }

    private void Update() {
        shoot(weaponName, weaponPower);
    }
    
}