using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SlotTower slotSelected; //Slot da torre selecionado
    public GameObject towerSelected; //Torre selecionada
    public Tower towerDragged; //Torre a ser arrastada
    private int money; //Dinheiro atual do jogador

    private HUDManager hudManager; //Gerenciador da interface

    #region Singleton

    public static GameManager instance; //instancia estatica da classe

    //É chamado ao ser carregado
    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }

        hudManager = GetComponent<HUDManager>();
    }

    #endregion

    //É chamado no primeiro frame
    private void Start()
    {
        money = 100;
        hudManager.UpdateUI(money);

        Time.timeScale = 0;
    }

    //É chamado quando uma torre é arrastada
    public void DragTower(Tower _tower)
    {
        if (towerSelected == null)
        {
            towerDragged = _tower;
        }
    }

    //É chamado ao passar o mouse sobre um slot de torre
    public bool SelectSlot(SlotTower newSlot)
    {
        if (towerSelected != null || towerDragged != null)
        {
            slotSelected = newSlot;
            return true;
        }
        else
        {
            return false;
        }
    }

    //É chamado ao soltar uma torre arrastada
    public void DropTower()
    {
        if (towerDragged != null)
        {
            towerDragged.UpdateTowerPosition(slotSelected);
            towerDragged = null;
        }
    }

    //É chamado ao selecionar um slot para instanciar a torre selecionada
    public void SpawnTower(SlotTower _slotTower)
    {
        if (towerSelected != null && _slotTower.Avaliable)
        {
            Tower _tower = towerSelected.GetComponent<Tower>();
            if (SpendMoney(_tower.GetCost()))
            {
                Vector3 _spawnPosition = slotSelected.transform.position + new Vector3(0, 0.5f, 0);

                slotSelected = _slotTower;
                _tower = Instantiate(towerSelected, _spawnPosition, slotSelected.transform.rotation).GetComponent<Tower>();
                _tower.SetSlot(slotSelected);
                towerSelected = null;
            }
        }
    }

    //Diminui o dinheiro do jogador de acordo com parametro e retorna verdadeiro se a transação ocorreu com sucesso
    private bool SpendMoney(int _value)
    {
        if (money >= _value)
        {
            money -= _value;

            hudManager.UpdateUI(money);

            return true;
        }
        else
        {
            return false;
        }
    }

    //Recebe dinheiro de acordo com o parametro
    public void GiveReward(int _value)
    {
        money += _value;

        hudManager.UpdateUI(money);
    }

    //É chamado ao acabar o jogo
    public void GameOver()
    {
        hudManager.GameOver();
        Time.timeScale = 0;
    }

    //É chamado para iniciar o jogo
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    //Reinicia a cena
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
