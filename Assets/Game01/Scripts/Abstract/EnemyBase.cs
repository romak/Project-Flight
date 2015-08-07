using UnityEngine;
using System.Collections;

public class EnemyBase : DamageBase {

	void Start () {
	}
	
	void Update () {
	
	}

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    protected override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }

}
