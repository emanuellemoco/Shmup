using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour
{

  private Vector3 direction;
  GameManager gm;

  private void OnTriggerEnter2D(Collider2D collision)
  {
      // if (collision.CompareTag("Inimigos") ) return; //inimigo nao destroi inimigo

      if (collision.CompareTag("Inimigos") || collision.CompareTag("TiroInimigo") ) return; //inimigo nao destroi inimigo

      IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
      if (!(damageable is null))
      {
          damageable.TakeDamage();
      }
      Destroy(gameObject);
  }

   void Start(){
         gm = GameManager.GetInstance();

           if (gm.gameState == GameManager.GameState.MENU ){
              foreach (Transform child in transform) { 
            GameObject.Destroy(child.gameObject);
        }
    }
   }

  void Update()
  {
    //para o jogo congelar se nao tiver no play:
    // if (gm.gameState != GameManager.GameState.GAME) return;

    if (gm.gameState != GameManager.GameState.GAME) return;

 
      if (GameObject.FindWithTag("Player") == null){return;}
    //O Aluno Rafael Almada me ajudou nessa parte.
    float dist = Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);
    if (dist > 5.0f) {
      Destroy(gameObject);
    }

      //faz com que o tiro do inimigo siga o jogador o tempo todo
      if (GameObject.FindWithTag("Player") == null){return;}
      Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
      direction =  (posPlayer - transform.position).normalized;
      Thrust(direction.x, direction.y);
  }

  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}