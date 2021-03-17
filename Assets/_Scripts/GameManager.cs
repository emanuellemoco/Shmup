using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }
    public int vidas;
    public int pontos;
    public int vidasInimigo;
    

    UI_Timer ui_ti;
    public float timeLeft;

   
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;



    public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

    private GameManager()
   {
       vidas = 10;
       pontos = 0;
       vidasInimigo = 100;
       timeLeft = 60f; //MUDAR AQUIII
       gameState = GameState.MENU;
       lastState = GameState.MENU;
   }
   
   public void ChangeState(GameState nextState)
    {
    if (nextState == GameState.GAME && gameState == GameState.MENU)  Reset();
        lastState = gameState;
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 10; 
        pontos = 0; 
        vidasInimigo = 100;
        timeLeft = 60f; //MUDAR AQUIII
    }


}