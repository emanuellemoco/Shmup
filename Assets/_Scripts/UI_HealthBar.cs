using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    Image healthBar;
    private int maxLife = 10; //lembrar de arrumar o timeleft no gamemanager
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image> ();
        gm = GameManager.GetInstance();
        gm.vidas = maxLife;
    }

    // Update is called once per frame
    void Update()
    {   
        if (gm.gameState != GameManager.GameState.GAME) return;

        // 

        if (gm.vidas>0){ 
            // gm.timeLeft -= Time.deltaTime;
            // Debug.Log(gm.vidas);
            // Debug.Log(maxLife);
            // Debug.Log("-------");
            healthBar.fillAmount = gm.vidas / maxLife;
        }
        else{
            // timesUpText.setActive(true);
            // timesUpText.SetActive (true);
            gm.ChangeState(GameManager.GameState.ENDGAME);
         
        }

        if (gm.gameState == GameManager.GameState.ENDGAME){
            gm.vidas = maxLife;
            // healthBar.fillAmount =  gm.vidas; //arrumar depois pra barra ficar cheia de novo
        }
    }
}
