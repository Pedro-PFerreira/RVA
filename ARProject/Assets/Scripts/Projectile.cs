using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private Entity thrower;


    public Entity GetThrower() {
        return thrower;
    }
}
