using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace Game.Enemies
{
	public class EnemyHealth : MonoBehaviour
	{

		[SerializeField] private float _health;
		[SerializeField] private Enemy _enemyRef;
		[SerializeField] private SpriteRenderer _enemySpriteRef;
		[SerializeField] private string _hurtAnimation;

		public float Health
		{
			get => _health; set => _health = value;
		}

		public void CheckDeath()
		{
			if (_health <= 0)
			{
				_enemyRef.Death(this);
			}
		}

		public void IncreaseHealth(float healthBooster)
		{
			_health += healthBooster;
		}

		public void TakeDamage(float damage)
		{
			_health -= damage;
			StartCoroutine(DamageFeedback());

		}

		IEnumerator DamageFeedback()
		{
			var enemyAnim = _enemySpriteRef.GetComponent<Animator>();
			if (enemyAnim)
			{
				enemyAnim.Play(_hurtAnimation);

			}
			yield return null;
			CheckDeath();
		}
	}

}
