using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth
{
    private float _maxHealth;
    private float _currHealth;

    private TextMeshProUGUI _healthTMP;
    private Image _revivePanel;

    private Pause _pause;

    public PlayerHealth(float maxHealth, TextMeshProUGUI healthTMP, Image revivePanel, Pause pause)
    {
        _maxHealth = maxHealth;
        _currHealth = _maxHealth;
        _healthTMP = healthTMP;
        _revivePanel = revivePanel;

        _pause = pause;

        _healthTMP.text = _currHealth.ToString();
    }

    public void TakeDamage(float damage)
    {
        _currHealth -= damage;
        if (_currHealth <= 0)
        {
            _currHealth = 0;
            Death();
        }
        _healthTMP.text = _currHealth.ToString();
    }

    private void Death()
    {
        _pause.PauseUnPauseGame();
        _revivePanel.gameObject.SetActive(true);
    }
}
