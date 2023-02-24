using UnityEngine;
using Game.Enemies;

namespace Game.Player
{
	public abstract class PlayerSpecialShoot : Bullet
	{
		[SerializeField] protected Animator anim;
		[SerializeField] protected string explosionAnimation;
		[SerializeField] public int id;
		public abstract void Shot();
		
		protected virtual void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>() )
			{
				anim.Play(explosionAnimation); // TODO: The zone damage will be done into the animation.
			}
			
		}

	}
}
