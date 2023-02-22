using UnityEngine;
using Game.Player;
using Game.Enemies;

namespace Game.Enemies
{
	public class HoleCenterSpecial: MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>())
			{
				collision.GetComponent<Enemy>().Death(collision.GetComponent<EnemyHealth>());
			}
			if (collision.GetComponent<Rigidbody2D>() && !collision.GetComponent<Enemy>()&&!collision.CompareTag("Player"))
			{
				collision.gameObject.SetActive(false);
			}
			else if (collision.CompareTag("Player"))
			{
				PlayerManager.instance.gameObject.GetComponent<PlayerDeath>().Die();
			}
		}
	}
}
