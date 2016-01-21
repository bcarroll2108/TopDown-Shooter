using UnityEngine;
using System.Collections;

public class SetCannonActive : MonoBehaviour
{
    public GameObject cannon;
    public GameObject cannon2;
    public GameObject cannon3;

    public void setActiveCannon()
    {
        cannon.SetActive(true);
    }

    public void setActiveCannon2()
    {
        cannon.SetActive(false);
        cannon2.SetActive(true); 
    }

    public void setActiveCannon3 ()
    {
        cannon.SetActive(false);
        cannon2.SetActive(false);
        cannon3.SetActive(true);
    }
}
