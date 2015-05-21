using UnityEngine;
using System.Collections;

public class RsEnemyDamage : RsDamageBase
{

    protected virtual void Awake()
    {
    }

    protected virtual void Start()
    {

    }

    protected override void OnDeath()
    {
        base.OnDeath();
        // TODO: add sound, effects, etc.
        Destroy(gameObject);
    }

    protected override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        // TODO: add sound, effects, etc.
    }
}
