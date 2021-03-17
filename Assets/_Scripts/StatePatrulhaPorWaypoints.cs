using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulhaPorWaypoints : State
{
  public Transform[] waypoints;  
  SteerableBehaviour steerable;
  GameManager gm;
 
  public override void Awake()
  {
      base.Awake();
      if (GameObject.FindWithTag("Player") != null){

      
      // Configure a transição para outro estado aqui.
      Transition attacking = new Transition();
      attacking.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform, 2.0f);
      attacking.target = GetComponent<StateAtaque>();
      transitions.Add(attacking);
    }
      steerable = GetComponent<SteerableBehaviour>();

  }

  public void Start()
  {
      if (GameObject.FindWithTag("Player") != null){
      waypoints[0].position = transform.position;
      waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
      }
      gm = GameManager.GetInstance();
  }

  public override void Update()
  {
      if (gm.gameState != GameManager.GameState.GAME) return;

      //se a a distancia da posicao pro waypont for menor que 1
      //anda na direcao
      if(Vector3.Distance(transform.position, waypoints[1].position) > .1f) {
          Vector3 direction = waypoints[1].position - transform.position;
          direction.Normalize();
         steerable.Thrust(direction.x, direction.y);
      } else {
          waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
      }
  }
 
}