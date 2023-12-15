using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;

public class AddUsers : MonoBehaviour
{

   
    public Text textName;
    public Text textPassword;
    public InputField tN;
    public InputField tP;
    public InputField tP2;
    public GameObject ErrorName1;
    public GameObject ErrorName2;
    public GameObject ErrorName3;
    public GameObject MenuAddUsers;
    // Start is called before the first frame update
    

    public void Debager()
    {
        var rName = textName.GetComponent<Text>().text;
        string nN = "";
        foreach (var t in rName)
        {
            if(t!=' ') { nN += t; }
        }
        rName = nN;
        ErrorName1.SetActive(false);
        ErrorName2.SetActive(false);
        ErrorName3.SetActive(false);
        if (rName == "") { ErrorName1.SetActive(true); }
        else
        {
            string timetext = "";
            int vb = 0; 
            vb=AccessPoint.UserSearch2(tN.text);

            if (vb > 0) { ErrorName2.SetActive(true); }
            else
            {
                if (tP.text != tP2.text) { ErrorName3.SetActive(true); }
                else
                {
                    string[] str4=new string[2];
                    str4[0] = tN.text;
                    str4[1] = tP.text;

                    AccessPoint.addUser(str4);

                    tN.text = string.Empty;
                    tP.text = string.Empty;
                    tP2.text = string.Empty;
                    MenuAddUsers.SetActive(false);
                }
            }

        }

    }


    void Start()
    {

    }

}
