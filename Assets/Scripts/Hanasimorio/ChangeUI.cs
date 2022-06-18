using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeUI : MonoBehaviour
{

    public Chara[] chara;//キャラのクラスを配列化

    [SerializeField] private Image image;//Mainのイラスト

    [SerializeField] private Text NameText;//名前を表示するテキスト

    [SerializeField] private Text DesText;//キャラクターの説明を表示するテキスト

    private int charanumber;//キャラが何人いるか

    private int now = 0;//今閲覧している番号

    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject Iconbutton1;

    [SerializeField] private GameObject Iconbutton2;

    [SerializeField] private GameObject Iconbutton3;

    [SerializeField] private GameObject Iconbutton4;

    private Image image1;

    private Image image2;

    private Image image3;

    private Image image4;

    private int Iconnow = 0;



    // Start is called before the first frame update
    void Start()
    {

        //image = GameObject.Find("MainImage").GetComponent<Image>();

        //NameText = GameObject.Find("NameText").GetComponent<Text>();

        //DesText = GameObject.Find("DescriptionText").GetComponent<Text>();


        /*
        image1 = Iconbutton1.transform.GetChild(0).GetComponent<Image>();

        image2 = Iconbutton2.transform.GetChild(0).GetComponent<Image>();

        image3 = Iconbutton3.transform.GetChild(0).GetComponent<Image>();

        image4 = Iconbutton4.transform.GetChild(0).GetComponent<Image>();
        */


        image1 = Iconbutton1.GetComponent<Image>();

        image2 = Iconbutton2.GetComponent<Image>();

        image3 = Iconbutton3.GetComponent<Image>();

        image4 = Iconbutton4.GetComponent<Image>();



        charanumber = chara.Length-1;

        FirstSet();
        SetIcon(Iconnow);
        Debug.Log(Iconnow);
        
        //if(canvas.activeSelf)
        //canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void FirstSet()
    {
        image.sprite = chara[now].charaim;

        NameText.text = chara[now].charaname;

        DesText.text = chara[now].charadesc;


    }

    private void SetChara(int num)
    {
        image.sprite = chara[num].charaim;

        NameText.text = chara[num].charaname;

        DesText.text = chara[num].charadesc;
    }


    public void RightArrow()
    {
        if(now < charanumber)
        {
            now += 1;

            SetChara(now);
        }
        else//一周できるように
        {
            now = 0;
            SetChara(now);
        }
    }

    public void LeftArrow()
    {
        if(now > 0)
        {
            now -= 1;
            SetChara(now);
        }
        else//一周できるように
        {
            now = chara.Length - 1;
            SetChara(now);
        }
    }


    public void ShowZukan()
    {
        canvas.SetActive(true);
    }

    public void HideZukan()
    {

        now = 0;
        Iconnow = 0;

        FirstSet();
        SetIcon(Iconnow);


        canvas.SetActive(false);
    }


    //アイコンエリア


    private  void SetIcon(int num)
    {

        image1.sprite = chara[num].charaicon;

        if (num + 1 < charanumber)
        {
            image2.sprite = chara[num + 1].charaicon;
            if (!Iconbutton2.activeSelf)
                Iconbutton2.SetActive(true);
        }
        else
            Iconbutton2.SetActive(false);

        if (num + 2 < charanumber)
        {
            image3.sprite = chara[num + 2].charaicon;
            if (!Iconbutton3.activeSelf)
                Iconbutton3.SetActive(true);
        }

        else
            Iconbutton3.SetActive(false);

        if (num + 3 < charanumber+1)
        {
            image4.sprite = chara[num + 3].charaicon;
            Debug.Log(Iconnow);
            if (!Iconbutton4.activeSelf)
                Iconbutton4.SetActive(true);

        }
        else
            Iconbutton4.SetActive(false);




    }

    public void  IconRightArrow()
    {
        if(Iconnow + 4 <= charanumber)
        {
            Iconnow += 4;

            SetIcon(Iconnow);

        }

    }

    public void IconLeftArrow()
    {
        if(Iconnow - 4 >= 0)
        {
            Iconnow -= 4;

            SetIcon(Iconnow);

        }

    }

    public void button1()
    {

        SetChara(Iconnow);
        now = Iconnow;

    }

    public void button2()
    {

        SetChara(Iconnow+1);
        now = Iconnow + 1;

    }
    public void button3()
    {
        SetChara(Iconnow + 2);
        now = Iconnow + 2;
    }
    public void button4()
    {
        SetChara(Iconnow + 3);
        now = Iconnow + 3;
    }

}

[System.Serializable] //キャラの詳細クラス
public class Chara
{
    public string name;

    [Header("キャライラスト")]
    public Sprite charaim;

    [Header("キャラの名前")]
    public string charaname;

    [Header("キャラの説明"),TextArea(1,6)]
    public string charadesc;

    [Header("キャラのアイコン")]
    public Sprite charaicon;

}
