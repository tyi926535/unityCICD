using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class KeyLock : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField keyT;
    public GameObject Error1;
    public InputField keyT2;
    public GameObject Error2;
    public GameObject keyLock1;
    private string yu1 = "C:/HTG Locker/bd.txt";

    public void KeyError()
    {
        Error1.SetActive(false);
        Error2.SetActive(false);
        if ((keyT.text != "")&& (keyT2.text != ""))
        {
            if (keyT.text != keyT2.text) { Error2.SetActive(true); }
            else { KeyProverka(); }
        }
        else
        {
            Error1.SetActive(true);
        }


    }
    async void KeyProverka()
    {
        //Debug.Log("keyT.text3="+ keyT.text);
        string keyFail = "";
        if (System.IO.File.Exists(yu1))
        {
            using (StreamReader reader = new StreamReader(yu1))
            {
                string line4;
                while ((line4 = await reader.ReadLineAsync()) != null)
                {
                    keyFail=line4; break;
                }
            }
        }
       // keyFail=keyFail.Trim('&');//////////////////////////////////////////////////////////
        //Debug.Log("keyFail=" + keyFail);
        if (keyFail != keyT.text) { ExitError(); }
        else { keyLock1.SetActive(false);
            keyT.text = string.Empty;
            keyT2.text = string.Empty;
        }

    }

    public void ExitError()
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
