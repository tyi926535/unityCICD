using System.Collections;//динамические массивы
using System.Collections.Generic;
using UnityEngine;//стандартные классы
using UnityEngine.UI;
using System.IO;
using System;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;


public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //[NonSerialized] public int ui = 9;//Поле не отображается в юнити хотя и public

    //[SerializeField]private int rt=89;//Поле отображается в юнити хотя и private
    //public int[] numb67 = new int[3];


    public GameObject Entrance1;//////////////////////////////////////
    public GameObject Entrance2;//////////////////////////////////////


    void Start()//выполняется при старте игры
    {
        int ty = 0;
        ty = AccessPoint.chekingNull();
        if (ty==0)
        {
            Entrance1.SetActive(true);
            Entrance2.SetActive(false);
        }
        else
        {
            Entrance1.SetActive(false);
            Entrance2.SetActive(true);
        }

                }
    //void Info(){}
    // Update is called once per frame
    //void Update(){}
    public void OnDestroy()
    {
        Application.Quit();
    }
    //private void OnDestroy(){ //срабатывает во время уничтожения объекта}
    //private void OnEnable(){ //срабатывает при включении объекта}
    //private void OnDisable(){ //срабатывает при отключении объекта}



}
