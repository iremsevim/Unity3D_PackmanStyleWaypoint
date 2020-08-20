using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
      KarakterMovement();
    }
    public void KarakterMovement()
    {
        float rightleft=Input.GetAxis("Horizontal")*speed;
        float yukarıasagı=Input.GetAxis("Vertical")*speed;
        rb.velocity=new Vector2(rightleft,yukarıasagı);
        if(rightleft<0)
        {
            transform.eulerAngles=new Vector3(0,0,180);
        }
        else if(rightleft>0)
        {
            transform.eulerAngles=new Vector3(0,0,0);
        }
        else if(yukarıasagı<0)
        {
             transform.eulerAngles=new Vector3(0,0,-90);
        }
        else
        {
            transform.eulerAngles=new Vector3(0,0,90);
        }
    
     
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="yem")
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag=="büyükyem")
        {
            Destroy(other.gameObject);
           
            BüyükYemYendi();
        }
        else if(other.gameObject.tag=="enemy")
        {
                 DusmanaDegıldi(other.GetComponent<EnemyAI>());
        }
      
    }
    public void BüyükYemYendi()
    {
         foreach(var item in EnemyAI.enemies)
         {    
             item.Korkak();
         }
         StartCoroutine(recolor());
         IEnumerator recolor()
         {
             yield return new WaitForSeconds(10f);
             foreach(var item in EnemyAI.enemies)
         {    
             item.Agresif();
         }
             
         }

         
    }
    public void DusmanaDegıldi(EnemyAI enemy)
    {
      if(enemy.enemyState==EnemyAI.EnemyState.korkak)
      {
        Destroy(enemy.gameObject);

      }
      else
      {
       Debug.Log("GameOver");
      }
    }
    
    
}
