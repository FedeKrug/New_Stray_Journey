using UnityEngine;
using System.Collections;

namespace Game.Enemies
{
	public class Obstacle : PassiveEnemy
	{
		[SerializeField] private GameObject _explosion;
		[SerializeField] private AudioClip _explosionSound;
		[SerializeField] private GameObject _particlesExplosion;
		[SerializeField] private SpriteRenderer _spriteR;
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


			_particlesExplosion.SetActive(true);


		}

		protected override IEnumerator Explode()
		{
			_explosion.SetActive(true);
			_particlesExplosion.SetActive(true);
			aSource.PlayOneShot(_explosionSound);
			yield return null;
			_spriteR.enabled = false;
			yield return new WaitForSeconds(1.2f);
			_explosion.SetActive(false);
			this.gameObject.SetActive(false);
		}
	}
}
