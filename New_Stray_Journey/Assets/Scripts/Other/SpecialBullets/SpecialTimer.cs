using Game.Player;

using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;
using UnityEngine.UI;
public class SpecialTimer : MonoBehaviour
{

	private float _maxTime;
	[SerializeField] private Image _powerUpImage;

	private void OnEnable()
	{
		_maxTime = UIManager.instance.timeToSpecial;
	}
	void Update()
	{
		if (UIManager.instance.timeToSpecial > 0)
		{
			UIManager.instance.timeToSpecial -= Time.deltaTime;
			_powerUpImage.fillAmount = UIManager.instance.timeToSpecial / _maxTime;
		}

		if (UIManager.instance.timeToSpecial <= 0)
		{
			this.gameObject.SetActive(false);
			PlayerManager.instance.usingSpecial = false;
			PlayerManager.instance.grabbedSpecial = false;
		}
	}
}
