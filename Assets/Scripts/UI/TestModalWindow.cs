using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalWindow : MonoBehaviour
{
    private ModalPanel modalPanel;
    private DisplayManager displayManager;


    public GameObject cannon1;
    public GameObject crossbow1;
    public GameObject launcher1;

    public GameObject cannon2;
    public GameObject cannon3;

    public GameObject crossbow2;
    public GameObject crossbow3;

    public GameObject launcher2;
    public GameObject launcher3;

    public GameObject banner;

    public Transform spawnpoint;

    public Spawner spawner;


    public GameObject notEnoughMoney;


    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();
    }

    void update()
    {

        //moonBeamsText.text = (" " + moonbeams);

    }

    // Send to the modal panel to set up the buttons and functions to call
    public void CreateWeaponLambda( )
    {
        modalPanel.Choice("Choose a Weapon",  createCannon,  createCrossbowFunction, createLauncherFunction, cancelFunction);
       
    }


    public void upgradeCannonLvl2()
    {
        modalPanel.Choice("6 moonbeams to upgrade to level 2 cannon? \n Time Between shots is half \n Longer range", yesLevel2CannonFunction, cancelFunction, sellFunction);
    }

    public void upgradeCannonLvl3()
    {
        modalPanel.Choice("7 moonbeams to upgrde to level 3 cannon? \n Time Between shots is half  \n Longer range", yesLevel3CannonFunction, cancelFunction, sellFunction);
    }

    public void upgradeCrossbowLvl2()
    {
        modalPanel.Choice("4 moonbeams to upgrade to level 2 crossbow? \n Time Between shots is half  \n Longer range", yesLevel2CrossbowFunction, cancelFunction, sellFunction);
    }

    public void upgradeCrossbowLvl3()
    {
        modalPanel.Choice("5 moonbeams to upgrade to level 3 crossbow? \n Time Between shots is half  \n Longer range", yesLevel3CrossbowFunction, cancelFunction, sellFunction);
    }

    public void upgradeLauncherLvl2()
    {
        modalPanel.Choice("8 moonbeams to upgrade to level 2 launcher? \n Time Between shots is half  \n Longer range", yesLevel2LauncherFunction, cancelFunction, sellFunction);
    }

    public void upgradeLauncherLvl3()
    {
        modalPanel.Choice("9 moonbeams to upgrade to level 3 launcher? \n Time Between shots is half  \n Longer range", yesLevel3LauncherFunction, cancelFunction, sellFunction);
    }

    //these are wrapped into unityActions
    public void createCannon()
    {
        spawner.buyCannon();
        if (spawner.canBuy == true)
        {
            cannon1.SetActive(true);
            banner.SetActive(false);
            Debug.Log("Cannon");
            spawner.canBuy = false;
        }

        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("not enough money");
        }

    }

    void createCrossbowFunction()
    {
        spawner.buyCrossbow();
        if (spawner.canBuy == true)
        {
            crossbow1.SetActive(true);
            banner.SetActive(false);
            Debug.Log("Crossbow");
            spawner.canBuy = false;
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("not enough money");
        }

    }

    void createLauncherFunction()
    {
        spawner.buyLauncher();
        if (spawner.canBuy == true)
        {
            launcher1.SetActive(true);
            banner.SetActive(false);
            Debug.Log("Launcher");
            spawner.canBuy = false;
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("not enough money");
        }

    }

    void cancelFunction()
    {
        Debug.Log("Cancel");
    }

    void yesLevel2CannonFunction()
    {
        spawner.upgradeCannon2();
        if (spawner.canUpgrade == true)
        {
            cannon1.SetActive(false);
            cannon2.SetActive(true);
            Debug.Log("True");
            Debug.Log("you cna upgrade");
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("you can't upgrade");
        }
            
    }


    void yesLevel3CannonFunction()
    {
        spawner.upgradeCannon3();
        if (spawner.canUpgrade == true)
        {
            cannon2.SetActive(false);
            cannon3.SetActive(true);
            Debug.Log("True");
            Debug.Log("you cna upgrade");
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("you can't upgrade");
        }
    }

    void yesLevel2CrossbowFunction()
    {
        spawner.upgradeCrossbow2();
        if (spawner.canUpgrade == true)
        {
            crossbow2.SetActive(true);
            crossbow1.SetActive(false);
            Debug.Log("True");
            Debug.Log("you cna upgrade");
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("you can't upgrade");
        }
    }

    void yesLevel3CrossbowFunction()
    {
        spawner.upgradeCrossbow3();
        if (spawner.canUpgrade == true)
        {
            crossbow2.SetActive(false);
            crossbow3.SetActive(true);
            Debug.Log("True");
            Debug.Log("you cna upgrade");
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("you can't upgrade");
        }
    }

    void yesLevel2LauncherFunction()
    {
        spawner.upgradeLauncher2();
        if (spawner.canUpgrade == true)
        {
            launcher1.SetActive(false);
            launcher2.SetActive(true);
            Debug.Log("True");
            Debug.Log("you cna upgrade");
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("you can't upgrade");
        }
    }

    void yesLevel3LauncherFunction()
    {
        spawner.upgradeLauncher3();
        if (spawner.canUpgrade == true)
        {
            launcher2.SetActive(false);
            launcher3.SetActive(true);
            Debug.Log("True");
            Debug.Log("you cna upgrade");
        }
        else
        {
            notEnoughMoney.gameObject.SetActive(true);
            Debug.Log("you can't upgrade");
        }
    }

    void sellFunction()
    {
        spawner.sellCannon();
        Debug.Log("sell");
    }

}
