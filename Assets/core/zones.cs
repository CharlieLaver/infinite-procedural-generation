using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

class zones : MonoBehaviour {

	private string[] allZones;
	private GameObject[] zone;

	public void getAllZones() {
		this.allZones = Directory.GetDirectories(Application.dataPath + "/Resources/world");
	}
	
	public void randomZone() {
		string selectedZone = Path.GetFileNameWithoutExtension(this.allZones[UnityEngine.Random.Range(0, this.allZones.Length)]);
		string[] zoneResources = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/world/" + selectedZone));
		List<GameObject> randomBlocks = new List<GameObject>();
		for(int i = 0; i < zoneResources.Length; i++) {
			string randomBlockName = Path.GetFileNameWithoutExtension(zoneResources[UnityEngine.Random.Range(0, zoneResources.Length)]);
			GameObject randomGameObj = Resources.Load<GameObject>("world/" + selectedZone + "/" + randomBlockName);
			randomBlocks.Add(randomGameObj);
		}
		this.zone = randomBlocks.ToArray();
	}

	public GameObject selectBlock() {
		return this.zone[UnityEngine.Random.Range(0, this.zone.Length)];
	}

}