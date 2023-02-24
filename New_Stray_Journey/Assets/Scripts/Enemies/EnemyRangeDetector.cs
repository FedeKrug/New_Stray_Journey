using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace Game.Enemies
{
	public class EnemyRangeDetector : MonoBehaviour
	{
		[SerializeField] private Enemy _colliderDetector;
		[SerializeField, Range(0, 20)] private float _timeToStopChasing, _timeToStopSpecial;


		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				_colliderDetector.inAttackRange = true;
				_colliderDetector.playerDetected = true;
			}
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				_colliderDetector.inAttackRange = false;
				StartCoroutine(StopChasing());
				StartCoroutine(StopSpecial());

			}
		
		}
		private void OnTriggerStay2D(Collider2D collision)
		{
			if (collision.CompareTag("Player") && _colliderDetector.GetComponent<EnemyHealth>().Health >0)
			{
				StartCoroutine(_colliderDetector.ChargingSpecial());

			}
		}

		IEnumerator StopChasing()
		{
			yield return new WaitForSeconds(_timeToStopChasing);
			_colliderDetector.playerDetected = false;
		}
		IEnumerator StopSpecial()
		{
			yield return new WaitForSeconds(_timeToStopSpecial);
			if (!_colliderDetector.inSpecial)
			{
				_colliderDetector.specialReady = false;

			}
			else
			{
				yield return new WaitUntil(() => _colliderDetector.inSpecial == false);
				_colliderDetector.specialReady = false;
			}

		}
	}

}
