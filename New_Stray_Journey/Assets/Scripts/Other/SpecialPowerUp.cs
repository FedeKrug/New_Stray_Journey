using UnityEngine;
using System.Collections;

namespace Game.Player
{
	public class SpecialPowerUp : MonoBehaviour, Collectable
	{
		public TypeOfSpecialAttack typeOfSpecial;
		
		public void Collect()
		{
			PlayerManager.instance.onSpecial = true;
			StartCoroutine(TurnOffSpecial());
		}
		public int SelectSpecialByType()
		{
			switch (typeOfSpecial)
			{
				case TypeOfSpecialAttack.Explosion:
					return 0;

				case TypeOfSpecialAttack.PowerRay:
					return 1;
			}
			return -1;
		}

		IEnumerator TurnOffSpecial()
		{
			GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds(UIManager.instance.timeToSpecial);
			PlayerManager.instance.onSpecial = false;
			Debug.Log($"Special Attack: {typeOfSpecial}");
			gameObject.SetActive(false);
		}
	}
}