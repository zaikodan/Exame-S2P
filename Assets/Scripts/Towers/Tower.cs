using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected SlotTower currentSlot; //Slot atualmente sendo ocupado pela torre
    [SerializeField]
    protected GameObject projectile; //Projetil da torre
    [SerializeField]
    private int cost; //Custo da torre
    [SerializeField]
    protected float fireRate; //Cadencia de disparo da torre
    protected float timer; //Relogio para calcular o tempo de disparo da torre
    [SerializeField]
    protected int health; //Vida da torre
    [SerializeField]
    protected LayerMask layerToIgnore; //Layer para o raycast da torre ignorar
    [SerializeField]
    protected Material outlineMaterial; //Material da torre com contorno
    [SerializeField]
    protected Material defaultMaterial; //Material padrão da torre

    //É chamado a cada frame
    protected void Update()
    {
        Reload();
    }

    //Verifica se tem algum inimigo na frente e retorna um valor booleano
    protected bool OnTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10, ~layerToIgnore))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                return true;
            }
        }

        return false;
    }

    //Calcula o tempo necessario para poder atirar
    protected void Reload()
    {
        if(timer <= 0)
        {
            if (OnTarget())
            {
                Fire();
                timer = fireRate;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    //Retorna o valor de custo da torre
    public int GetCost()
    {
        return cost;
    }

    //É chamado para disparar o projetil
    protected virtual void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    //Atualiza o slot atual da torre
    public void SetSlot(SlotTower _slot)
    {
        currentSlot = _slot;
        currentSlot.OccupySlot();
    }

    //É chamado ao arrastar a torre
    public void DragTower()
    {
        GameManager.instance.DragTower(this);
    }

    //Atualiza a posição da torre de acordo com o slot atual
    public void UpdateTowerPosition(SlotTower newSlot)
    {
        if(newSlot.Avaliable)
        {
            currentSlot.ClearSlot();
            currentSlot = newSlot;
            currentSlot.OccupySlot();
            transform.position = currentSlot.transform.position + new Vector3(0, 0.5f, 0);
        }
    }

    //Diminui a vida da torre de acordo com o parametro
    public bool TakeDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
        {
            currentSlot.ClearSlot();
            Destroy(gameObject);
            return false;
        }
        else
        {
            return true;
        }
    }

    //É chamado quando o ponteiro do mouse fica emcima
    public void MouseEnter()
    {
        GetComponent<MeshRenderer>().material = outlineMaterial;
    }

    //É chamado quando o ponteiro do mouse sai de cima
    public void MouseExit()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
