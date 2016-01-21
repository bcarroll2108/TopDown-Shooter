using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour {


    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

}
