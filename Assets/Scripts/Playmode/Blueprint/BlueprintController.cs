using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Playmode.Player;
using Playmode.Senses; 
using UnityEngine;

namespace Playmode.Blueprint
{
	public class BlueprintController : MonoBehaviour
	{
		[SerializeField] private float speed;

		private CollisionSensor collisionSensor;

		private Stopwatch lifetime;
	
		// Use this for initialization
		private void Awake () 
		{
			collisionSensor = transform.root.GetComponentInChildren<CollisionSensor>();
		
			lifetime = new Stopwatch();
			lifetime.Start();
		
			if(speed <= 0)
				throw new ArgumentException("Speed is negative or null");
		}

		private void OnEnable()
		{
			collisionSensor.OnCollision += OnCollision;
		}

		private void OnDisable()
		{
			collisionSensor.OnCollision -= OnCollision;
		}

		// Update is called once per frame
		private void Update ()
		{
			Vector3 movement = Vector3.down * speed * Time.deltaTime; 
		
			transform.root.Translate(movement);

			if (lifetime.ElapsedMilliseconds > 15 * 1000)
			{
				Destroy(transform.root.gameObject);
			}
		}

		private void OnCollision(PlayerController player)
		{
			player.Unlock(this);
		
			Destroy(transform.root.gameObject);
		}
	}
}
