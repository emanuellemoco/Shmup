using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player; 
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();      
    }


  void Construir()
  {    
    //   Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

      
       if (gm.gameState == GameManager.GameState.GAME && gm.lastState == GameManager.GameState.MENU)
      {
        // Debug.Log($"ENTROU 1");

        foreach (Transform child in transform) { 
            GameObject.Destroy(child.gameObject);
        }

        // Debug.Log($"X: {x} \t | \t Y: {y}");
    
        Vector3 posicao = new Vector3(0, 0, 0);
        Instantiate(Player, posicao, Quaternion.identity, transform);
        

      }

  }

    // Update is called once per frame
    void Update()
    {


    }
}