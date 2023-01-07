using UnityEngine;
using System.Collections.Generic;

namespace Game.Enemies
{
	public class Turret : PassiveEnemy
	{
		[SerializeField] protected List<GameObject> bulletGens;
		[SerializeField] protected GameObject bullet;

		private void Update()
		{
			timeRate -= Time.deltaTime;
			if (playerDetected)
			{
				Move();
			}
			if (inAttackRange)
			{
				ConstantAttack();
			}
		}

		private void ConstantAttack()
		{
			if (timeRate <= 0)
			{
				timeRate = remainingTime;
				Attack();
			}
		}

		public override void Death(EnemyHealth enemyHealth)
		{

		}


		public void Move() //la torreta girara constantemente cuando el player se acerca a ella
		{
			this.transform.eulerAngles += Vector3.forward * speed * Time.deltaTime;
		}

		protected override void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet);
		}
		protected override void SpecialAttack()
		{

		}
		protected void LookAtTarget(Transform target)
		{

		}
	}
}
