using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Entity entity;

    private void Start() {
        entity.OnHPChanged += Entity_OnHPChanged;
        barImage.fillAmount = 1f;

        if (entity.isEnemy) {
            barImage.color = Color.red;
        }
    }

    private void Entity_OnHPChanged(object sender, Entity.OnHPChangedEventArgs e) {
        barImage.fillAmount = e.hpNormalized;
    }

}
