using UnityEngine;
using System.Collections;

namespace Game.Player
{
	public class PlayerRayShooting : MonoBehaviour
	{
		[SerializeField] private GameObject _ray;
		private void Update()
		{
			if (Input.GetKey(KeyCode.E))
			{
				_ray.SetActive(true);
			}
			else 
			{
				_ray.SetActive(false);

			}
		}

		
	}
}



