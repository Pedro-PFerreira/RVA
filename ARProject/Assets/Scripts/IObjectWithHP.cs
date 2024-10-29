using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectWithHP {
    public event EventHandler<OnHPChangedEventArgs> OnHPChanged;
    public class OnHPChangedEventArgs : EventArgs {
        public float hpNormalized;
    }

    int Health { get; }

    void TakeDamage(int amount);
    void Die();
}

