using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _invincibilityDuration;
    private int _currentHealth;
    [SerializeField]private bool _isInvincible;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public bool DecreaseHealth(int pDamage)
    {
        if (_isInvincible) return false;
        _currentHealth -= pDamage;
        StartCoroutine(InvincibilityCooldown());
        if (_currentHealth <= 0)
        {
            EventManager.Instance.OnPlayerDie?.Invoke();
        }
        return true;
    }
    private IEnumerator InvincibilityCooldown()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(_invincibilityDuration);
        _isInvincible = false;
    }
}