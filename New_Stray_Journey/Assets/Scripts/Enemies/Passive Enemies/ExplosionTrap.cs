using System.Collections;

using UnityEngine;


namespace Game.Enemies
{
	public class ExplosionTrap : Obstacle
	{
		[SerializeField] private GameObject _bigExplosion;
		protected override void Attack()
		{
			base.Attack();
			_bigExplosion.SetActive(true);
			StartCoroutine(Explode());
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
			{
				Attack();
			}
		}
	}
}
