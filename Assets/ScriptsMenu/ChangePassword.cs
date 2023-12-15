using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Unity.VisualScripting;
using System.ComponentModel;

public class ChangePassword : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField TP;
    public InputField TPN;
    public InputField TPN2;
    public InputField TP2;
    public GameObject Error1;
    public GameObject Error2;
    public GameObject Error3;
    public GameObject Error4;
    public GameObject Window1;
    private string login1 = "";
    private string userNowStr = "";

    private int cx = 0;

    private void ComparisonPassword()
    {
        string[] gh=new string[3];
        gh=AccessPoint.UserGet();
        string pas = gh[1]; string num = gh[2]; string nameNow = gh[0];

        string tp1 = TP.text;
        string tp2 = TP2.text;
        string tpn1 = TPN.text;
        string tpn2 = TPN2.text;
        string p2 = "";
        string pn2 = "";
        foreach(char r in tp1)
        {
            if(r!=' ') { p2 += r; }
        }
        tp1 = p2;
        foreach (char r in tpn1)
        {
            if (r != ' ') { pn2 += r; }
        }
        tpn1 = pn2;
        int f = tpn1.Length;
        if (num == "") { num = "0"; }
        int f2 = Convert.ToInt32(num);
        int fg = 0;
        Error1.SetActive(false);
        Error2.SetActive(false);
        Error3.SetActive(false);
        Error4.SetActive(false);
        if (tp1 != pas) { Error1.SetActive(true); }
        else
        {
            fg++;
            if (f < f2)
            {
                Error2.SetActive(true);
                GameObject recod11 = Error2.transform.Find("numberText").gameObject;
                recod11.GetComponent<Text>().text = f2.ToString();
            }
            else { 
            if (tp1 != tp2) { Error3.SetActive(true); }
            else{
                  if (tpn1 != tpn2) { Error4.SetActive(true); }
                    else
                    {
                        fg++;
                        if (fg == 2)
                        {
                            cx = 1;
                            AccessPoint.AUusernow2(tpn1);
                            AccessPoint.AUbd3(nameNow, tpn1);
                        }
                        else { cx = 0; }
                        if (cx == 1)
                        {
                            RewriteText();
                            Window1.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    private void RewriteText()//Переписывание файла
    {
        
        TP.text = string.Empty;
        TPN.text = string.Empty;
        TP2.text = string.Empty;
        TPN2.text = string.Empty;

    }

    public void ChangePas()
    {
        string tp1 = TP.text;
        string tpn1 = TPN.text;
        ComparisonPassword();

    }
    void Start()
    {

    }

}
