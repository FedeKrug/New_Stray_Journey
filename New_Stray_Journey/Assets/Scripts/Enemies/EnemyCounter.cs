using UnityEngine;
using Game.SO;
namespace Game.Enemies
{
	public class EnemyCounter : MonoBehaviour
	{
		public int enemyCant =0;
		[SerializeField] IntSO _totalEnemies;
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>() && !collision.GetComponent<Obstacle>())
			{
				enemyCant++;
				_totalEnemies.value++;
			}
		}
	}

}
