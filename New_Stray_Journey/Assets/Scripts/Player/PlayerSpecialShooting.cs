using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
		[SerializeField] private Image _explosionImage, _powerRayImage;
		void Update()
		{
			if (PlayerManager.instance.usingSpecial)
			{
				SelectSpecial();

			}

			if (Input.GetKeyDown(KeyCode.T) && PlayerManager.instance.grabbedSpecial)
			{
				PlayerManager.instance.usingSpecial = true;
				SelectSpecial();
				Debug.Log("Special Actived");
				switch (typeOfSpecial)
				{
					case 0:
						EventManager.instance.specialAttackUIEvent.Invoke(_explosionImage);
						break;
					case 1:
						EventManager.instance.specialAttackUIEvent.Invoke(_powerRayImage);
						break;
				}
			}
		}

		private void SelectSpecial() //TODO: Change the special Attack enum when player takes the Special Object
		{
			typeOfSpecial = _playerInteraction.special;
			switch (typeOfSpecial)
			{

				case 0:
					if (Input.GetKeyUp(_keyToSpecial)) //Explosion
					{
						EventManager.instance.specialShootingEvent.Invoke(_specialGens, _specialShots[0].gameObject);
						
						//_explosionImage.gameObject.SetActive(true);
					}
					break;
				case 1:
					if (Input.GetKeyDown(_keyToSpecial)) //Power Ray
					{
						_specialShots[1].gameObject.SetActive(true);
						//_powerRayImage.gameObject.SetActive(true);
					}
					break;
			}
		}
	}

}
