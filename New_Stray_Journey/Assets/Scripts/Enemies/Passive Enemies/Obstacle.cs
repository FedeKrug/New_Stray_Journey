using UnityEngine;
using System.Collections;

namespace Game.Enemies
{
	public class Obstacle : PassiveEnemy
	{
		[SerializeField] private GameObject _explosion;
		[SerializeField] protected AudioClip explosionSound;
		[SerializeField] protected GameObject particlesExplosion;
		[SerializeField] protected SpriteRenderer spriteR, miniMapSprite;
		public override void Death(EnemyHealth enemyHealth)
		{
			StartCoroutine(Explode());
		}

		protected override void Attack()
		{
			StaticDamage();
		}

		public override void SpecialAttack() { }

		protected override IEnumerator Explode()
		{
			_explosion.SetActive(true);
			particlesExplosion.SetActive(true);
			this.GetComponent<Collider2D>().enabled = false;
			aSource.PlayOneShot(explosionSound);
			yield return null;
			spriteR.enabled = false;
			miniMapSprite.enabled = false;
			while (aSource.isPlaying)
			{
				yield return null;
			}
			this.gameObject.SetActive(false);
		}
	}
}
