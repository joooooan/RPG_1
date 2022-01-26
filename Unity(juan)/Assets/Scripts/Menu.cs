using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void ReTurnTitle()
    {
        LoadManager.LoadScene("TitleScene");
    }
    public void Option()
    {

    }

    public void GameExit()
    {
        Application.Quit();
    }

}
