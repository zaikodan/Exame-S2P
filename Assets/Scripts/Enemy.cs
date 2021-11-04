using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed; //Velocidade de movimento
    [SerializeField]
    private int health; //Vida do inimigo
    [SerializeField]
    private int damage; //Dano por segundo causado
    private Rigidbody rgbody; //Rigidbody do inimigo
    [SerializeField]
    private int reward; //Valor ganho ao derrotar o inimigo

    private bool onCollision; //Se esta em contato com alguma torre

    //É chamado no primeiro frame
    private void Start()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    //É chamado a cada frame
    private void Update()
    {
        Movement();
    }

    //Movimenta o objeto
    private void Movement()
    {
        rgbody.velocity = transform.forward * movementSpeed;
    }

    //Diminui a vida de acordo com o parametro
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GameManager.instance.GiveReward(reward);
            Destroy(gameObject);
        }
    }

    //É chamado ao colidir com algum objeto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            onCollision = true;
            StartCoroutine(Attack(collision.gameObject.GetComponent<Tower>()));
        }
    }

    //É chamado ao sair da colisão de um objeto
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            onCollision = false;
        }
    }

    //É chamado ao colidir com algum trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndGame"))
        {
            GameManager.instance.GameOver();
        }
    }

    //Causa dano por segundo na torre em colisão
    private IEnumerator Attack(Tower _tower)
    {
        while (onCollision)
        {
            onCollision = _tower.TakeDamage(damage);

            yield return new WaitForSeconds(1);
        }
    }
}
