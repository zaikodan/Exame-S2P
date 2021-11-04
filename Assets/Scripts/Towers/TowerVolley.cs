using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVolley : Tower
{
    //Atira o projetil
    protected override void Fire()
    {
        StartCoroutine(Volley());
    }

    //Dispara uma rajada de 3 projeteis por vez
    private IEnumerator Volley()
    {
        int shoot = 3;
        while(shoot > 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            shoot--;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
