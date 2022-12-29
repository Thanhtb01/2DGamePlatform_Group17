using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLv : MonoBehaviour
{
    public OptionUpdate optionUpdate;
    [SerializeField] TMPro.TextMeshProUGUI nameOpt;
    [SerializeField] TMPro.TextMeshProUGUI detailOpt;
    public TMPro.TextMeshProUGUI coinOpt;
   
    private void Update()
    {
        nameOpt.text = optionUpdate.nameOp;
        detailOpt.text = optionUpdate.detail;
        coinOpt.text = optionUpdate.coin.ToString() + " coins";
    }
}
