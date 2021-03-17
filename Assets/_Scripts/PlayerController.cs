using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;

    public AudioClip shootSFX;
    
    public GameObject bullet;
    public Transform arma;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    private Vector3 direcao;


    float cantoSuperior = 4.5f; 
    float cantoInferior = -4.7f; 

    GameManager gm;

    private void Start()
    {
        animator = GetComponent<Animator>();

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);
        direcao = new Vector3(dirX, dirY).normalized;
        
        gm = GameManager.GetInstance();
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;


        //Quando apertar esc
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        //Para achar a posicao do player
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
              
    }

   void FixedUpdate()
   {
       if (gm.gameState != GameManager.GameState.GAME) return;

       float yInput = Input.GetAxis("Vertical");
       float xInput = Input.GetAxis("Horizontal");

        if ((transform.position.y > cantoSuperior && yInput > 0) ||(transform.position.y < cantoInferior && yInput < 0)){
            yInput = 0;
        }


       Thrust(xInput, yInput);
       if (yInput != 0 || xInput != 0)
       {
           animator.SetFloat("Velocity", 1.0f);
       }
       else
       {
           animator.SetFloat("Velocity", 0.0f);
       }

       //Fire1 -> ctrl
        if(Input.GetAxisRaw("Jump") != 0) //Jump -> barra de espaco
       {
           Shoot();
       }
   }  
  

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
       _lastShootTimestamp = Time.time;
       Instantiate(bullet, arma.position, Quaternion.identity);

        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
       gm.vidas--;

    //    if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)


        //se estiver em GAME e acabar as vidas
       if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
       { 
            gm.ChangeState(GameManager.GameState.ENDGAME);
            Die();
       }
    }

    public void Die()
    {
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
}

    
}
