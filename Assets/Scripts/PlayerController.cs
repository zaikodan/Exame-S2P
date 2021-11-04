using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputMaster inputMaster; //Armazena os inputs do jogador

    //� chamado ao ser carregado
    private void Awake()
    {
        inputMaster = new InputMaster();

        inputMaster.Player.ClickUp.performed += ctx => DropTower();
    }

    //� chamado ao selecionar uma torre para arrastar
    public void SelectTower(GameObject _tower)
    {
        if (GameManager.instance.towerSelected != _tower)
        {
            GameManager.instance.towerSelected = _tower;
        }
        else
        {
            GameManager.instance.towerSelected = null;
        }
    }

    //� chamado ao soltar o bot�o esquerdo do mouse
    private void DropTower()
    {
        GameManager.instance.DropTower();
    }

    //� chamado quando o game object esta ativo na cena
    private void OnEnable()
    {
        inputMaster.Enable();
    }

    //� chamado quando o game object n�o esta ativo na cena
    private void OnDisable()
    {
        inputMaster.Disable();
    }
}
