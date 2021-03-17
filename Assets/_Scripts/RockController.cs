using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    protected GameManager gm;
    protected float angle = 0;

    public GameObject pedra;
    // public GameObject explosao;

   void Start(){
       gm = GameManager.GetInstance();
       pedra.GetComponent<SpriteRenderer>().enabled = true;
   }


    private void OnTriggerEnter2D(Collider2D collision){
        // gm.vidas --;

        //PQ A ANIMACAO NAO TA FUNCIONANDO?
        // explosao.GetComponent<SpriteRenderer>().enabled = true;


        pedra.GetComponent<SpriteRenderer>().enabled = true;
    }


   void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;   
    }


}
