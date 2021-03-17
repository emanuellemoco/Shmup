using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{
    GameManager gm;


   void Start(){
    gm = GameManager.GetInstance();

        if (gm.gameState == GameManager.GameState.MENU ){
            foreach (Transform child in transform) { 
        GameObject.Destroy(child.gameObject);
    }
}
   }

    private void OnTriggerEnter2D(Collider2D collision)
   {
       //Para evitar receber proprio tiro
       if (collision.CompareTag("Player")) return;
       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           damageable.TakeDamage();
       }
       Destroy(gameObject);
   }

    private void Update()
   {
        if (gm.gameState != GameManager.GameState.GAME) return;

    //O Aluno Rafael Almada me ajudou nessa parte.
    float dist = Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);
        if (dist > 15.0f) {
            Destroy(gameObject);
        }

        Thrust(1, 0);
   }


}
