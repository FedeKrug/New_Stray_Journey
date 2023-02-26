using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField, Range(0, 10)] protected float idleDamage;
		[SerializeField, Range(0, 10)] protected float timeToSpecial, timeOfSpecial;
		[SerializeField] protected float movementSpeed;
		protected float idleTime;
		[SerializeField] protected EnemyHealth enemyLife;
		public bool inSpecial, specialReady;
		public bool inAttackRange, playerDetected;
		[SerializeField] protected Animator anim;
		[SerializeField] protected AudioSource aSource;
		[SerializeField] protected List<GameObject> droppingObjects;

		void Awake()
		{
			idleTime = timeToSpecial;
		}

		public abstract void Death(EnemyHealth enemyHealth);
		protected abstract void Attack();
		public abstract void SpecialAttack();

		protected virtual void Update()
		{
			if (PlayerManager.instance.playerDead)
			{
				if (GetComponent<StateManager>())
				{
					GetComponent<StateManager>().enabled = false;

				}
			}
		}
		public void StaticDamage()
		{
			PlayerManager.instance.TakeDamage(idleDamage);
		}

		public virtual IEnumerator ChargingSpecial()
		{
			yield return new WaitForSeconds(timeToSpecial);
			specialReady = true;
			yield return null;
			SpecialAttack();
			yield return new WaitForSeconds(timeOfSpecial);
			specialReady = false;

		}
		protected virtual void Dropping(List<GameObject> droppedObjects)
		{
			//spawner de objetos aleatoriamente en un rango definido por cada enemigo
			for (int i = 0; i < droppedObjects.Count; i++)
			{
				Instantiate(droppedObjects[i], transform.position, droppedObjects[i].transform.rotation);
			}
		}

	}
}
