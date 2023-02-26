using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
	public class PlayerSpecialShooting : MonoBehaviour
	{
		public int typeOfSpecial;
		[SerializeField] private KeyCode _keyToSpecial;
		[SerializeField, Tooltip("0 = Explosion, 1 = PowerRay")] private List<GameObject> _specialShots;
		[SerializeField] private List<GameObject> _specialGens;
		[SerializeField] private PlayerInteraction _playerInteraction;
		void Update()
		{
			if (PlayerManager.instance.onSpecial)
			{
				SelectSpecial();

			}
			else return;

		}

		private void SelectSpecial() //TODO: Change the special Attack enum when player takes the Special Object
		{
			typeOfSpecial = _playerInteraction.special;
			switch (typeOfSpecial)
			{

				case 0:
					if (Input.GetKeyUp(_keyToSpecial))
					{
						EventManager.instance.specialShootingEvent.Invoke(_specialGens, _specialShots[0].gameObject);
					}
					break;
				case 1:
					if (Input.GetKeyDown(_keyToSpecial))
					{
						_specialShots[1].gameObject.SetActive(true);
					}
					break;
			}
		}
	}

}
