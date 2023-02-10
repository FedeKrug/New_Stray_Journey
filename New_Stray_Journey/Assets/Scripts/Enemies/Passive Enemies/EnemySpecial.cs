using UnityEngine;


namespace Game.Enemies
{
	public class EnemySpecial : MonoBehaviour
	{
		[SerializeField] Enemy _enemyRef;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				_enemyRef.StaticDamage();
				if (_enemyRef.inSpecial)
				{
					StartCoroutine(_enemyRef.ChargingSpecial());
				}
			}
		}

	}
}
