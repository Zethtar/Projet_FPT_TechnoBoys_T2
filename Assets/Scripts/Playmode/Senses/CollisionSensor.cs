using System.Collections;
using System.Collections.Generic;
using Playmode.Player;
using UnityEngine;

namespace Playmode.Senses
{
	public delegate void CollisionSensorEventHandler(PlayerController player);
	
	public class CollisionSensor : MonoBehaviour
	{
		public event CollisionSensorEventHandler OnCollision;

		public void CollideWith(PlayerController player)
		{
			NotifyCollision(player);
		}

		private void NotifyCollision(PlayerController player)
		{
			if(OnCollision != null)
				OnCollision.Invoke(player);
		}
	}
}


