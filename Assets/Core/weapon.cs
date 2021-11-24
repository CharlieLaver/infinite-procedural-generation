using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class weapon : MonoBehaviour {
    
    protected Transform firePos;
	protected GameObject projectile;
    private float weaponPower = 8000;
    private float shootDelay = 3;
    private bool canShoot = true;

    protected void getFirePos() {
        firePos = GameObject.Find("firePos").transform;
    }

    protected void shoot() {
        if(Input.GetMouseButton(0) && this.canShoot && inventory.projectiles > 0) {
            StartCoroutine(fireRate());
            inventory.projectiles--;
            inventory.projectileCount.text = inventory.projectiles.ToString();
        }
    }

	protected void changeWeapon() {
        if(Input.GetKeyDown(KeyCode.F1)) {
            // this.weaponPower = Random.Range(1000, 9000);
            // this.shootDelay = Random.Range(1, 20);
            this.projectile = this.selectProjectile();
        }
    }

    protected IEnumerator fireRate() {
        GameObject shot = Instantiate(this.projectile, this.firePos.position, this.firePos.rotation);
        shot.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * this.weaponPower);
        this.canShoot = false;
        yield return new WaitForSeconds(this.shootDelay);
        this.canShoot = true;
    }

    protected GameObject selectProjectile() {
		string[] projectileResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/inventory/projectiles/"));
        string randomProjectile = Path.GetFileNameWithoutExtension(projectileResources[Random.Range(0, projectileResources.Length)]);
        GameObject projectileRes = Resources.Load<GameObject>("inventory/projectiles/" + randomProjectile);
		return projectileRes;
    }
}
