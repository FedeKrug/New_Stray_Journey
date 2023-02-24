using UnityEngine;

namespace Game.Enemies
{
	public abstract class Trap : Obstacle
	{
		protected override void ConstantMove() //move around waypoints
		{
			base.ConstantMove();
		}
		protected override void Attack()
		{
			base.Attack();

		}
	}
}
