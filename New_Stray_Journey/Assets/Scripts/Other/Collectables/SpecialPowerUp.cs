using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Game.Player
{
	public class SpecialPowerUp : MonoBehaviour, Collectable
	{
		public TypeOfSpecialAttack typeOfSpecial;
		[SerializeField] private Image _icon;
		[SerializeField] private Image _image;
		public void Collect()
		{
			if (!PlayerManager.instance.grabbedSpecial)
			{
			PlayerManager.instance.grabbedSpecial = true;

			}
			StartCoroutine(TakeSpecial());
			EventManager.instance.specialAttackUIIConEvent.Invoke(_icon);
			if (PlayerManager.instance.usingSpecial)
			{
				EventManager.instance.specialAttackUIEvent.Invoke(_image);
				StartCoroutine(PlayerManager.instance.UseSpecial());
			}

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

		IEnumerator TakeSpecial()
		{
			GetComponent<SpriteRenderer>().enabled = false;
			yield return null;
			gameObject.SetActive(false);
		}


	}
}