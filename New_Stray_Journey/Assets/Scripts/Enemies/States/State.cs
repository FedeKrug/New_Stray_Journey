using UnityEngine;

namespace Game.Enemies
{
	//#region Interfaces
	////public interface IDamagable
	////{
	////	public void TakeDamage();
	////	public void Death();
	////}

	////public interface IAttacks
	////{
	////	public abstract void Attack();
	////	public abstract void SpecialAttack();
	////}
	//#endregion


	public abstract class State : MonoBehaviour
	{
		public abstract State RunCurrentState();
	}
}
