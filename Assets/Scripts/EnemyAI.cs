using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyAI : MonoBehaviour
{
    public static List<EnemyAI> enemies= new List<EnemyAI>();
   public Transform target;
   public EnemyState enemyState;
   public Sprite agresifsprite;
   public Sprite korkaksprite;
  
    void Awake()
    {
        enemies.Add(this);
       
        
    }
   
    void OnDestroy()
    {
        enemies.Remove(this);
            
     
    }
    void Start()
    {
       // A ,B,C 
       GameData.GeneeralGameData.WayPointsProfill firstpoint=GameData.instance.geneeralGameData.FindWayPoints;
       transform.position=firstpoint.waypoints.position;
       target=firstpoint.FindRandomsonrakiPoint;

    }

    // Update is called once per frame
    void Update()
    {
        GoToPositon();
        
    }
    public void GoToPositon()
    {  
       if(target==null) return;
       transform.position=Vector3.MoveTowards(transform.position,target.position,0.02f);
       if(Vector3.Distance(transform.position,target.position)<0.01f)
       {
              SonrakiNoktayıBul();
       }
    }
    public void SonrakiNoktayıBul()
    {   
        GameData.GeneeralGameData.WayPointsProfill targetprofil=GameData.instance.geneeralGameData.pointsProfills.Find(x=>x.waypoints==target);
        target=targetprofil.FindRandomsonrakiPoint;

        
    }
    
    public void Korkak()
    {
     enemyState=EnemyState.korkak;
     transform.GetComponent<SpriteRenderer>().sprite=korkaksprite;
    }
    public void Agresif()
    {
      enemyState=EnemyState.agresif;
       transform.GetComponent<SpriteRenderer>().sprite=agresifsprite;

    }


    public enum EnemyState
    {
        agresif=0,korkak=1
    }
}
