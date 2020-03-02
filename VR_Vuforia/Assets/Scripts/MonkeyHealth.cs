using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHealth : MonoBehaviour
{
    public uint healthPoints = 10;

    private uint currentHealthPoints;

    public void ReduceHealth()
    {
        currentHealthPoints--;
        if(currentHealthPoints <= 0)
        {
            gameObject.SetActive(false);
            GameObject psystem = GameManager.instance.GetBananaSystemPool().GetInactiveGameObject();
            psystem.transform.position = transform.position;
            psystem.SetActive(true);
            GameManager.instance.PlaySound(GameManager.Sounds.MonkeyDeath);
        }
    }

    private void OnEnable()
    {
        currentHealthPoints = healthPoints;
    }
}
