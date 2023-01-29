using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


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

}

public class ShootEvent : UnityEvent<List<GameObject>, GameObject> { } //1- de donde sale el disparo 2- cual es el disparo
public class HealthEvent : UnityEvent<float> { } //la vida que se le da o quita al personaje
public class ScoreEvent : UnityEvent<string, TextMeshProUGUI> { }