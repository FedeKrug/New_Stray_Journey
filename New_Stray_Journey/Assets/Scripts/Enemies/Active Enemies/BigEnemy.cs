using UnityEngine;
using System.Collections;


namespace Game.Enemies
{
	public class BigEnemy : MiniEnemy, Patroller
	{
		[SerializeField] private Transform _wayPointTarget;
		

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("WayPoint"))
			{
				_wayPointTarget = collision.GetComponent<WayPoint>().nextPoint;
			}
		}
		protected override void LookAtTarget(Transform target)
		{
			base.LookAtTarget(target);
		}

		public void Patrol()
		{
			LookAtTarget(_wayPointTarget);
			transform.Translate(-Vector2.up * movementSpeed * Time.deltaTime);
			Debug.Log("Patrolling");
		}
		
	}
}
