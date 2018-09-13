using System.Collections;
using System.Collections.Generic;
using Playmode.Player;
using UnityEngine;

namespace Playmode.Senses
{
	public class CollisionStimulus : MonoBehaviour
	{
		private PlayerController player;

		private void Awake()
		{
			player = transform.root.GetComponentInChildren<PlayerController>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			other.GetComponent<CollisionSensor>().CollideWith(player);
		}
	}
}


