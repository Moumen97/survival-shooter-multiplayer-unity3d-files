﻿using UnityEngine;
using System.Collections.Generic;

public class PickupItemManager : MonoBehaviour
{

	public string prefabName;
	public int maxCount;
	public float respawnDelay;
	public float initialDelay;
	
	List<GameObject> itemInstances = new List<GameObject> ();
	
	void OnRoundStarted ()
	{
		InvokeRepeating ("SpawnItem", initialDelay, respawnDelay);
	}
	
	void OnPauseStarted ()
	{
		CancelInvoke ("SpawnItem");
	}
	
	void SpawnItem ()
	{
		Debug.Log ("spawning item");
		if (itemInstances.Count >= maxCount) {
			return;
		}
		PositionData randomTransform = PositionHelper.GetRandomSpawnPosition ();
		PhotonNetwork.Instantiate (prefabName, randomTransform.position, randomTransform.rotation, 0);
	}
}
