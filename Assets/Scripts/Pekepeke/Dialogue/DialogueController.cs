using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public HomeButtonManager homebuttonmanager;

    [SerializeField] public TextAsset dialogueTextAsset = default;
    [SerializeField] public Text dialogueText;
    [SerializeField] public TextAsset charanameAsset = default;
    [SerializeField] public Text charanameText;

    public string[] splitDialogue;
    public string dialogueData;

    public string[] splitCharaname;
    public string charanameData;

    public Animator Manim;
    public Animator Aanim;
    public Animator Sanim;

    // Start is called before the first frame update
    void Start()
    {
        dialogueData = dialogueTextAsset.text;
        splitDialogue = dialogueData.Split('\n');

        charanameData = charanameAsset.text;
        splitCharaname = charanameData.Split('\n');


    }
    public void OnClick()
    {
        if(homebuttonmanager.Charaid == 0)
        {
            Manim.SetBool("angry", false);
            Manim.SetBool("excited", false);
            Manim.SetBool("happy", false);
            Manim.SetBool("sad", false);
            Manim.SetBool("surprised", false);
            int Mrandom = Random.Range(0, 5);
            dialogueText.text = splitDialogue[Mrandom];
            charanameText.text = splitCharaname[0];
            if(Mrandom == 0)
            {
                Manim.SetBool("angry", true);
            }
            if (Mrandom == 1)
            {
                Manim.SetBool("excited", true);
            }
            if (Mrandom == 2)
            {
                Manim.SetBool("happy", true);
            }
            if (Mrandom == 3)
            {
                Manim.SetBool("sad", true);
            }
            if (Mrandom == 4)
            {
                Manim.SetBool("surprised", true);
            }
        }

        if (homebuttonmanager.Charaid == 1)
        {
            Aanim.SetBool("happy", false);
            Aanim.SetBool("sad", false);
            Aanim.SetBool("surprise", false);
            Aanim.SetBool("trouble", false);
            Aanim.SetBool("zoi", false);
            int Arandom = Random.Range(5, 10);
            dialogueText.text = splitDialogue[Arandom];
            charanameText.text = splitCharaname[1];
            if (Arandom == 5)
            {
                Aanim.SetBool("happy", true);
            }
            if (Arandom == 6)
            {
                Aanim.SetBool("sad", true);
            }
            if (Arandom == 7)
            {
                Aanim.SetBool("surprise", true);
            }
            if (Arandom == 8)
            {
                Aanim.SetBool("trouble", true);
            }
            if (Arandom == 9)
            {
                Aanim.SetBool("zoi", true);
            }
        }

        if (homebuttonmanager.Charaid == 2)
        {
            Sanim.SetBool("disappointed", false);
            Sanim.SetBool("happy", false);
            Sanim.SetBool("lucky", false);
            Sanim.SetBool("sad", false);
            Sanim.SetBool("surprise", false);
            Sanim.SetBool("trouble", false);
            int Srandom = Random.Range(10, 16);
            dialogueText.text = splitDialogue[Srandom];
            charanameText.text = splitCharaname[2];
            if (Srandom == 10)
            {
                Sanim.SetBool("disappointed", true);
            }
            if (Srandom == 11)
            {
                Sanim.SetBool("happy", true);
            }
            if (Srandom == 12)
            {
                Sanim.SetBool("lucky", true);
            }
            if (Srandom == 13)
            {
                Sanim.SetBool("sad", true);
            }
            if (Srandom == 14)
            {
                Sanim.SetBool("surprise", true);
            }
            if (Srandom == 15)
            {
                Sanim.SetBool("trouble", true);
            }
        }

    }
    
}
