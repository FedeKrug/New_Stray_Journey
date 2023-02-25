using System;
using System.Collections;

using Game.Enemies;
using UnityEngine;

namespace Game.Player
{
	public class PowerRaySpecialAttack : LasserRay
	{
		[Header("PowerRaySpecialAttack Variables")]

		[SerializeField] private AudioClip _chargingAttackAudio;
		[SerializeField] private AudioClip _shootRayAudio;
		[SerializeField] private GameObject _powerRay, _chargingPowerAttack;
		[SerializeField] private AudioSource _aSource;
		public override void InteractWithEntities(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>())
			{
				Shot();
			}
		}

		public  void Shot()
		{
			//StartCoroutine(ChargrRayAndShoot());
			

		}

		IEnumerator ChargeRayAndShoot()
		{
			_aSource.PlayOneShot(_chargingAttackAudio);
			//anim.Play(shootingAnimation);
			while (_aSource.isPlaying)
			{
				yield return null;
			}
			//_chargingPowerAttack.SetActive(false);
			//yield return null;
			//_powerRay.SetActive(true);
			//aSource.PlayOneShot(_shootRayAudio);
			//while (aSource.isPlaying)
			//{
			//yield return null;
			//}
			//_powerRay.SetActive(true);
		}
	}
}
