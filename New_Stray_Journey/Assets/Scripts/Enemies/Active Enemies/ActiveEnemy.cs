using UnityEngine;
using System.Collections.Generic;

namespace Game.Enemies
{
	public abstract class ActiveEnemy : Enemy
	{
		
		[SerializeField] protected Transform playerRef;
		public abstract void Move(Transform target);

		protected virtual void Dropping(List<GameObject> droppedObjects)
		{
			//spawner de objetos aleatoriamente en un rango definido por cada enemigo
			for (int i =0; i< droppedObjects.Count; i++)
			{
				Instantiate(droppedObjects[i], transform.position, droppedObjects[i].transform.rotation);
			}
		}

		public float MovementSpeed
		{
			get => movementSpeed; set => value = movementSpeed;
		}

	}
}
