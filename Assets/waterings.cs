using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watering : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    private void Update()
    {
        MouseFollowWithOffset();
    }


    public void Attack()
    {

    }

    private void MouseFollowWithOffset()
    {

    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
