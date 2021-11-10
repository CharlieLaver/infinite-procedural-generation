using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class weaponHolder : MonoBehaviour {
    
    public List<string> weaponInventory = new List<string>();

    // TODO:
    // public void pickUpWeapon(string weaponName) {
    //     if(weaponInventory.Count <= 4) {
    //         weaponInventory.Add(weaponName);
    //         for(int i = 0; i < weaponInventory.Count; i++) {
    //             if(gameObject.GetComponent(weaponInventory[i]) != null) {
    //                 UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Core/weaponHolder.cs (16,21)", weaponInventory[i]);
    //                 changeWeaponScript(weaponInventory.Count);
    //             }
    //         }
    //     }
    // }

    public void weaponSwitch() {
        if(Input.GetKeyDown(KeyCode.F1)) {
            Debug.Log("keypad1");
            changeWeaponScript(0);
        } else if(Input.GetKeyDown(KeyCode.F2)) {
            if(weaponInventory.ElementAtOrDefault(1) != null) {
                changeWeaponScript(1);
            }
        } else if(Input.GetKeyDown(KeyCode.F3)) {
            if(weaponInventory.ElementAtOrDefault(2) != null) {
                changeWeaponScript(2);
            }
        } else if(Input.GetKeyDown(KeyCode.F4)) {
            if(weaponInventory.ElementAtOrDefault(3) != null) {
                changeWeaponScript(3);
            }
        } else if(Input.GetKeyDown(KeyCode.F5)) {
            if(weaponInventory.ElementAtOrDefault(4) != null) {
                changeWeaponScript(4);
            }
        }
    }

    private void changeWeaponScript(int weaponIndex) {
        if(weaponInventory.ElementAtOrDefault(weaponIndex) != null) {
            for(int i = 0; i < weaponInventory.Count; i++) {
                if(weaponInventory[i] != weaponInventory[weaponIndex]) {
                    if(weaponInventory[i] != null) {
                        Debug.Log("disable " + weaponInventory[i]);
                    //    (GetComponent(weaponInventory[i]) as MonoBehaviour).enabled = false;
                    }
                } 
            }
            Debug.Log("enable " + weaponInventory[weaponIndex]);
            // (GetComponent(weaponInventory[weaponIndex]) as MonoBehaviour).enabled = false;
        }
    }

}
