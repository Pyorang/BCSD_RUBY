using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayControl : MonoBehaviour
{
    [SerializeField]
    private GameObject howDialog;

    public void OnHTPDialog()
    {
        howDialog.SetActive(true);
    }

    public void OffHTPDialog()
    {
        howDialog.SetActive(false);
    }
}
