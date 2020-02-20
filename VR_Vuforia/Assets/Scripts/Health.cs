using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Starting health")]
    public uint healthPoints = 10;

    private uint currentHealthPoints;

    public void ReduceHealth()
    {
        currentHealthPoints--;
        if(currentHealthPoints <= 0)
        {
            gameObject.SetActive(false);
            GameObject psystem = GameManager.instance.GetBananaSystem().GetInactiveGameObject();
            psystem.transform.position = gameObject.transform.position;
            psystem.SetActive(true);
        }
    }

    private void OnEnable()
    {
        currentHealthPoints = healthPoints;
    }
}
