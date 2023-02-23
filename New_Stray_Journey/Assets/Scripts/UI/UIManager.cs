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
	}

	private void OnDisable()
	{
		EventManager.instance.healthBarEvent.RemoveListener(UpdateHealthBarHandler);
	}
	public void UpdateHealthBarHandler()
	{
		_healthBar.fillAmount = _playerHealth.value/1000;
	}
}
