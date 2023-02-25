﻿using UnityEngine;
using System.Collections;

namespace Game.Enemies
{
	public class Obstacle : PassiveEnemy
	{
		[SerializeField] private GameObject _explosion;
		[SerializeField] private AudioClip _explosionSound;
		[SerializeField] private GameObject _particlesExplosion;
		[SerializeField] private SpriteRenderer _spriteR, _miniMapSprite;
		public override void Death(EnemyHealth enemyHealth)
		{
			StartCoroutine(Explode());
		}

		protected override void Attack()
		{
			StaticDamage();
		}

		public override void SpecialAttack()
		{
			//Damage with the obstacle destruction


			_particlesExplosion.SetActive(true);


		}

		protected override IEnumerator Explode()
		{
			_explosion.SetActive(true);
			_particlesExplosion.SetActive(true);
			this.GetComponent<Collider2D>().enabled = false;
			aSource.PlayOneShot(_explosionSound);
			yield return null;
			_spriteR.enabled = false;
			_miniMapSprite.enabled = false;
			while (aSource.isPlaying)
			{
				yield return null;
			}
			this.gameObject.SetActive(false);
		}
	}
}
