using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : weapon {

    private string weaponName = "shotGun";
    private float weaponPower = 4000;
    private float fireRate = 1;

    private void Start() {
        getFirePos();
    }

    private void Update() {
        shoot(weaponName, weaponPower, fireRate);
    }

}