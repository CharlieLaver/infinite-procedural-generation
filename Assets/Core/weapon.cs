using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class weapon : MonoBehaviour {
    
    protected Transform firePos;
    private bool canShoot = true;

    protected void getFirePos() {
        firePos = GameObject.Find("firePos").transform;
    }

    protected void shoot(string weaponName, float weaponPower, float shootDelay) {
        if(Input.GetMouseButton(0) && this.canShoot && inventory.projectiles > 0) {
            StartCoroutine(fireRate(weaponName, weaponPower, shootDelay));
        }
    }

    protected IEnumerator fireRate(string weaponName, float weaponPower, float shootDelay) {
        string[] projectileResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/inventory/projectiles/" + weaponName));
        string randomProjectile = Path.GetFileNameWithoutExtension(projectileResources[Random.Range(0, projectileResources.Length)]);
        GameObject projectile = Resources.Load<GameObject>("inventory/projectiles/" + weaponName + "/" + randomProjectile);
        GameObject shot = Instantiate(projectile, firePos.position, firePos.rotation);
        shot.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * weaponPower);
        inventory.projectiles--;        
        this.canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        this.canShoot = true;
    }

}
