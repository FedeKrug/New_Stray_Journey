using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;


namespace Game.Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField, Range(0, 10)] protected float idleDamage;
		[SerializeField, Range(0, 10)] protected float timeToSpecial;
		protected float idleTime;
		[SerializeField] protected EnemyHealth enemyLife;
		//[SerializeField] protected EnemyRangeDetector rangeOfView;
		protected bool inSpecial, specialReady;
		public bool inAttackRange, playerDetected;

		void Awake()
		{
			idleTime = timeToSpecial;
		}

		public abstract void Death(EnemyHealth enemyHealth);
		protected abstract void Attack();
		protected abstract void SpecialAttack();


		protected void StaticDamage()
		{
			PlayerManager.instance.TakeDamage(idleDamage);
		}

		public virtual IEnumerator ChargingSpecial()
		{
			yield return new WaitForSeconds(timeToSpecial);
			specialReady = true;
			yield return null;
			SpecialAttack();
		}

	}

	#region Interfaces
	public interface IDamagable
	{
		public void TakeDamage();
		public void Death();
	}

	public interface IAttacks
	{
		public abstract void Attack();
		public abstract void SpecialAttack();
	}
	#endregion

}
