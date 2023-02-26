using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.SO;
using TMPro;
using Game.Enemies;
using Game.Player;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;


	[Header("HealthBar")]
	[SerializeField] private Image _healthBar;
	[SerializeField] private FloatSO _playerHealth;


	[Header("SpecialAttacks")]
	[SerializeField] private List<Image> _specialAttackIcons;
	[SerializeField] private List<Image> _specialAttacks;//icons
	public float timeToSpecial;
	[SerializeField] private float _maxTime;
	[SerializeField] private PlayerSpecialShooting _playerSpecialShootingRef;

	[Header("EnemyCounter")]
	[SerializeField] private IntSO _enemyCantRef;
	[SerializeField] private EnemyCounter _enemyCouneterRef;
	[SerializeField] private TextMeshProUGUI _enemyCounterText;
	[SerializeField] private TextMeshProUGUI _totalEnemyDead;
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

	private void Update()
	{
		EventManager.instance.healthBarEvent.Invoke();
	}

	private void OnEnable()
	{
		EventManager.instance.healthBarEvent.AddListener(UpdateHealthBarHandler);
		EventManager.instance.enemyCounterUIEvent.AddListener(EnemyCounterUIHandler);
		EventManager.instance.specialAttackUIEvent.AddListener(SpecialAttackUIHandler);
	}

	private void OnDisable()
	{
		EventManager.instance.healthBarEvent.RemoveListener(UpdateHealthBarHandler);
		EventManager.instance.enemyCounterUIEvent.RemoveListener(EnemyCounterUIHandler);
		EventManager.instance.specialAttackUIEvent.RemoveListener(SpecialAttackUIHandler);
	}
	public void UpdateHealthBarHandler()
	{
		_healthBar.fillAmount = _playerHealth.value / 1000;
	}

	public void SpecialAttackUIHandler(Image currentSpecial)
	{
		currentSpecial.gameObject.SetActive(true);
		UseSpecialAttackUI(currentSpecial);
		ShowSpecialAttackIcons(currentSpecial);
	}

	public void UseSpecialAttackUI(Image currentSpecial)
	{
		if (timeToSpecial > 0)
		{
			timeToSpecial -= Time.deltaTime;
			currentSpecial.fillAmount = timeToSpecial / _maxTime;
		}

	}

	public void ShowSpecialAttackIcons(Image currentIcon)
	{
		for (int i = 0; i < _specialAttackIcons.Count; i++)
		{
			_specialAttackIcons[i].gameObject.SetActive(false);
		}
		currentIcon.gameObject.SetActive(true);
	}

	public void EnemyCounterUIHandler()
	{
		_enemyCounterText.text = $"Enemies: { _enemyCouneterRef.enemyCant}";
		_totalEnemyDead.text = $"Total Enemies Killed: {_enemyCantRef.value}";
	}
}
