using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListUsers : MonoBehaviour
{
    public GameObject conteiner;
    public GameObject conteiner1;
    public GameObject conteinerAdmin;
    public Transform content2;
    public Sprite krest;
    public Sprite gal;
    private List<int> activeFlag = new List<int>();
    private List<GameObject> UserData = new List<GameObject>();
    
    public void OnEnable()
    {
        int f = 0; int k = 0;
        int ty = 0;
        ty = AccessPoint.chekingNull();

        for (int i = 1; i < ty; i++)
        {
            string[] str4 = new string[4];
            str4 = AccessPoint.UserSearch2(i);

            GameObject nConteiner = Instantiate(conteiner, transform.position, Quaternion.identity);

            GameObject recod1 = nConteiner.transform.Find("tlogin").gameObject;
            recod1.GetComponent<Text>().text = str4[0];
            GameObject recod3 = nConteiner.transform.Find("tamount").gameObject;
            GameObject recod321 = nConteiner.transform.Find("tamount2").gameObject;
            GameObject recod311 = recod3.transform.Find("Placeholder").gameObject;
            recod311.GetComponent<Text>().text = str4[2];
            recod321.GetComponent<Text>().text = str4[2];
            if (str4[3] == "0")
            {
                GameObject recod4 = nConteiner.transform.Find("tactive").gameObject;
                recod4.GetComponent<Button>().image.sprite = krest;
                activeFlag.Add(0);
            }
            else
            {
                GameObject recod4 = nConteiner.transform.Find("tactive").gameObject;
                recod4.GetComponent<Button>().image.sprite = gal;
                activeFlag.Add(1);
            }

            nConteiner.transform.SetParent(content2);
            //recod1.GetComponent<Button>().text=str4[0];
            UserData.Add(nConteiner);

        }
    }

    public void OnDisable()
    {
        int g = 0;
        if (content2.childCount > 0)
        {
            //Debug.Log("2G(content2.childCount > 0)");
            List<GameObject> usersChild = new List<GameObject>();
            for (int i = 0; i < content2.childCount; i++)
            {
                usersChild.Add(content2.GetChild(i).gameObject);
            }
            foreach (var t in usersChild)
            {
                { Destroy(t); }
            }

        }

    }

}
