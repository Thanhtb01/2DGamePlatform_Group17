using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject [] skillSpecials;
    private Level lv;
    private bool activeSkill = false;
    private bool activeForceField = false;
    private void Start()
    {
        lv = GetComponent<Level>();
        foreach(GameObject skill in skillSpecials)
        {
            skill.SetActive(false);
        }
    }
    public void setFrameSkill()
    {
        if(activeSkill == false)
        {
            skillSpecials[1].SetActive(true);
            activeSkill = true;
        }
        else
        {
            skillSpecials[1].GetComponent<SkillSpecial>().timeToAttack /= 1.1f;
        }
    }
    public void setForceFieldSkill()
    {
        if (activeForceField == false)
        {
            skillSpecials[0].SetActive(true);
            activeForceField = true;
        }
        else
        {
            skillSpecials[0].GetComponent<forceFieldScript>().damage += 5;
        }
    }
    //public void updateForceFieldSkill()
    //{
    //    skillSpecials[1].GetComponent<forceFieldScript>().damage += 5;
    //}
    //public void updateFrameSkill()
    //{
    //    skillSpecials[1].GetComponent<SkillSpecial>().timeToAttack /= 1.1f;
    //}
    //private void Update()
    //{
    //    for(int i = 1; i <= skillSpecials.Length; i++)
    //    {
    //        if (lv.level > 3*i)
    //        {
    //            skillSpecials[i-1].SetActive(true);
    //        }
    //    }
    //}
}
