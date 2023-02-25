using UnityEngine;
using System.Collections.Generic;

namespace Game.Enemies
{
	public abstract class ActiveEnemy : Enemy
	{
		
		[SerializeField] protected Transform playerRef;
		public abstract void Move(Transform target);

		

		public float MovementSpeed
		{
			get => movementSpeed; set => value = movementSpeed;
		}

	}
}
