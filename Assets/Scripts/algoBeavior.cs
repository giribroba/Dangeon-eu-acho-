﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class algoBeavior : MonoBehaviour
{
    float empurrando;
    float xPush;
    float yPush;

    public float speed;

    public float tempoEmpurrar;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Detecta colisão com o player/Remove vida
        if (other.tag == "Player") 
        {   
            vidaCount.Vida -= 10;
            empurrando = tempoEmpurrar;
            xPush = playerBehavior.xMoviment;
            yPush = playerBehavior.yMoviment;
        }
    }

    private void Update()
    {
        //Empurra o player ao colidir com o objeto
        if (empurrando > 0 && (playerBehavior.xMoviment != 0 || playerBehavior.yMoviment != 0))
        {
            playerBehavior.move = false;
            Player.transform.Translate(Vector3.up * -yPush * speed * Time.deltaTime);
            Player.transform.Translate(Vector3.right * -xPush * speed * Time.deltaTime);
        }
        else
        {
            playerBehavior.move = true;
        }
        empurrando -= Time.deltaTime;
        if (xPush > 0)
        {
            xPush -= 0.7f * Time.deltaTime;
        }
        else if (xPush < 0)
        {
            xPush += 0.7f * Time.deltaTime;
        }
        if (yPush > 0)
        {
            yPush -= 0.7f * Time.deltaTime;
        }
        else if (yPush < 0)
        {
            yPush += 0.7f * Time.deltaTime;
        }
    }

}
