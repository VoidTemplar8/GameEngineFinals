using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsShotCounter : MonoBehaviour
{
    int killCount = 0;
    private void OnDisable()
    {
        PlayerController.ShotEvent -= OnKill;
    }
    private void OnEnable()
    {
        PlayerController.ShotEvent += OnKill;
    }
    void OnKill()
    {
        ++killCount;
        this.GetComponent<Text>().text = "Shots Fired: " + killCount;
    }
}
