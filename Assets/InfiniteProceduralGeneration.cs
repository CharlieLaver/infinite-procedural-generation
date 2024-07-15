using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class InfiniteProceduralGeneration : MonoBehaviour
{
	
	[Serializable]
	public class Zone
	{
		public GameObject[] blocks;
		
		[Range(1, 6)]
		public int noiseHeight = 4;
	}
	
	public GameObject player;
	public static Transform playerPos;
	public int worldSize = 20;
	public Zone[] zones;
	
	public static Hashtable blockContainer = new Hashtable();
	
	private List<Vector3> blockPositions = new List<Vector3>();
	private Vector3 startPos;
	private Zone selectedZone;
	
	private void Start()
	{
		this.SelectZone();
		startPos = player.transform.position;
		playerPos = player.GetComponent<Transform>();
	}
	
	private void Update()
	{
		this.MeasurePlayerDis();
		for(int x = -worldSize; x < worldSize; x++)
		{
			for(int z = -worldSize; z < worldSize; z++)
			{
				Vector3 pos = new Vector3(x * 1 + this.XPlayerLocation, this.GenerateNoise(x + this.XPlayerLocation, z + ZPlayerLocation, 8f) * this.selectedZone.noiseHeight, z * 1 + this.ZPlayerLocation);
				if(!blockContainer.ContainsKey(pos))
				{
					GameObject block = Instantiate(this.SelectBlock(), pos, Quaternion.identity) as GameObject;
					blockContainer.Add(pos, block);
					blockPositions.Add(block.transform.position);
					block.transform.SetParent(this.transform);
				}
			}
		}
	}
	
	private void MeasurePlayerDis()
	{
		float distTravalledX = Math.Abs(player.transform.position.x - startPos.x);
		float distTravalledZ = Math.Abs(player.transform.position.z - startPos.z);
		if(Math.Round(distTravalledX) > 100 || Math.Round(distTravalledZ) > 100)
		{
			this.SelectZone();
			startPos = player.transform.position;
		}
	}
	
	private int XPlayerLocation
	{
		get
		{
			return (int)Mathf.Floor(player.transform.position.x);
		}
	}
	
	private int ZPlayerLocation
	{
		get
		{
			return (int)Mathf.Floor(player.transform.position.z);
		}
	}
	
	private float GenerateNoise(int x, int z, float detailScale)
	{
		float xNoise = (x + this.transform.position.x) / detailScale;
		float zNoise = (z + this.transform.position.z) / detailScale;
		return Mathf.PerlinNoise(xNoise, zNoise);
	}
	
	private void SelectZone()
	{
		this.selectedZone = this.zones[UnityEngine.Random.Range(0, this.zones.Length)];
	}
	
	private GameObject SelectBlock()
	{
		return this.selectedZone.blocks[UnityEngine.Random.Range(0, this.selectedZone.blocks.Length)];
	}
	
}