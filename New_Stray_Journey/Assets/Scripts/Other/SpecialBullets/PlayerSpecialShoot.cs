using UnityEngine;
using Game.Enemies;

namespace Game.Player
{
	public abstract class PlayerSpecialShoot : Bullet
	{
		[SerializeField] protected Animator anim;
		[SerializeField] protected string explosionAnimation, shootingAnimation;
		[SerializeField] public int id;
		[SerializeField] protected AudioSource aSource;
		public abstract void Shot();
		
		protected virtual void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>() )
			{
				Shot(); //Shot is the moment when the player shoots the bullet
						// TODO: The zone damage will be done into the animation.
			}
			
		}

	}
}
