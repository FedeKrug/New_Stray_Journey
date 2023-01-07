using UnityEngine;

namespace Game.Enemies
{
	public abstract class PassiveEnemy : Enemy
	{
		[SerializeField] protected float speed;
		[SerializeField, Range(0, 5)] protected float remainingTime;
		protected float timeRate;

	}
}
