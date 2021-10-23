using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperGun : weapon {

    private string weaponName = "sniperGun";
    private float weaponPower = 8000;
    private float fireRate = 5;

    private void Start() {
        getFirePos();
    }

    private void Update() {
        shoot(weaponName, weaponPower, fireRate);
    }

}