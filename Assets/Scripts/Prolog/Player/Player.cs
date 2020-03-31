using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _levelContinious;
    private float _maxHealth;
    private SpriteRenderer _spriteRenderer;
    private bool _exitLevel = false;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<BoxCollider2D>().isTrigger = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _maxHealth = _currentHealth;
    }

    private void Update()
    {
        if(Time.time >= _levelContinious && !_exitLevel)
        {
            _exitLevel = true;
            Die();
        }
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _currentHealth / _maxHealth);

        if (_currentHealth <= 2)
        {
            Die();
        }
    }

    public void Die()
    {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0.05f);
        FindObjectOfType<Spawner>().gameObject.SetActive(false);
        if (_currentHealth == _maxHealth)
        {
            PlayerPrefs.SetInt("DisappearSpeed", 1);
        }
        else if (_currentHealth > _maxHealth / 2)
        {
            PlayerPrefs.SetInt("DisappearSpeed", 2);
        }
        else
        {
            PlayerPrefs.SetInt("DisappearSpeed", 3);
        }
        Invoke("NextLevel", 5f);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
