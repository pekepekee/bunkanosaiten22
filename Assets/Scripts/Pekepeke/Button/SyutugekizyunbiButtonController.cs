using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SyutugekizyunbiButtonController : MonoBehaviour
{
    public List<GameObject> skillList;

    static public int Stageid = 0;

    public void MippanDisplay()
    {
        skillList[0].SetActive(true);
    }

    public void MippannNotDisplay()
    {
        skillList[0].SetActive(false);
    }

    public void MultDisplay()
    {
        skillList[1].SetActive(true);
    }

    public void MultNotDisplay()
    {
        skillList[1].SetActive(false);
    }

    public void AippanDisplay()
    {
        skillList[2].SetActive(true);
    }

    public void AippanNotDisplay()
    {
        skillList[2].SetActive(false);
    }

    public void AultDisplay()
    {
        skillList[3].SetActive(true);
    }
    public void AultNotDisplay()
    {
        skillList[3].SetActive(false);
    }

    public void SippanDisplay()
    {
        skillList[4].SetActive(true);
    }
    public void SippanNotDisplay()
    {
        skillList[4].SetActive(false);
    }

    public void SultDisplay()
    {
        skillList[5].SetActive(true);
    }

    public void SultNotDisplay()
    {
        skillList[5].SetActive(false);
    }

    public void Set11()
    {
        Stageid = 0;
    }


    public void GoGame()
    {
        if(Stageid == 0)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}
