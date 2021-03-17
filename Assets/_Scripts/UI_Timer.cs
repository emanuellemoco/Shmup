using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    //Based script from video https://www.youtube.com/watch?v=bcvLM_riVuw

    Image timerBar;
    private float maxTime = 60f; //lembrar de arrumar o timeleft no gamemanager
    public GameObject timesUpText;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        timesUpText.SetActive (false);
        timerBar = GetComponent<Image> ();
        
        gm = GameManager.GetInstance();
        gm.timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {   
        if (gm.gameState != GameManager.GameState.GAME) return;

        Time.timeScale= 1;


        if (gm.timeLeft>0){  //1 ou 2 PARA FICAR ESTETICAMENTE MAIS BONITO
            gm.timeLeft -= Time.deltaTime;
            timerBar.fillAmount = gm.timeLeft / maxTime;
        }
        else{
            // timesUpText.setActive(true);
            // timesUpText.SetActive (true);
            Time.timeScale= 0;
            gm.ChangeState(GameManager.GameState.ENDGAME);
         
        }

        if (gm.gameState == GameManager.GameState.ENDGAME){
            gm.timeLeft = maxTime;
        }
    }
}
