using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public static InfoManager infoManagerInstance;
    void Start()
    {
        if (InfoManager.infoManagerInstance == null)
        {
            InfoManager.infoManagerInstance = this;
        }
        else
        {
            if (InfoManager.infoManagerInstance != null)
            {
                Destroy(InfoManager.infoManagerInstance.gameObject);
                InfoManager.infoManagerInstance = this;
            }
        }
    }
    [SerializeField] private GameObject _pressButtonDisplay;
    public void PressButtonInfo()
    {
        _pressButtonDisplay.SetActive(true);
    }
    public void UnpressButtonInfo()
    {
        _pressButtonDisplay.SetActive(false);
    }
}
