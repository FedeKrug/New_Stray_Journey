using UnityEngine;
using System.Collections;


namespace Game.Enemies
{
	public class BlackHole : Trap
	{
		[SerializeField, Range(0,10000)] private float _holeForce;
		[SerializeField] private bool _inHoleRadius;
		[SerializeField] private Transform _holeCenter;
		[SerializeField, Tooltip("Hole Center rb2d")] private Rigidbody2D _rb2d;


		private void Update()
		{
			//AtractObjects();
		}
		private void AtractObjects() // TODO: Use forces & Physics2D to atract the player
									 // and objects to the center of the hole
		{
			if (_inHoleRadius)
			{
				_rb2d.AddForceAtPosition(new Vector2(_holeForce, _holeForce), _holeCenter.position);
			}
			else
			{
				return;
			}
		}

		private void GetCloseToObjects(Collider2D collision)
		{
			if (collision.gameObject.GetComponent<Rigidbody2D>()|| collision.gameObject.GetComponentInParent<Rigidbody2D>())
			{
				var dir = transform.position - collision.transform.position;
				var dirScale = Vector2.Scale(dir.normalized, gameObject.transform.localScale);
				collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dirScale, ForceMode2D.Force );
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_inHoleRadius = true;
			GetCloseToObjects(collision);

		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			_inHoleRadius = false;
		}
	}

	public class HoleCenterSpecial: MonoBehaviour
	{
		
	}
}
