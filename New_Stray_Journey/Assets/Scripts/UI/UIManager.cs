using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.SO;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Image _healthBar;
    [SerializeField] private FloatSO _playerHealth;

	[SerializeField] private List<Image> _specialAttacks;
	[SerializeField] private float _timeToSpecial;
	[SerializeField] private float _maxTime;
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

	}

	private void OnDisable()
	{
		EventManager.instance.healthBarEvent.RemoveListener(UpdateHealthBarHandler);
		EventManager.instance.specialUIEvent.RemoveListener(SpecialAttackUIHandler);
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
}
