using UnityEngine;

namespace Game.Enemies
{
	public class Obstacle : PassiveEnemy
	{
		public override void Death(EnemyHealth enemyHealth)
		{
			//Destroyed Obstacle
		}

		protected override void Attack()
		{
			//Idle Damage if it has 
		}

		protected override void SpecialAttack()
		{
			//Damage with the obstacle destruction
		}
	}
}
