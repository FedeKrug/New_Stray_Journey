using System;
using System.Collections;
using Game.Enemies;

using UnityEngine;
namespace Game.Player
{
	public class ExplosionSpecialAttack : PlayerSpecialShoot
	{
		[Header("ExplosionAttack Variables")]
		[SerializeField] private GameObject _bulletExplosion; //Zone Attack
		[SerializeField] private bool _hasToExplode;

		protected override void OnEnable()
		{
			base.OnEnable();
			StartCoroutine(StartTimerOfBomb());
		}
		protected override void Update()
		{
			if (_hasToExplode)
			{
				Explode();
			}
		}
		public override void Shot()
		{
			Explode();
		}

		public void Explode()
		{
			Instantiate(_bulletExplosion, transform.position, transform.rotation);
		}

		protected override void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>())
			{
				Explode();
			}
		}
		IEnumerator StartTimerOfBomb()
		{
			yield return new WaitForSeconds(maxTimeToDestroy);
			_hasToExplode = true;
		}
	}
}
