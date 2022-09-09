using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script is added to blocks from InfiniteProceduralGeneration
// Used to destroy block when it is out of range
public class DestroyBlock : MonoBehaviour
{
	
	private float howclose = 80f;

	private void Update()
	{
		float dist = Vector3.Distance(InfiniteProceduralGeneration.playerPos.position, transform.position);
		if(dist > howclose)
		{
			InfiniteProceduralGeneration.blockContainer.Remove(transform.position);
			Destroy(gameObject);
		}

	}

}