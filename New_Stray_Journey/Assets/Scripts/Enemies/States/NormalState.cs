using UnityEngine;

namespace Game.Enemies
{
	public class NormalState : State
	{
		public Enemy enemyRef;
		public SpecialAttackState specialAttackState;
		public PatrolState patrolState;
		public override State RunCurrentState()
		{
			if (enemyRef.specialReady)
			{
				return specialAttackState;
			}
			else if (enemyRef.GetComponent<Patroller>() != null)
			{
				return patrolState;
			}
			else
			{
				return this;

			}
		}
	}
}

