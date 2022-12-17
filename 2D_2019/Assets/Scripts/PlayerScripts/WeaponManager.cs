    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectContainer;
    [SerializeField] WeaponData startingWeapon;
    private void Start()
    {
        AddWeapon(startingWeapon);
    }
    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectContainer);

    }
}
