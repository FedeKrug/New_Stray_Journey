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
		[SerializeField] private GameObject _powerRay, _chargeRayEffect;
		[SerializeField] private AudioSource _aSource;
		[SerializeField, Range(0,1500)] private float _powerRayDamage;
		[SerializeField, Range(0, 10)] private float _timeOfSpecial; 
		public override void InteractWithEntities(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>())
			{
				collision.GetComponent<Enemy>().GetComponent<EnemyHealth>().TakeDamage(_powerRayDamage);
			}
		}
		private void OnEnable()
		{
			StartCoroutine(ChargeRayAndShoot());
		}
		
		
		IEnumerator ChargeRayAndShoot()
		{
			_aSource.PlayOneShot(_chargingAttackAudio);
			while (_aSource.isPlaying)
			{
				yield return null;
			}
			_chargeRayEffect.GetComponent<SpriteRenderer>().enabled = false;
			_powerRay.SetActive(true);
			_aSource.PlayOneShot(_shootRayAudio);
			yield return null;
			gameObject.layer = 16;
			while (_aSource.isPlaying)
			{
			yield return null;
			}
			_powerRay.SetActive(true);
			yield return new WaitForSeconds(_timeOfSpecial);
			_powerRay.SetActive(false);
			_chargeRayEffect.SetActive(false);

		}
	}

	
}
