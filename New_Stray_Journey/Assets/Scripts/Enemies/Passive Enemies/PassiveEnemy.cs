using UnityEngine;
using System.Collections;

namespace Game.Enemies
{
	public abstract class PassiveEnemy : Enemy
	{
		[SerializeField, Range(0, 5)] protected float remainingTime;
		protected float timeRate;

		protected virtual IEnumerator Explode()
		{
			Debug.Log("Enemy is dead");

			yield return null;
			gameObject.SetActive(false);
		}
	}
}
