using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyUI; //Texto para exibir o dinheiro
    [SerializeField]
    private Button[] towersButton; //Botões para instanciar torres
    [SerializeField]
    private int[] towersCost; //Custo de cada torre
    [SerializeField]
    private GameObject gameOverPanel; //Tela de game over

    //Atualiza a interface de acordo com o dinheiro do jogador
    public void UpdateUI(int _money)
    {
        moneyUI.text = "$" + _money.ToString();

        for (int i = 0; i < towersButton.Length; i++)
        {
            if (_money < towersCost[i])
            {
                towersButton[i].interactable = false;
            }
            else
            {
                towersButton[i].interactable = true;
            }
        }
    }

    //Ativa a tela de game over
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
