using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
	public class PlayerInteraction : MonoBehaviour
	{
		public int special; 
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Collectable>() != null)
			{
				collision.GetComponent<Collectable>().Collect();
				if (collision.GetComponent<SpecialPowerUp>())
				{
					special = collision.GetComponent<SpecialPowerUp>().SelectSpecialByType();
				}
			}
		}
	}


}