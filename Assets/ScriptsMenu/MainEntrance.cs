using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.IO;
using System;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MainEntrance : MonoBehaviour
{
    // Start is called before the first frame update

    public Text textName;
    private int attempts = 0;
    public InputField textName2;
    public InputField textPassw;
    public GameObject ErrorName1;
    public GameObject ErrorName2;
    public GameObject Ballusers;
    public GameObject Badduser;
    public GameObject Entrance;

    public async void Debager2()
    {
        string tName = textName.GetComponent<Text>().text;
        string tPas = textPassw.text;
        string n2 = "";
        string p2 = "";
        foreach (char r in tPas)
        {
            if (r != ' ') { p2 += r; }
        }
        tPas = p2;
        foreach (char r in tName)
        {
            if (r != ' ') { n2 += r; }
        }
        tName = n2;
        string[] fil=new string[4];
        fil=AccessPoint.UserSearch(tName, tPas);


        // fil[0]--name  fil[1]--password  fil[2]--active fil[3]--length
        if (fil[0] == "") { ErrorName1.SetActive(true); ErrorName2.SetActive(true); attempts++; }
        else
        {
            if ((fil[0] == tName) && (fil[1] != tPas) && (fil[2] == "1")) { ErrorName1.SetActive(false); ErrorName2.SetActive(true); attempts++; }
            if ((fil[0] != tName) || (fil[2] == "0")) { ErrorName1.SetActive(true); ErrorName2.SetActive(false); attempts++; }
            if ((fil[0] == tName) && (fil[1] == tPas) && (fil[2] == "1"))
            {
                ErrorName1.SetActive(false); ErrorName2.SetActive(false);
                AccessPoint.AUusernow(fil);
                ModeSelection(fil[0]);
            }
        }
        if (attempts > 2)
        {
            Exit2();
        }

    }

    private void ModeSelection(string nName)
    {
        if (nName == "ADMIN")
        {
            Badduser.SetActive(true);
            Ballusers.SetActive(true);
        }
        else
        {
            Badduser.SetActive(false);
            Ballusers.SetActive(false);
        }

        Entrance.SetActive(false);
        textPassw.text = string.Empty;
        textName2.text = string.Empty;


    }
    public void Exit2()
    {
        Application.Quit();
    }





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
