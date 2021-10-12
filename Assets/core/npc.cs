using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class npc : MonoBehaviour {

    protected Vector3 pos; 

    protected void move(Transform target, float howClose, float speed, bool shouldAttack = false) {
        float distToTarget = Vector3.Distance(transform.position, target.position);
        float distToPos = Vector3.Distance(this.pos, transform.position);
        if(distToTarget <= howClose && shouldAttack) {
            if(distToPos < 5) {
                this.pos = transform.position;
            } else {
                this.pos = target.position;
            }
        } else if(distToPos < 5) {
            randomPos();
        }
        transform.LookAt(this.pos);
        transform.position = Vector3.MoveTowards(transform.position, this.pos, speed * Time.deltaTime);
    }   

    protected void randomPos() {
        float x = Random.Range((transform.position.x - 30), (transform.position.x + 30));
        float z = Random.Range((transform.position.z - 30), (transform.position.z + 30));
        this.pos = new Vector3(x, 5, z);
    } 

    protected float damageCalculator(Collision collision, float health) {
        if (collision.relativeVelocity.magnitude > 100) {
            health -= 50;
        }
        else if (collision.relativeVelocity.magnitude > 60) {
            health -= 30;
        }
        else if (collision.relativeVelocity.magnitude > 40) {
            health -= 20;
        }
        else if (collision.relativeVelocity.magnitude > 20) {
            health -= 10;
        }
        return health;
    }

    protected void die(int dropAmount, string npcType) {
        Destroy(gameObject);
        for (int i = 0; i < dropAmount; i++) {
            Instantiate(this.getRandomGameObj(npcType), transform.position, transform.rotation);
        }
    }

    protected GameObject getRandomGameObj(string npcType) {
        string[] gameObjResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/npc/" + npcType + "/gameObjects"));
        string randomGameObj = Path.GetFileNameWithoutExtension(gameObjResources[Random.Range(0, gameObjResources.Length)]);
        return Resources.Load<GameObject>("npc/" + npcType + "/gameObjects/" + randomGameObj);
    }
	protected void selectCharacteristics(string npcType) {
		string[] meshResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/npc/" + npcType + "/meshes"));
		string randomMesh = Path.GetFileNameWithoutExtension(meshResources[Random.Range(0, meshResources.Length)]);
		Mesh selectedMesh = Resources.Load<Mesh>("npc/" + npcType + "/meshes/" + randomMesh);
		gameObject.GetComponent<MeshFilter>().mesh = selectedMesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = selectedMesh;
		string[] matResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/npc/" + npcType + "/materials"));
		string randomMat = Path.GetFileNameWithoutExtension(matResources[Random.Range(0, matResources.Length)]);
		Material selectedMat = Resources.Load<Material>("npc/" + npcType + "/materials/" + randomMat);
		gameObject.GetComponent<Renderer>().material = selectedMat;
	}

}