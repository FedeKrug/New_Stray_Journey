using UnityEngine;
using System.Collections.Generic;

namespace Game.Enemies
{
	public abstract class ActiveEnemy : Enemy
	{
		[SerializeField] protected float movementSpeed;
		[SerializeField] protected Transform playerRef;
		public abstract void Move(Transform target);

		protected virtual void Dropping(List<GameObject> droppedObjects)
		{
			//spawner de objetos aleatoriamente en un rango definido por cada enemigo
		}



	}
}
