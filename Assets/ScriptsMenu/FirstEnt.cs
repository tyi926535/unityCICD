
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FirstEnt : MonoBehaviour
{
    public InputField textPassw;
    public InputField textPassw2;
    public GameObject ErrorName1;
    public GameObject ErrorName3;
    public GameObject Ballusers;
    public GameObject Badduser;
    public GameObject FirstEntrance;
    // Start is called before the first frame update


    public void Debager2()
    {
        string tPas = textPassw.text;
        string p2 = "";
        string tPas2 = textPassw2.text;
        p2 = "";
        foreach (char r in tPas)
        {
            if (r != ' ') { p2 += r; }
        }
        tPas = p2;
        ErrorName1.SetActive(false);
        ErrorName3.SetActive(false);
        if (tPas.Length < 1) { ErrorName1.SetActive(true); }
        else
        {
                if (tPas != tPas2) { ErrorName3.SetActive(true); }
                else
                {
                string[] str1=new string[4];
                str1[0] = "ADMIN"; str1[1] = tPas; str1[2] = "1"; str1[3] = "0";

                AccessPoint.AUusernow(str1);
                AccessPoint.AUbd(str1);
                
                        ModeSelection();
                }
        }
    }

    private void ModeSelection()
    {
        Badduser.SetActive(true);
        Ballusers.SetActive(true);
        FirstEntrance.SetActive(false);
        textPassw.text = string.Empty;
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
