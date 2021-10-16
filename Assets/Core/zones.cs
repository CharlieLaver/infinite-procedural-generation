using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

class zones : MonoBehaviour {

	private string[] allZones;
	private string selectedZone;

	public void getAllZones() {
		this.allZones = Directory.GetDirectories(Application.dataPath + "/Resources/world");
	}
	
	public void randomZone() {
		this.selectedZone = Path.GetFileNameWithoutExtension(this.allZones[UnityEngine.Random.Range(0, this.allZones.Length)]);
	}

	public GameObject selectBlock() {
		string blockType = "common";
		int conditionalIndex = UnityEngine.Random.Range(0, 1000);
		if(conditionalIndex > 0 && conditionalIndex < 900) {
			blockType = "common";
		} else if(conditionalIndex > 900 && conditionalIndex < 998) {
			blockType = "infrequent";
		} else if(conditionalIndex > 998 && conditionalIndex < 1000) {
			blockType = "rare";
		}
		string[] blocks = helpers.filterMetaFiles(Directory.GetFiles(Application.dataPath + "/Resources/world/" + this.selectedZone + "/" + blockType));
		string randomBlock = Path.GetFileNameWithoutExtension(blocks[UnityEngine.Random.Range(0, blocks.Length)]);
		return Resources.Load<GameObject>("world/" + this.selectedZone + "/" + blockType + "/" + randomBlock);
	}

}