using UnityEngine;
using System.Collections;

namespace Game.Player
{
	public class PlayerRayShooting : MonoBehaviour
	{
		[SerializeField] private GameObject[] _ray = new GameObject[2];
		[SerializeField] private KeyCode _attractRayButton, _repulsionRayButton;

		private void Update()
		{

			if (Input.GetKey(_attractRayButton))
			{
				_ray[0].SetActive(true);
			}

			if (Input.GetKeyUp(_attractRayButton))
			{
				_ray[0].SetActive(false);
			}

			if (Input.GetKey(_repulsionRayButton))
			{
				_ray[1].SetActive(true);
			}


			if (Input.GetKeyUp(_repulsionRayButton))
			{
				_ray[1].SetActive(false);
			}
		}

	}
}



