using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanner : MonoBehaviour
{
    [SerializeField] Transform update1;
    [SerializeField] Transform update2;
    [SerializeField] Transform update3;
    [SerializeField] GameObject[] updateOpts;
    
    private void Update()
    {
        if(LevelUpController.instance.timer >= 3)
        {
            RandomUpdateOpt();
        }
    }
    public void RandomUpdateOpt()
    {
        GameObject upd1 = Instantiate(updateOpts[Random.Range(0, updateOpts.Length)], transform.position, transform.rotation);
        GameObject upd2 = Instantiate(updateOpts[Random.Range(0, updateOpts.Length)], transform.position, transform.rotation);
        GameObject upd3 = Instantiate(updateOpts[Random.Range(0, updateOpts.Length)], transform.position, transform.rotation);
        upd2.transform.SetParent(update2.transform, false);
        upd3.transform.SetParent(update3.transform, false);
        upd1.transform.SetParent(update1.transform, false);
        LevelUpController.instance.timer = 0;
    }

}
