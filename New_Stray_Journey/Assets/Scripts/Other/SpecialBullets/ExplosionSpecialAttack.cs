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

		protected override void OnEnable()
		{
			base.OnEnable();
			StartCoroutine(StartTimerOfBomb());
		}
	

		public void Explode()
		{
			speed = 0;
			_bulletExplosion.SetActive(true);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>())
			{
				Explode();
			}
		}
		IEnumerator StartTimerOfBomb()
		{
			yield return new WaitForSeconds(maxTimeToDestroy);
			Explode();
		}
	}
}
