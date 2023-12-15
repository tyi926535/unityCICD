using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UI;

public class ListUser2 : MonoBehaviour
{
    public GameObject conteiner;
    public GameObject conteiner1;
    public GameObject conteinerAdmin;
    public Button btn1;
    public Transform content2;
    public Sprite krest;
    public Sprite gal;
    private List<int> activeFlag = new List<int>();
    //private List<GameObject> UserData = new List<GameObject>();


    public void ExLU()
    {
        int g = 0;
        if (content2.childCount > 0)
        {
            List<GameObject> usersChild = new List<GameObject>();

            RewriteText();
        }
    }
    public void RewriteText()//Переписывание файла
    {
        List<GameObject> UserData = new List<GameObject>();

        for (int i = 0; i < content2.childCount; i++)
        {
            UserData.Add(content2.GetChild(i).gameObject);
        }
        int ty = 0;
        ty = AccessPoint.chekingNull();
        foreach (var i in UserData)
        {
            string[] str3 = new string[3];
            GameObject recod1 = i.transform.Find("tlogin").gameObject;
            str3[0] = recod1.GetComponent<Text>().text;
            GameObject recod3 = i.transform.Find("tamount").gameObject;
            GameObject recod31 = recod3.transform.Find("Text (Legacy)").gameObject;
            str3[1] = recod31.GetComponent<Text>().text;
            GameObject recod32 = i.transform.Find("tamount2").gameObject;
            string amount2 = recod32.GetComponent<Text>().text;
            if (str3[1] == "") { str3[1] = amount2; }
            GameObject recod4 = i.transform.Find("tactive").gameObject;
            var t = recod4.GetComponent<Button>().image.sprite;
            int g = 0;
            if (t == gal) { g = 1; }
            else if (t == krest) { g = 0; }
            str3[2] = g.ToString();
            AccessPoint.AUbd2(str3);
        }

            btn1.GetComponent<Button>().onClick.Invoke();
    }
       

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
