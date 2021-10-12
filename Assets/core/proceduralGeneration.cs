using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class proceduralGeneration : MonoBehaviour {

	public static Hashtable blockContainer = new Hashtable();
    private List<Vector3> blockPositions = new List<Vector3>();
	private zones zoneService = new zones();
	private Vector3 startPos;
	private GameObject player;
	private bool loadSceneOnStart = true;
	private int worldSizeX = 40;
    private int worldSizeZ = 40;
    private int noiseHeight = 4;

	protected void proceduralGenerationInit() {
		player = GameObject.FindGameObjectWithTag("Player");
		startPos = player.transform.position;
		this.zoneService.getAllZones();
		this.zoneService.randomZone();
	}

    protected void infiniteProceduralGeneration() {
        measurePlayerDis();
        if (Mathf.Abs(xPlayerMove) >= 1 || Mathf.Abs(zPlayerMove) >= 1 || loadSceneOnStart) {
            for (int x = -worldSizeX; x < worldSizeX; x++) {
                for (int z = -worldSizeZ; z < worldSizeZ; z++) {
                    Vector3 pos = new Vector3(x * 1 + xPlayerLocation, generateNoise(x + xPlayerLocation, z + zPlayerLocation, 8f) * noiseHeight, z * 1 + zPlayerLocation);
                    if (!blockContainer.ContainsKey(pos)) {
                        GameObject block = Instantiate(zoneService.selectBlock(), pos, Quaternion.identity) as GameObject;
                        blockContainer.Add(pos, block);
                        blockPositions.Add(block.transform.position);
                        block.transform.SetParent(this.transform);
                    }
                }
            }
        }
    }

    private void measurePlayerDis() {
        float distTravalledX = Math.Abs(player.transform.position.x - startPos.x);
        float distTravalledZ = Math.Abs(player.transform.position.z - startPos.z);
        if (Math.Round(distTravalledX) > 100 || Math.Round(distTravalledZ) > 100) {
            this.zoneService.randomZone();
            startPos = player.transform.position;
        }
    }

    private int xPlayerMove {
        get {
            return (int)(player.transform.position.x - startPos.x);
        }
    }

    private int zPlayerMove {
		get {
			return (int)(player.transform.position.z - startPos.z);
		}
    }

	private int xPlayerLocation {
        get {
            return (int)Mathf.Floor(player.transform.position.x);
        }
    }

    private int zPlayerLocation {
        get {
            return (int)Mathf.Floor(player.transform.position.z);
        }
    }

	private float generateNoise(int x, int z, float detailScale) {
        float xNoise = (x + this.transform.position.x) / detailScale;
        float zNoise = (z + this.transform.position.z) / detailScale;
        return Mathf.PerlinNoise(xNoise, zNoise);
    }

}