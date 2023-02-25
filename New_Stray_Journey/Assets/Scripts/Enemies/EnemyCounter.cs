using UnityEngine;
using Game.SO;
namespace Game.Enemies
{
	public class EnemyCounter : MonoBehaviour
	{
		public int enemyCant ;
		[SerializeField] IntSO _totalEnemies;

		private void Start()
		{
			EventManager.instance.enemyCounterUIEvent.Invoke();
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.GetComponent<Enemy>() && !collision.GetComponent<Obstacle>())
			{
				enemyCant--;
				_totalEnemies.value++;
				EventManager.instance.enemyCounterUIEvent.Invoke();
			}
		}

		private void Update()
		{
			if (enemyCant<=0)
			{
				Debug.Log("All enemies are dead");
			}
		}
	}

}
