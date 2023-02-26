using UnityEngine;
using System.Collections;


namespace Game.Enemies
{
	public class BlackHole : ExplosionTrap
	{
		[SerializeField, Range(0,100)] private float _holeForce;
		[SerializeField] private bool _inHoleRadius;
		[SerializeField] private Transform _holeCenter;
		[SerializeField, Tooltip("Hole Center rb2d")] private Rigidbody2D _rb2d;
		
		private void GetCloseToObjects(Collider2D collision)
		{
			if (collision.gameObject.GetComponent<Rigidbody2D>()|| collision.gameObject.GetComponentInParent<Rigidbody2D>() || collision.gameObject.GetComponentInChildren<Rigidbody2D>())
			{
				var dir = transform.position - collision.transform.position;
				var dirScale = Vector2.Scale(dir.normalized, gameObject.transform.localScale);
				collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dirScale * _holeForce, ForceMode2D.Force );
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_inHoleRadius = true;

		}
		private void OnTriggerStay2D(Collider2D collision)
		{
			GetCloseToObjects(collision);
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			_inHoleRadius = false;
		}
	}
}
