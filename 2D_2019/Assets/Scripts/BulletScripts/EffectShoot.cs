using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hitEffect;
    public void ShootEffect()
    {
        if(hitEffect == null)
        {
            return;
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }
    
}
