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
		}
	}
}
