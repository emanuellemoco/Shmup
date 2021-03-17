using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
   public Text message;

    GameManager gm;
    
    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.MENU);  
    }

   private void OnEnable()
   {
       gm = GameManager.GetInstance();

       if(gm.vidas <= 0)
       {
           message.text = "Você Perdeu!!!!!";
       }
       else if (gm.vidasInimigo <= 0)
       {
           message.text = "Você destruiu o inimigo!!!!!";
       }
       else {
           message.text = "Acabou o tempo!!";
       }
   }

    //    else
    //    {

    //     //    message.text = "Você Perdeu!!";
    //     //    SoundManagerScript.PlaySound("end");
    //    }




    //    if(gm.vidas > 0)
    //    {
    //        message.text = "Você Ganhou!!!";
    //    }
    //    else
    //    {
    //        message.text = "Você Perdeu!!";
    //     //    SoundManagerScript.PlaySound("end");
    //    }
//    }

}