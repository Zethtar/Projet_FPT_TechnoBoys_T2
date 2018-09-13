using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Playmode.Blueprint.Spawner
{
	public class SpawnPointController : MonoBehaviour
	{

		[SerializeField] private GameObject objectPrefab;
		[SerializeField] private float spawnDelaySeconds;

		private float leftWorldBound;
		private float rightWorldBound;

		private void Awake()
		{
			if(objectPrefab == null)
				throw new ArgumentException("Null obj prefab : No spawn");
			if(spawnDelaySeconds <= 0)
				throw new ArgumentException("Spawn time must be valid : no infinite spawn");

			leftWorldBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
			rightWorldBound = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
		}

		private IEnumerator SpawnRandomObjectRoutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(spawnDelaySeconds);
				SpawnRandomObject();
			}
		}

		private void SpawnRandomObject()
		{
			Vector3 newPosition = gameObject.transform.position;
			newPosition.x = GetRandomXPositionInBounds();

			Instantiate(objectPrefab, newPosition, Quaternion.identity);
		}

		private float GetRandomXPositionInBounds()
		{	
			return Random.Range(leftWorldBound, rightWorldBound);
		}

		private void OnEnable()
		{
			StartCoroutine(SpawnRandomObjectRoutine());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}
