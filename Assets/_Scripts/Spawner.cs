using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PurpleShip;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += ConstruirShip;
        ConstruirShip();   
        
    }



    void ConstruirShip()
    {    
      Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

      
       if (gm.gameState == GameManager.GameState.GAME && gm.lastState == GameManager.GameState.MENU)
      {
        // foreach (Transform child in transform) {
        //     GameObject.Destroy(child.gameObject);
        // }

        for(int i = 0; i < 4; i++){
           
            float x = Random.Range(9*posicaoVP.x/10,posicaoVP.x);
            float y = Random.Range(-posicaoVP.y,posicaoVP.y);
            Debug.Log($"X: {x} \t | \t Y: {y}");
      
            Vector3 posicao = new Vector3(x, y, 0);
            Instantiate(PurpleShip, posicao, Quaternion.identity, transform);   
        }

      }

  }

    //   void Construir()
    // {
    //     ConstruirShip();   
        
    // }




  void Reset(){
    //aARRUMAR
    // foreach (GameObject PurpleShip in GameObject.FindGameObjecstWithTag("inimigos"))
    // {
    //     Destroy(PurpleShip);
    // }

  }




    // Update is called once per frame
    void Update()
    {
      if (gm.gameState == GameManager.GameState.MENU){
        Reset();
      }

      float i = Random.Range(0,800);
      if (i==90){
        ConstruirShip();
      }
      else {
      }

    }
}
