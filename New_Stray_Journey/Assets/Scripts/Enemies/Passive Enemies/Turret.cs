using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Game.Enemies
{
	public class Turret : PassiveEnemy
	{
		[SerializeField] protected List<GameObject> bulletGens;
		[SerializeField] protected GameObject bullet;
		[SerializeField] bool onAnimation;
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
			StartCoroutine(Explode());
			//enemyHealth.gameObject.SetActive(false);
		}


		public void Move() //la torreta girara constantemente cuando el player se acerca a ella
		{
			this.transform.eulerAngles += Vector3.forward * movementSpeed * Time.deltaTime;
		}

		protected override void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet);
		}
		protected override void SpecialAttack() // un ataque potente con mayor rango de ataque y mayor damage
		{

		}
		protected void LookAtTarget(Transform target) // si la torreta tiene poca vida, empezara a buscar al player para apuntarle y atacarlo (raycast2D)
		{

		}

		
	}
}
