using UnityEngine;
using Game.Enemies;

namespace Game.Player
{
	public class BulletExplosionDamage : MonoBehaviour
	{
		[SerializeField, Range(0, 1500)] private float _damage;
		private void OnTriggerEnter2D(Collider2D collision)
		{

			if (collision.GetComponent<EnemyHealth>())
			{
				collision.GetComponent<EnemyHealth>().TakeDamage(_damage);
				
			}
			if (collision.CompareTag("Player") && GetComponentInParent<ExplosionTrap>())
			{
				PlayerManager.instance.TakeDamage(_damage/2);
			}

		}
	}
}
