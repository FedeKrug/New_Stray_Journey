using System.Collections;

using UnityEngine;


namespace Game.Enemies
{
	public class ExplosionTrap : Obstacle
	{
		[SerializeField] private GameObject _bigExplosion;
		protected override void Attack()
		{
			//base.Attack();
			//_bigExplosion.SetActive(true);
			StartCoroutine(Explota());
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
			{
				Attack();
			}
		}

		IEnumerator Explota()
		{
			_bigExplosion.SetActive(true);
			particlesExplosion.SetActive(true);
			this.GetComponent<Collider2D>().enabled = false;
			aSource.PlayOneShot(explosionSound);
			yield return null;
			spriteR.enabled = false;
			miniMapSprite.enabled = false;
			while (aSource.isPlaying)
			{
				yield return null;
			}
			this.gameObject.SetActive(false);
		}
	}
}
