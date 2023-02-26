using System;
using UnityEngine;


namespace Game.Enemies
{
	public  class ExplosionTrap : Obstacle
	{
		[SerializeField] private GameObject _bigExplosion;

		protected override void Attack()
		{
			base.Attack();
			//TODO: Trap Special zone damage
			_bigExplosion.SetActive(true);

		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag ("Player")|| collision.CompareTag("Enemy"))
			{
				Attack();
			}
		}
	}
}
