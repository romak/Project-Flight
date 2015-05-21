using UnityEngine;
using System.Collections;

public class RsWeaponLauncherBase : MonoBehaviour
{

    [SerializeField]
    protected RsAmmoBase m_ammo;

    public virtual void Fire() { }



}
