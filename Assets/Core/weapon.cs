using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class weapon : MonoBehaviour {
    
    protected Transform firePos;
	private GameObject projectile;
    private float weaponPower;
    private float shootDelay;
    private bool canShoot = true;

    protected void getFirePos() {
        firePos = GameObject.Find("firePos").transform;
    }

    protected void shoot() {
        if(Input.GetMouseButton(0) && this.canShoot && inventory.projectiles > 0) {
            StartCoroutine(fireRate());
        }
    }

	protected void changeWeapon() {
        if(Input.GetKeyDown(KeyCode.F1)) {
            this.weaponPower = Random.Range(1000, 9000);
            this.shootDelay = Random.Range(1, 20);
            this.projectile = this.selectProjectile();
        }
    }

	// doesn't currenlty work TODO
    protected IEnumerator fireRate() {
		Debug.Log(this.projectile);
        GameObject shot = Instantiate(this.projectile, this.firePos.position, this.firePos.rotation);
        shot.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * this.weaponPower);
        inventory.projectiles--;
        this.canShoot = false;
        yield return new WaitForSeconds(this.shootDelay);
        this.canShoot = true;
    }

    private GameObject selectProjectile() {
		string[] projectileResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/inventory/projectiles/"));
        string randomProjectile = Path.GetFileNameWithoutExtension(projectileResources[Random.Range(0, projectileResources.Length)]);
        GameObject projectileRes = Resources.Load<GameObject>("inventory/projectiles/" + randomProjectile);
		return projectileRes;
    }
}
