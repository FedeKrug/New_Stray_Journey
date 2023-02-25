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
		[SerializeField] private GameObject _powerRay;
		[SerializeField] private AudioSource _aSource;
		[SerializeField, Range(0,1500)] private float _powerRayDamage;
		public override void InteractWithEntities(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>())
			{
				Shot();
				collision.GetComponent<Enemy>().GetComponent<EnemyHealth>().TakeDamage(_powerRayDamage);
			}
		}

		public void Shot()
		{
			StartCoroutine(ChargeRayAndShoot());


		}

		IEnumerator ChargeRayAndShoot()
		{
			_aSource.PlayOneShot(_chargingAttackAudio);
			//anim.Play(shootingAnimation); //TODO: Animation for powerRay charge
			while (_aSource.isPlaying)
			{
				yield return null;
			}
			//_chargingPowerAttack.SetActive(false);
			yield return new WaitForSeconds(0.5f);
			_powerRay.SetActive(true);
			_aSource.PlayOneShot(_shootRayAudio);
			yield return null;
			gameObject.layer = 16;
			while (_aSource.isPlaying)
			{
			yield return null;
			}
			_powerRay.SetActive(true);
		}
	}

	
}
