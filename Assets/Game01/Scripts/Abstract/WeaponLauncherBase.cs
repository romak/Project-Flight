using UnityEngine;
using System.Collections;

public class WeaponLauncherBase : MonoBehaviour
{

    [SerializeField]
    protected AmmoBase m_ammo;

    public virtual void Fire() { }



}
