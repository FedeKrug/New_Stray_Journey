using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
	public class PlayerSpecialShooting : MonoBehaviour
	{
		private TypeOfSpecialAttack _typeOfSpecial;
		public bool onSpecial;
		[SerializeField] private KeyCode _keyToSpecial;
		[SerializeField] private List<PlayerSpecialShoot> _specialShots;
	

		void Update()
		{
			if (onSpecial)
			{
				SelectSpecial();
			}
			else return;
			
		}

		private void SelectSpecial()
		{

			//switch (_typeOfSpecial)
			//{
			//	case TypeOfSpecialAttack.Dispersion:
			//		if (Input.GetKey(_keyToSpecial))
			//		{
			//			_specialShots[0].Shot();
			//		}
			//			break;
			//	case TypeOfSpecialAttack.Explosion:
			//		if (Input.GetKeyUp(_keyToSpecial))
			//		{
			//			_specialShots[1].Shot();
			//		}
			//		break;
			//	case TypeOfSpecialAttack.PowerRay:
			//		if (Input.GetKeyDown(_keyToSpecial))
			//		{
			//			_specialShots[2].Shot();
			//		}
			//		break;
			//}



		}
	}

}
