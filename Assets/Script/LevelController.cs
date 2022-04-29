using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] _monsters;
    [SerializeField] string _nextLvName;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
            GoToNextLv();

    }

    private void GoToNextLv()
    {
        Debug.Log("Go to next Level " + _nextLvName);
        SceneManager.LoadScene(_nextLvName);
    }

    private bool MonstersAreAllDead()
    {   //Kiem tra xem quai chet het chua
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
