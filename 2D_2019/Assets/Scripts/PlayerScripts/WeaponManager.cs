using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject [] skillSpecials;
    private Level lv;
    private void Start()
    {
        lv = GetComponent<Level>();
        foreach(GameObject skill in skillSpecials)
        {
            skill.SetActive(false);
        }
    }
    private void Update()
    {
        for(int i = 1; i <= skillSpecials.Length; i++)
        {
            if (lv.level > i)
            {
                skillSpecials[i-1].SetActive(true);
            }
        }
    }
}
