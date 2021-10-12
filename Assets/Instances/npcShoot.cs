using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class npcShoot : npc {
    
    public Transform firePos;
    private float health = 10;
	private float speed = 10;
	private Transform target;
    private string npcType = "npcShoot";
    private bool canShoot = true;
    private float shootRange = 10;
    private GameObject projectile; 

    private void Start() {
        selectCharacteristics(this.npcType);        
		this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("randomPos", 2f, 5f);
        this.projectile = getRandomGameObj(this.npcType); 
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
        float distToPlayer = Vector3.Distance(this.target.position, transform.position);
        if (distToPlayer <= shootRange) {
            if (this.canShoot) {
                StartCoroutine(this.shootDelay(2, 5000));
            }
        }
    }

    private IEnumerator shootDelay(float shootDelay, float shootPower) {
        GameObject projectile = Instantiate(this.projectile, firePos.position, firePos.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shootPower);
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

}