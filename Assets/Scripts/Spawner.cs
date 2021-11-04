using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPositions; //Armazena as posições para instanciar os inimigos
    [SerializeField]
    private GameObject[] enemyPrefab; //Armazena os prefabs dos inimigos a serem instanciados

    private float timer; //Relogio para instanciar os inimigos
    const float cooldown = 4; //Tempo necessario para instanciar os inimigos

    //É chamado a cada frame
    private void Update()
    {
        SpawnTimer();
    }

    //Contabiliza o tempo necessario para poder instanciar o inimigo
    private void SpawnTimer()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Spawn();
            timer = cooldown;
        }
    }

    //Seleciona qual inimigo deve ser instanciado
    private int SelectEnemy()
    {
        int enemySelected = Random.Range(1, 11);

        switch (enemySelected)
        {
            case 10:
                return 3;

            case 9:
            case 8:
                return 2;

            case 7:
            case 6:
                return 1;

            default:
                return 0;
        }
    }

    //Instancia um inimigo aleatorio
    private void Spawn()
    {
        int i = Random.Range(0, spawnPositions.Length);
        Instantiate(enemyPrefab[SelectEnemy()], spawnPositions[i].position, spawnPositions[i].rotation);
    }
}
