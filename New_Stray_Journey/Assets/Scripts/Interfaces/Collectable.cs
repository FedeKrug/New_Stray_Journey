using UnityEngine;
public interface Collectable
{
	public void Collect();
}


namespace Game.Player
{
	public class SpecialPowerUp : MonoBehaviour, Collectable
	{
		[SerializeField] private PlayerSpecialShooting _playerRef;
		public TypeOfSpecialAttack typeOfSpecial;
		public void Collect()
		{
			_playerRef.onSpecial = true;
		}

		public int SelectSpecialByType()
		{
			switch (typeOfSpecial)
			{
				case TypeOfSpecialAttack.Dispersion:
					return 0;
					
				case TypeOfSpecialAttack.Explosion:
					return 1;
					
				case TypeOfSpecialAttack.PowerRay:
					return 2;
				
			}
			return -1;
		}

	}
}