using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
	public class PlayerInteraction : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponent<Interactable>() != null )
			{
				collision.GetComponent<Interactable>().Interact();
			}
			if (collision.GetComponent<Collectable>() != null)
			{
				collision.GetComponent<Collectable>().Collect();
			}
		}
	}


}