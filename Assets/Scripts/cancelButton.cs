using UnityEngine;
using System.Collections;

public class cancelButton : MonoBehaviour
{
    public GameObject notEnoughMoney;

    public void cancel()
    {
        notEnoughMoney.SetActive(false);
    }
}
