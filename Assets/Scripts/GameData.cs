using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public GeneeralGameData geneeralGameData;
    void Awake()
    {
        instance=this;
    }
[System.Serializable]
  public class GeneeralGameData
  {
      public List<WayPointsProfill> pointsProfills;
      public WayPointsProfill FindWayPoints
      {
        get
        {

           return pointsProfills[Random.Range(0,pointsProfills.Count)];
        }
      }
   
      [System.Serializable]
    public class WayPointsProfill
    {    
         public Transform waypoints;
        public List<Transform> sonrakiyollar;
        public Transform FindRandomsonrakiPoint
        {
            get
            {
               return sonrakiyollar[Random.Range(0,sonrakiyollar.Count)];
            }
        }
         
    }
  }
}
