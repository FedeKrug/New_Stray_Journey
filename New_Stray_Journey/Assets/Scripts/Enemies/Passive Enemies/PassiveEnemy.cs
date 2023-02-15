using UnityEngine;
using System.Collections;

namespace Game.Enemies
{
	public abstract class PassiveEnemy : Enemy
	{
		[SerializeField] protected float speed;
		[SerializeField, Range(0, 5)] protected float remainingTime;
		protected float timeRate;


		protected virtual IEnumerator Explode()
		{
			//anim.Play("DeathAnimation"); //uso anim.Play para que solo se reproduzca una vez la animacion
			////en la animacion de muerte se activa un bool onAnimation que se desactiva al finalizar la animacion

			//while (onAnimation)
			//{
			//	yield return null;
			//}
			Debug.Log("Enemy is dead");

			yield return null;
			gameObject.SetActive(false);
		}
	}
}
