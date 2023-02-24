using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.SO;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

	[Header ("HealthBar")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private FloatSO _playerHealth;


	[Header ("SpecialAttacks")]
	[SerializeField] private List<Image> _specialAttacks;
	[SerializeField] private float _timeToSpecial;
	[SerializeField] private float _maxTime;

	[Header("EnemyCounter")]
	[SerializeField] private IntSO _enemyCantRef;
	[SerializeField] private TextMeshProUGUI _enemyCounterText;
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
		EventManager.instance.specialUIEvent.AddListener(SpecialAttackUIHandler);
		EventManager.instance.enemyCounterUIEvent.AddListener(EnemyCounterUIHandler);

	}

	private void OnDisable()
	{
		EventManager.instance.healthBarEvent.RemoveListener(UpdateHealthBarHandler);
		EventManager.instance.specialUIEvent.RemoveListener(SpecialAttackUIHandler);
		EventManager.instance.enemyCounterUIEvent.RemoveListener(EnemyCounterUIHandler);
	}
	public void UpdateHealthBarHandler()
	{
		_healthBar.fillAmount = _playerHealth.value/1000;
	}

	public void SpecialAttackUIHandler()
	{
		for (int i =0; i < _specialAttacks.Count; i++)
		{

		}
	}

	public void UseSpecialAttackUI(Image currentSpecial)
	{
		if (_timeToSpecial>0)
		{

		_timeToSpecial -= Time.deltaTime;
		}

		currentSpecial.fillAmount = 0;
	}

	public void EnemyCounterUIHandler()
	{
		_enemyCounterText.text = $"Enemies: { _enemyCantRef.value.ToString()}";
	}
}
