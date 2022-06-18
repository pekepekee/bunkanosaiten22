using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButtonManager : MonoBehaviour
{
    public DialogueController dialoguecontroller;
    public List<GameObject> CharaList;
    public List<GameObject> BGList;
    public int Charaid = 0;
    public int BGid = 0;
    // Start is called before the first frame update

    private void Start()
    {
    }
    public void GoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GoJunbi()
    {
        SceneManager.LoadScene("SyutugekiZyunbi");
    }

    public void ChangeChara()
    {
        Charaid++;
        if (Charaid >= 3)
        {
            Charaid = 0;
        }
        for (int i = 0; i <= 2; i++)
        {
            CharaList[i].SetActive(false);
        }
        CharaList[Charaid].SetActive(true);
        if (Charaid == 0)
        {
            dialoguecontroller.dialogueText.text = dialoguecontroller.splitDialogue[Random.Range(0, 5)];
            dialoguecontroller.charanameText.text = dialoguecontroller.splitCharaname[0];
        }

        if (Charaid == 1)
        {
            dialoguecontroller.dialogueText.text = dialoguecontroller.splitDialogue[Random.Range(5, 10)];
            dialoguecontroller.charanameText.text = dialoguecontroller.splitCharaname[1];
        }

        if (Charaid == 2)
        {
            dialoguecontroller.dialogueText.text = dialoguecontroller.splitDialogue[Random.Range(10, 16)];
            dialoguecontroller.charanameText.text = dialoguecontroller.splitCharaname[2];
        }
    }

    public void ChangeBG()
    {
        BGid++;
        if(BGid >= 2)
        {
            BGid = 0;
        }
        for (int i = 0; i <= 2; i++)
        {
            BGList[i].SetActive(false);
        }
        BGList[BGid].SetActive(true);
    }
}
