using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionExample : MonoBehaviour
{
    //şeker dükkanı saat 8-18 
    //kahve 12-24
    //market 9-15

    public int time=12;

    public Dukkan sekerdukkanı;
   
    public Dukkan kahvedukkanı;
    public Dukkan marketdukkanı;

    public List<Dukkan> dukkanlar =new List<Dukkan>();

    void Start()
    {
        sekerdukkanı.dukkanname="irem";
        dukkanlar.Add(sekerdukkanı);
         dukkanlar.Add(kahvedukkanı);
          dukkanlar.Add(marketdukkanı);
        sekerdukkanı.OpenCloseRule=()=>
        {
            return time>=8&&time<=18;
        };
        kahvedukkanı.OpenCloseRule=()=>
        {
            return time>=12 &&time<=24;
        };

        marketdukkanı.OpenCloseRule=()=>
        {
             return time>=9 &&time<=15;
        };
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            time+=1;
            if(time>24)
            {
              time=1;
            }
            
        }
         if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            time-=1;
            if(time<1)
            {
              time=24;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
          Debug.Log("Saat :"+time);
           foreach(var item in dukkanlar)
           {
            if(item.OpenCloseRule())
            {
                Debug.Log("Dükkan Açık :"+item.dukkanname);
            }
            else
            
                {
                   Debug.Log("Dükkan Kapalı "+item.dukkanname);
                }
            
           }
           Debug.Log("***************************");
           
        }
    }

   

}


public struct Dukkan
{
    
    public string dukkanname;
    public Func<bool> OpenCloseRule;
}



