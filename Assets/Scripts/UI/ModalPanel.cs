using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour
{
    public Text question;
    public Image iconImage;
    public Button yesButton;
    public Button cannonButton;
    public Button CrossbowButton;
    public Button LauncherButton;
    public Button upgradeButton;
    public Button cancelButton;
    public GameObject modalPanelObject;
    public Button sellbutton;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There need to be on active ModalPanel script on a GameObject in your scene.");
        }
        return modalPanel;
    }

    //cannon/ crossbow/ launcher/ cancel; A string, a yes event, no event, cancel event
    public void Choice (string question, UnityAction cannonEvent, UnityAction crossbowEvent, UnityAction LauncherEvent, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);
        cannonButton.onClick.RemoveAllListeners();
        cannonButton.onClick.AddListener(cannonEvent); // call cannonEvent
        cannonButton.onClick.AddListener(ClosePanel); // call void closePanel()

        modalPanelObject.SetActive(true);
        CrossbowButton.onClick.RemoveAllListeners();
        CrossbowButton.onClick.AddListener(crossbowEvent); // call cannonEvent
        CrossbowButton.onClick.AddListener(ClosePanel); // call void closePanel()

        modalPanelObject.SetActive(true);
        LauncherButton.onClick.RemoveAllListeners();
        LauncherButton.onClick.AddListener(LauncherEvent); // call cannonEvent
        LauncherButton.onClick.AddListener(ClosePanel); // call void closePanel()

        modalPanelObject.SetActive(true);
        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(cancelEvent); // call cannonEvent
        cancelButton.onClick.AddListener(ClosePanel); // call void closePanel()


        this.question.text = question;

        this.iconImage.gameObject.SetActive(false);
        cannonButton.gameObject.SetActive(true);
        CrossbowButton.gameObject.SetActive(true);
        LauncherButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(false);
        upgradeButton.gameObject.SetActive(false);
        sellbutton.gameObject.SetActive(false);
        
    }

    //yes/cancel ; A string, a yes event, cancel event
    public void Choice(string question, UnityAction yesEvent, UnityAction cancelEvent, UnityAction sellEvent)
    {
        modalPanelObject.SetActive(true);
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(yesEvent); // call cannonEvent
        yesButton.onClick.AddListener(ClosePanel); // call void closePanel()

        modalPanelObject.SetActive(true);
        sellbutton.onClick.RemoveAllListeners();
        sellbutton.onClick.AddListener(sellEvent); // call cannonEvent
        sellbutton.onClick.AddListener(ClosePanel); // call void closePanel()


        modalPanelObject.SetActive(true);
        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(cancelEvent); // call cannonEvent
        cancelButton.onClick.AddListener(ClosePanel); // call void closePanel()


        this.question.text = question;

        this.iconImage.gameObject.SetActive(false);
        cannonButton.gameObject.SetActive(false);
        CrossbowButton.gameObject.SetActive(false);
        LauncherButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        upgradeButton.gameObject.SetActive(false);
        sellbutton.gameObject.SetActive(true);

    }




    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }

}
