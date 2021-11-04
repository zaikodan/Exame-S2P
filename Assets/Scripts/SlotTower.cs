using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTower : MonoBehaviour
{
    public bool Avaliable { get; private set; } //Informa se o slot esta vago
    private GameObject towerPreview; //Objeto que mostra um preview da torre

    //� chamado no primeiro frame
    private void Start()
    {
        Avaliable = true;
        towerPreview = transform.GetChild(0).gameObject;
    }

    //� chamado quando o ponteiro do mouse fica emcima
    public void PointEnter()
    {
            towerPreview.SetActive(GameManager.instance.SelectSlot(this));
    }

    //� chamado quando o ponteiro do mouse sai de cima
    public void PointExit()
    {
        if (towerPreview.activeInHierarchy)
        {
            towerPreview.SetActive(false);
        }
    }

    //� chamado ao ser clicado com o mouse
    public void Selected()
    {
        GameManager.instance.SpawnTower(this);
    }

    //Torna a variavel avaliable falsa
    public void OccupySlot()
    {
        Avaliable = false;
    }

    //Torna a variavel avaliable verdadeira
    public void ClearSlot()
    {
        Avaliable = true;
    }
}
