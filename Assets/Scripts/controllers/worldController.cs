using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class worldController : MonoBehaviour
{
    //when adding new zone create new arr below and amend selectZone()
    public GameObject[] zone1Arr;
    public GameObject[] zone2Arr;
    public GameObject[] zone3Arr;
    public GameObject player;

    int worldSizeX = 40;
    int worldSizeZ = 40;
    int noiseHeight = 4;
    Vector3 startPosition;
    public static Hashtable blockContainer = new Hashtable();
    List<Vector3> blockPositions = new List<Vector3>();
    GameObject objectToSpawn;
    bool loadSceneOnStart = true;
    GameObject[] blocks = new GameObject[20];
    Vector3 startPos;
    zones testZone = new zones();

    void Start()
    {
        startPos = player.transform.position;
        selectZone();
        testZone.getAllZones();
        testZone.randomZone();
    }

    void Update()
    {
        measurePlayerDis();
        if (Mathf.Abs(xPlayerMove) >= 1 || Mathf.Abs(zPlayerMove) >= 1 || loadSceneOnStart)
        {
            for (int x = -worldSizeX; x < worldSizeX; x++)
            {
                for (int z = -worldSizeZ; z < worldSizeZ; z++)
                {
                    Vector3 pos = new Vector3(x * 1 + xPlayerLocation,
                    generateNoise(x + xPlayerLocation, z + zPlayerLocation, 8f) * noiseHeight,
                    z * 1 + zPlayerLocation);

                    if (!blockContainer.ContainsKey(pos))
                    {
                        selectBlocks();
                        GameObject block = Instantiate(objectToSpawn,
                        pos,
                        Quaternion.identity) as GameObject;
                        blockContainer.Add(pos, block);
                        blockPositions.Add(block.transform.position);
                        block.transform.SetParent(this.transform);
                    }
                }
            }
        }
    }

    int xPlayerMove
    {
        get
        {
            return (int)(player.transform.position.x - startPosition.x);
        }
    }

    int zPlayerMove
    {
        get
        {
            return (int)(player.transform.position.z - startPosition.z);
        }
    }

    // calls selectZone() when the player has moved a certain dist
    void measurePlayerDis()
    {
        float distTravalledX = Math.Abs(player.transform.position.x - startPos.x);
        float distTravalledZ = Math.Abs(player.transform.position.z - startPos.z);

        if (Math.Round(distTravalledX) > 100 || Math.Round(distTravalledZ) > 100)
        {
            selectZone();
            startPos = player.transform.position;
        }
    }

    int xPlayerLocation
    {
        get
        {
            return (int)Mathf.Floor(player.transform.position.x);
        }
    }

    int zPlayerLocation
    {
        get
        {
            return (int)Mathf.Floor(player.transform.position.z);
        }
    }

    // creates the terrain height
    float generateNoise(int x, int z, float detailScale)
    {
        float xNoise = (x + this.transform.position.x) / detailScale;
        float zNoise = (z + this.transform.position.z) / detailScale;
        return Mathf.PerlinNoise(xNoise, zNoise);
    }

    // assigns all the selected zone blocks to the zone that is being rendered
    void zones(GameObject[] zoneArr)
    {
        for (int i = 0; i < zoneArr.Length; i++)
        {
            blocks[i] = zoneArr[i];
        }
    }

    // Randomly selects a zone
    void selectZone()
    {
        float changeZoneNum = UnityEngine.Random.Range(0f, 30f);

        if (changeZoneNum > 0 && changeZoneNum < 10)
        {
            zones(zone1Arr);
        }
        else if (changeZoneNum > 10 && changeZoneNum < 20)
        {
            zones(zone2Arr);
        }
        else if (changeZoneNum > 20 && changeZoneNum < 30)
        {
            zones(zone3Arr);
        }
    }

    // selects blocks based on conditional probability and assigns it as the current objectToSpawn when the terrain is being generated
    void selectBlocks()
    {
        float randomSpawnNum = UnityEngine.Random.Range(0f, 50f);

        // very rare
        if (randomSpawnNum < 0.001f && randomSpawnNum > 0f)
        {
            objectToSpawn = blocks[0];
        }
        // rare
        else if (randomSpawnNum < 0.01f && randomSpawnNum > 0.001f)
        {
            objectToSpawn = blocks[1];
        }
        else if (randomSpawnNum < 0.02f && randomSpawnNum > 0.01f)
        {
            objectToSpawn = blocks[2];
        }
        // uncommon
        else if (randomSpawnNum < 0.1f && randomSpawnNum > 0.02f)
        {
            objectToSpawn = blocks[3];
        }
        else if (randomSpawnNum < 0.2f && randomSpawnNum > 0.1f)
        {
            objectToSpawn = blocks[4];
        }
        else if (randomSpawnNum < 0.3f && randomSpawnNum > 0.2f)
        {
            objectToSpawn = blocks[5];
        }
        else if (randomSpawnNum < 0.4f && randomSpawnNum > 0.3f)
        {
            objectToSpawn = blocks[6];
        }
        else if (randomSpawnNum < 0.5f && randomSpawnNum > 0.4f)
        {
            objectToSpawn = blocks[7];
        }
        // common
        else if (randomSpawnNum < 1f && randomSpawnNum > 0.5f)
        {
            objectToSpawn = blocks[8];
        }
        else if (randomSpawnNum < 2f && randomSpawnNum > 1f)
        {
            objectToSpawn = blocks[9];
        }
        else if (randomSpawnNum < 3f && randomSpawnNum > 2f)
        {
            objectToSpawn = blocks[10];
        }
        else if (randomSpawnNum < 4f && randomSpawnNum > 3f)
        {
            objectToSpawn = blocks[12];
        }
        else if (randomSpawnNum < 5f && randomSpawnNum > 4f)
        {
            objectToSpawn = blocks[13];
        }
        // very common
        else if (randomSpawnNum < 10f && randomSpawnNum > 5f)
        {
            objectToSpawn = blocks[14];
        }
        else if (randomSpawnNum < 15f && randomSpawnNum > 10f)
        {
            objectToSpawn = blocks[15];
        }
        else if (randomSpawnNum < 20f && randomSpawnNum > 15f)
        {
            objectToSpawn = blocks[16];
        }
        // very very common
        else if (randomSpawnNum < 30f && randomSpawnNum > 20f)
        {
            objectToSpawn = blocks[17];
        }
        else if (randomSpawnNum < 40f && randomSpawnNum > 30f)
        {
            objectToSpawn = blocks[18];
        }
        else if (randomSpawnNum < 50f && randomSpawnNum > 40f)
        {
            objectToSpawn = blocks[19];
        }
    }
}
