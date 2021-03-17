using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject tiro;
    protected GameManager gm;
    protected float angle = 0;

   void Start(){
       gm = GameManager.GetInstance();
   }

    public void Shoot()
    {
        // Debug.Log("ataque");
        Instantiate(tiro, transform.position, Quaternion.identity);
        
        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        // gm.vidasInimigo --;
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);

        
        gm.pontos += 10;
        // gm.vidasInimigo -= 5;
    }

   void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;

       //se estiver em GAME e acabar as vidas do inimigo, ganha
       if (gm.vidasInimigo <= 0 && gm.gameState == GameManager.GameState.GAME)
       { 
            gm.ChangeState(GameManager.GameState.ENDGAME);

       }
        
    }


    private void FixedUpdate()
    {   
        // if (gm.gameState != GameManager.GameState.GAME) return;
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        
        // Thrust(x, y);
       
    }
}
