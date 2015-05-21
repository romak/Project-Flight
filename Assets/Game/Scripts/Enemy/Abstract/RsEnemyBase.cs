using UnityEngine;
using System.Collections;

public class RsEnemyBase : RsDamageBase {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override void OnDeath()
    {
        print("OnDeath()");
        base.OnDeath();
    }

    protected override void OnDamage(float damage)
    {
        print("OnDamage");
        base.OnDamage(damage);
    }



}
