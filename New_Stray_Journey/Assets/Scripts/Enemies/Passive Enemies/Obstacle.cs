using UnityEngine;
using System.Collections;

namespace Game.Enemies
{
	public class Obstacle : PassiveEnemy
	{
		[SerializeField] private GameObject _explosion;
		[SerializeField] private AudioClip _explosionSound;
		[SerializeField] private GameObject _particlesExplosion;
		public override void Death(EnemyHealth enemyHealth)
		{
			StartCoroutine(Explode());
		}

		protected override void Attack()
		{
			StaticDamage();
		}

		protected override void SpecialAttack()
		{
			//Damage with the obstacle destruction
			
			if (_particlesExplosion)
			{
			_particlesExplosion.SetActive(true);

			}
		}

		protected override IEnumerator Explode()
		{
			_explosion.SetActive(true);
			this.gameObject.SetActive(false);
			aSource.PlayOneShot(_explosionSound);
			SpecialAttack();
			yield return null;
			yield return new WaitForSeconds(1.2f);
			_explosion.SetActive(false);
		}
	}
}
