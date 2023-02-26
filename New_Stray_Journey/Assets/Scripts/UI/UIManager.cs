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
		EventManager.instance.specialAttackUIEvent.AddListener(UseSpecialAttackUIHandler);
		EventManager.instance.specialAttackUIIConEvent.AddListener(ShowSpecialAttackIconsHandler);
	}

	private void OnDisable()
	{
		EventManager.instance.healthBarEvent.RemoveListener(UpdateHealthBarHandler);
		EventManager.instance.enemyCounterUIEvent.RemoveListener(EnemyCounterUIHandler);
		EventManager.instance.specialAttackUIEvent.RemoveListener(UseSpecialAttackUIHandler);
		EventManager.instance.specialAttackUIIConEvent.RemoveListener(ShowSpecialAttackIconsHandler);
	}
	public void UpdateHealthBarHandler()
	{
		_healthBar.fillAmount = _playerHealth.value / 1000;
	}


	public void UseSpecialAttackUIHandler(Image currentSpecial)
	{
		for (int i =0; i<_specialAttacks.Count; i++)
		{
			_specialAttacks[i].gameObject.SetActive(false);
		}
		currentSpecial.gameObject.SetActive(true);

	}

	public void ShowSpecialAttackIconsHandler(Image currentIcon)
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
