using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image _healthbarImage;

    public void UpdateHealthBar(float max, float currentHealth)
    {
        _healthbarImage.fillAmount = currentHealth / max;
    }
}
