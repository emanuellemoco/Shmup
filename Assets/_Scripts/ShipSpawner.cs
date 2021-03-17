using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject PurpleShip, YellowShip, Alien, Asteroid; //, BlocoVerde, BlocoPreto;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();      
    }

//direita = 530; 400
  void Construir()
  {    
      Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

  // Destruir todas as naves quando tiver no menu
    if (gm.gameState == GameManager.GameState.MENU ){
              foreach (Transform child in transform) { 
            GameObject.Destroy(child.gameObject);
        }
    }
    if (gm.gameState == GameManager.GameState.GAME && gm.lastState == GameManager.GameState.MENU)
    {

    // for(int i = 0; i < 2; i++){
        float x = Random.Range(9*posicaoVP.x/10,posicaoVP.x);
        float y = Random.Range(-posicaoVP.y,posicaoVP.y);
        // Debug.Log($"X: {x} \t | \t Y: {y}");
  
        Vector3 posicao = new Vector3(x, y, 0);
        int i = Random.Range(0,4);
        if (i != 0){
          Instantiate(PurpleShip, posicao, Quaternion.identity, transform);
        }
        Instantiate(YellowShip, posicao, Quaternion.identity, transform);


        //para instanciar a animacao
        int a = Random.Range(0,6);
        if (a >=4){
          x = Random.Range(9.8f*posicaoVP.x/10,posicaoVP.x);
          y = Random.Range(-posicaoVP.y,posicaoVP.y);
          posicao = new Vector3(x, y, 0);

          Instantiate(Alien, posicao, Quaternion.identity, transform);
        }
          if (a == 2){
          x = Random.Range(9.8f*posicaoVP.x/10,posicaoVP.x);
          y = Random.Range(-posicaoVP.y,posicaoVP.y);
          posicao = new Vector3(x, y, 0);

          Instantiate(Asteroid, posicao, Quaternion.identity, transform);
        }


    // }
    }
  }

    void Update()
    {
         float i = Random.Range(0,400);
         if (i==90){
           Construir();
         }
    }
}
