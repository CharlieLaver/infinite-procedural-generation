using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class npcShoot : npc {

    private float health = 10;
	private float speed = 10;
	private Transform target;
    private string npcType = "npcShoot";
    private bool canShoot = true;
    private float shootRange = 10;

    public GameObject associatedObj;
    public Transform firePos;

    private void Start() {
        selectCharacteristics(this.npcType);        
		this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("randomPos", 2f, 5f);
    }

    private void Update() {
        this.powerShoot();
		move(this.target, 10, this.speed, true);
        if(this.health < 0) {
            die(100, this.npcType);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        this.health = damageCalculator(collision, this.health);
    }

    private void powerShoot() {
        float shootDelay = Random.Range(1, 5);
        float shootPower = Random.Range(1000, 4000);
        float distToPlayer = Vector3.Distance(target.position, transform.position);
        if (distToPlayer <= shootRange) {
            if (this.canShoot) {
                StartCoroutine(this.shootDelay(shootDelay, shootPower));
            }
        }
    }

    private IEnumerator shootDelay(float shootDelay, float shootPower) {
        GameObject projectile = Instantiate(associatedObj, firePos.position, firePos.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shootPower);
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

}