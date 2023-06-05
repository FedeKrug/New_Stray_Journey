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
		[SerializeField] private string _deathAnim;
		[SerializeField] private float _deathTime;
		[SerializeField] private float _distance;
		[SerializeField] private Rigidbody2D _rb2d;
		protected override void Update()
		{
			base.Update();
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
		}

		protected IEnumerator Explode()
		{
			Debug.Log("Enemy is dead");
			Dropping(droppingObjects);
			yield return null;
			gameObject.SetActive(false);
		}

		IEnumerator ExplodeWithAnimation()
		{
			anim.Play(_deathAnim);
			yield return new WaitForSeconds(_deathTime);
			Debug.Log("Mini Enemy Exploded with animations");
			StartCoroutine(Explode());
		}


		private void OnTriggerEnter2D(Collider2D collision)
		{
			
		}
	}
}
