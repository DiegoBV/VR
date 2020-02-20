using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
        }
    }

    private void OnEnable()
    {
        currentHealthPoints = healthPoints;
    }
}
