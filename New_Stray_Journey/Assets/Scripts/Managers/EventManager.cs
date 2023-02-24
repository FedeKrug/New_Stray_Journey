using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Game.SO;

[DefaultExecutionOrder(-100)]
public class EventManager : MonoBehaviour
{
	#region Singleton & Awake
	public static EventManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion

	public ShootEvent normalShootingEvent = new ShootEvent();
	public ShootEvent specialShootingEvent = new ShootEvent();

	public ShootEvent enemyShootingEvent = new ShootEvent();

	public HealthEvent playerDamagedEvent = new HealthEvent();
	public HealthEvent playerCuredEvent = new HealthEvent();

	public ScoreEvent scoreEvent = new ScoreEvent();

	public HookEvent playerHookEvent = new HookEvent();

	public SaveScoreEvent saveScoreEvent = new SaveScoreEvent();

	public UIEvent healthBarEvent = new UIEvent();
	public UIEvent specialUIEvent = new UIEvent();
	public UIEvent enemyCounterUIEvent = new UIEvent();
}

public class ShootEvent : UnityEvent<List<GameObject>, GameObject> { } //1- de donde sale el disparo 2- cual es el disparo
public class HealthEvent : UnityEvent<float> { } 
public class ScoreEvent : UnityEvent<string, TextMeshProUGUI> { }
public class HookEvent : UnityEvent<GameObject, GameObject> { }

public class SaveScoreEvent : UnityEvent<int, TextMeshProUGUI> { }

public class UIEvent : UnityEvent { }