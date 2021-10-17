using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class weapon : MonoBehaviour {
    
    protected Transform firePos;

    protected void getFirePos() {
        firePos = GameObject.Find("firePos").transform;
    }

    protected void shoot(string weaponName, float weaponPower) {
        if(Input.GetMouseButtonDown(0)) {
            if(inventory.projectiles > 0) {
                string[] projectileResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/inventory/projectiles/" + weaponName));
                string randomProjectile = Path.GetFileNameWithoutExtension(projectileResources[Random.Range(0, projectileResources.Length)]);
                GameObject projectile = Resources.Load<GameObject>("inventory/projectiles/" + weaponName + "/" + randomProjectile);
                GameObject shot = Instantiate(projectile, firePos.position, firePos.rotation);
                shot.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * weaponPower);
                inventory.projectiles--;
            }
        }
    }

}
