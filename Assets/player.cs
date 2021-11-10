using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : inventory {

    private void Start(){
        projectileCountUI();
        // JUST FOR TEST (weaponHolder needs to be finished)
        // gameObject.AddComponent<sniperGun>().enabled = false;
        // gameObject.AddComponent<shotGun>().enabled = true;
        weaponHolder.weaponInventory.Add("sniperGun");
        weaponHolder.weaponInventory.Add("shotGun");
    }

    private void Update() {
        pickUp();
        weaponHolder.weaponSwitch();
    }

}