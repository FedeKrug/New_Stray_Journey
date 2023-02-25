using System;

using UnityEngine;

using static UnityEngine.GraphicsBuffer;

namespace Game.Enemies
{
	public abstract class Trap : Obstacle
	{
		[SerializeField] private Transform _wayPointTarget;

		protected override void ConstantMove() //move around waypoints
		{
			base.ConstantMove();
		}
		protected override void Attack()
		{
			base.Attack();
			//TODO: Trap Special 
		}


		public void Patrol()
		{
			LookAtTarget(_wayPointTarget);
			transform.Translate(-Vector2.up * movementSpeed * Time.deltaTime);
		}

		private void LookAtTarget(Transform wayPointTarget)
{
			this.transform.up = transform.position - _wayPointTarget.position;
		}
	}
}
