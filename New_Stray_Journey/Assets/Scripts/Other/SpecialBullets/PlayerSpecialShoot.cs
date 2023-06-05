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
		
	}
}
