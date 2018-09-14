using System;
using System.Collections;
using System.Collections.Generic;
using Playmode.Blueprint;
using UnityEngine;

namespace Playmode.Player
{
	public class PlayerController : MonoBehaviour {

		[SerializeField] private float speed;
		// Use this for initialization
		void Awake () 
		{
			if(speed <= 0)
				throw new ArgumentException("Negative speed");
		}
	
		// Update is called once per frame
		void Update ()
		{
			Vector3 movement = Vector3.zero; 
		
			if(Input.GetKey(KeyCode.RightArrow))
				movement += Vector3.right;
		
			if(Input.GetKey(KeyCode.LeftArrow))
				movement += Vector3.left;
		
			if(Input.GetKey(KeyCode.UpArrow))
				movement += Vector3.up;
		
			if(Input.GetKey(KeyCode.DownArrow))
				movement += Vector3.down;

			if (Input.GetKey(KeyCode.Space))
				movement *= 1.5f;

			movement *= speed * Time.deltaTime;
		
			transform.root.Translate(movement);
		}

		public void Unlock(BlueprintController blueprint)
		{
			
		}
	}
}


