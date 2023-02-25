using UnityEngine;

namespace Game.Enemies
{
	public class PatrolState : State
	{
		[SerializeField] private NormalState _normalState;
		[SerializeField] private SpecialAttackState _specialAttackState;

		public override State RunCurrentState()
		{

			if (_normalState.enemyRef.inAttackRange)
			{
				return _normalState;
			}
			else if (_normalState.enemyRef.specialReady)
			{
				return _specialAttackState;
			}
			else
			{
				_normalState.enemyRef.GetComponent<Patroller>().Patrol();
				return this;
			}
		}
	}
}
