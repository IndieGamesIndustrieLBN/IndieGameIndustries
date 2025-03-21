using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;

    public Slider HP;  // Referencja do paska HP
    public TextMeshProUGUI EnemyTag;  // Referencja do tekstu

    private void Start()
    {
        currentHP = maxHP;

        // Ustawienie domy�lnego imienia przeciwnika
        if (EnemyTag != null)
        {
            EnemyTag.text = "Wojownik"; // Mo�esz zmieni� na inne imi�
        }

        // Ustawienie pocz�tkowego HP
        if (HP != null)
        {
            HP.maxValue = maxHP;
            HP.value = maxHP;
        }
    }

    public void ApplyDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // Zapobiega warto�ciom ujemnym

        if (HP != null)
        {
            HP.value = currentHP;
        }

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Usuwa przeciwnika po �mierci
    }
}
