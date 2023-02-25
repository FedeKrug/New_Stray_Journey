using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
	public class PlayerSpecialShooting : MonoBehaviour
	{
		[SerializeField] private TypeOfSpecialAttack _typeOfSpecial;
		public bool onSpecial;
		[SerializeField] private KeyCode _keyToSpecial;
		[SerializeField, Tooltip("0 = Dispersion, 1 = Explosion, 2 = PowerRay")] private List<GameObject> _specialShots;
		[SerializeField] private List<GameObject> _specialGens;

		void Update()
		{
			if (onSpecial)
			{
				SelectSpecial();
				
			}
			else return;
			
		}

		private void SelectSpecial() //TODO: Change the special Attack enum when player takes the Special Object
		{

			switch (_typeOfSpecial)
			{
				case TypeOfSpecialAttack.Dispersion:
					if (Input.GetKey(_keyToSpecial))
					{
						_specialShots[0].GetComponent<PlayerSpecialShoot>().Shot();
						EventManager.instance.specialShootingEvent.Invoke(_specialGens, _specialShots[0].gameObject);
					}
					break;
				case TypeOfSpecialAttack.Explosion:
					if (Input.GetKeyUp(_keyToSpecial))
					{
						_specialShots[1].GetComponent<PlayerSpecialShoot>().Shot();
						EventManager.instance.specialShootingEvent.Invoke(_specialGens, _specialShots[1].gameObject);
					}
					break;
				case TypeOfSpecialAttack.PowerRay:
					if (Input.GetKeyDown(_keyToSpecial))
					{
						_specialShots[2].GetComponent<PowerRaySpecialAttack>().Shot();
						//EventManager.instance.specialShootingEvent.Invoke(_specialGens, _specialShots[2].gameObject);
					}
					break;
			}



		}
	}

}
