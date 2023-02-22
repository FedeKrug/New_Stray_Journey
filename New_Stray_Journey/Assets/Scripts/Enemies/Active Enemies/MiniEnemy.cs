using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Game.Enemies
{
	public class MiniEnemy : ActiveEnemy
	{
		[SerializeField, Range(0, 5)] protected float remainingTime;
		protected float timeRate;
		[SerializeField] protected List<GameObject> bulletGens;
		[SerializeField] protected GameObject bullet;

		private void Update()
		{
			timeRate -= Time.deltaTime;
			if (inAttackRange)
			{
				ConstantAttack();

			}
			if (playerDetected)
			{
				Move(playerRef);

			}
		}

		protected virtual void ConstantAttack()
		{
			if (timeRate <= 0)
			{
				timeRate = remainingTime;
				Attack();
			}
		}

		public override void Move(Transform target)
		{
			LookAtTarget(target);
			transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
		}

		protected virtual void LookAtTarget(Transform target)
		{
			this.transform.up = transform.position - target.position;
		}

		public override void Death(EnemyHealth enemyHealth)
		{
			StartCoroutine(Explode());
		}

		protected override void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet);
		}

		public override void SpecialAttack()
		{
			//Special Attack - un ataque kamikaze.
			//Explode();
			Debug.Log("Mini Enemy Kamikaze attack");
		}

		protected IEnumerator Explode()
		{
			//anim.Play("DeathAnimation"); //uso anim.Play para que solo se reproduzca una vez la animacion
			////en la animacion de muerte se activa un bool onAnimation que se desactiva al finalizar la animacion

			//while (onAnimation)
			//{
			//	yield return null;
			//}
			Debug.Log("Enemy is dead");

			yield return null;
			gameObject.SetActive(false);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			
		}
	}
}
