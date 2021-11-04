using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed; //Velocidade de movimento do projetil
    [SerializeField]
    private int damage; //Dano do projetil
    private Rigidbody rgbody; //Rigidbody do projetil

    //É chamado ao ser carregado
    private void Awake()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    //É chamado no primeiro frame
    private void Start()
    {
        Destroy(gameObject, 20);
    }

    //É chamado a cada frame
    private void Update()
    {
        Movement();
    }

    //Movimenta o projetil
    private void Movement()
    {
        rgbody.velocity = transform.forward * movementSpeed;
    }

    //É chamado ao collidir com algum projetil
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
