using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Game.Enemies
{
	public class Turret : PassiveEnemy
	{
		[SerializeField] protected List<GameObject> bulletGens;
		[SerializeField] protected GameObject bullet;
		[SerializeField, Range(-360, 360)] private float _specialSpeed;
		[SerializeField, Range(0, 5)] private float _specialFireRate;
		[SerializeField] private float _timeToChangeDirection;
		[SerializeField] private bool _changedDirection;
		private float _minSpeed, _minFireRate;
		private void Awake()
		{
			_minSpeed = movementSpeed;
			_minFireRate = remainingTime;
		}
		private void Update()
		{
			timeRate -= Time.deltaTime;
			if (playerDetected)
			{
				Move();
			}
			if (inAttackRange && !specialReady)
			{
				ConstantAttack();
			}
		}

		private void ConstantAttack()
		{
			movementSpeed = _minSpeed;
			remainingTime = _minFireRate;
			if (timeRate <= 0)
			{
				timeRate = remainingTime;
				Attack();
			}
		}

		public override void Death(EnemyHealth enemyHealth)
		{
			StartCoroutine(Explode());
		}


		public void Move()
		{
			this.transform.eulerAngles += Vector3.forward * movementSpeed * Time.deltaTime;
		}

		protected override void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet);
		}
		public override void SpecialAttack()
		{
			StartCoroutine(SpecialShooting());
		}
		protected void LookAtTarget(Transform target)
		{

		}

		IEnumerator SpecialShooting()
		{
			movementSpeed = _specialSpeed;
			remainingTime = _specialFireRate;
			Attack();
			//yield return new WaitForSeconds(_timeToChangeDirection);
			//_changedDirection = !_changedDirection;
			////if (_changedDirection)
			////{
			////	_specialSpeed *= -1;
			////}
			////else
			////{
			////	_specialSpeed /= -1;
			////}
			////_specialSpeed *= -1;
			yield return null;

		}
	}
}
