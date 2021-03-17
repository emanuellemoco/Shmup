using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{   
    //O aluno Leonardo Mendes me ajudou a fazer esta parte.
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null) {return;}

        transform.position = new Vector3 (player.transform.position.x + 3.5f, transform.position.y, transform.position.z);
    }
}
