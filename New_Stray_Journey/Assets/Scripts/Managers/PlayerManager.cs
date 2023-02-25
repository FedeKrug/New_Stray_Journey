using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.SO;
using System;
using Game.Enemies;

namespace Game.Player
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager instance;
		[SerializeField] private FloatSO _playerHealth;
		[SerializeField] private PlayerDeath _playerDeathRef;
		public bool _playerDead;

		#region Singleton and Awake
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
		#endregion

		#region Subscribe and Unsubscribe to EventManager
		private void OnEnable()
		{
			EventManager.instance.normalShootingEvent.AddListener(ShootingHandler);
			EventManager.instance.specialShootingEvent.AddListener(ShootingHandler);

			EventManager.instance.playerHookEvent.AddListener(HookEventHandler);

			EventManager.instance.playerDamagedEvent.AddListener(TakeDamage);
			EventManager.instance.playerCuredEvent.AddListener(IncreaseHealth);
		}

		private void HookEventHandler(GameObject hookOrigin, GameObject hook)
		{
			var playerPos = FindObjectOfType<PlayerMovement>().gameObject.transform;
			var playerPosOffset = new Vector3(hookOrigin.transform.position.x, hookOrigin.transform.position.y + 1.5f, hookOrigin.transform.position.z);
			GameObject _hook = Instantiate(hook, playerPosOffset, hookOrigin.transform.rotation, playerPos);
			_hook.transform.position = hookOrigin.transform.position;

		}

		private void OnDisable()
		{
			EventManager.instance.normalShootingEvent.RemoveListener(ShootingHandler);
			EventManager.instance.specialShootingEvent.RemoveListener(ShootingHandler);

			EventManager.instance.playerDamagedEvent.RemoveListener(TakeDamage);
			EventManager.instance.playerCuredEvent.RemoveListener(IncreaseHealth);

			EventManager.instance.playerHookEvent.RemoveListener(HookEventHandler);

		}

		#endregion

		public void ShootingHandler(List<GameObject> bulletGenerators, GameObject bullet)
		{
			for (int i = 0; i < bulletGenerators.Count; i++)
			{
				if (bullet)
				{
					GameObject _bullet = Instantiate(bullet, bulletGenerators[i].transform.position, bulletGenerators[i].transform.rotation);
					_bullet.transform.position = bulletGenerators[i].transform.position;
					Debug.Log("Disparo");

				}
				
			}
		}

		public void TakeDamage(float damage)
		{
			_playerHealth.value -= damage;
			CheckDeath();
		}

		public void IncreaseHealth(float healthBooster)
		{
			_playerHealth.value += healthBooster;
		}

		public void CheckDeath()
		{
			if (_playerHealth.value <= 0)
			{
				_playerDeathRef.Die();
				_playerDead = true;
			}
		}

		IEnumerator Death()
		{
			yield return new WaitForSeconds(2);
		}
	}
}
