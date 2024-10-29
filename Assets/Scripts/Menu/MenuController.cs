using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MenuController : Singleton<MenuController>
{
    [Serializable]
    public enum menuName
    {
        MainMenu = 0,
        Settings = 1,
        Credits = 2,
        PlayMenu = 3
    }
    public GameObject[] menus;
    public float duration = 1f;
    public int currentMenuIndex;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ChangeToMenu(int newMenuIndex)
    {   
        menus[currentMenuIndex].GetComponent<MenuAnimations>().DisablingAnimation();

        currentMenuIndex = newMenuIndex;

        menus[currentMenuIndex].gameObject.SetActive(true);
    }

    public void CheckPasswordAndUsername()
    {
        //Hacer comprobaciones del nombre y la contraseña
    }

    public void EnterAsGuest()
    {
        //Esto activa que el jugador está como invitado
    }
}