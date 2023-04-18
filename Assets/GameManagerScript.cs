using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;
    // Start is called before the first frame update
    void printArrey()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    int getPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }
    bool MoveNumber(int number,int MoveFrom,int MoveTo)
    {
        if (MoveTo < 0 || MoveTo >= map.Length)
        {
            return false;
        }
        if (map[MoveTo] == 2)
        {
            int velocity = MoveTo - MoveFrom;
            bool success = MoveNumber(2, MoveTo, MoveTo + velocity);
            if (!success) 
            {
                return false;
            }        
        }
            map[MoveTo] = number;
            map[MoveFrom] = 0;
        return true;
    }
    void Start()
    {
        map = new int[] { 0, 2, 0, 1, 0, 2, 0, 2, 0 };
        //Debug.Log("Hello world");
        printArrey();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            int playerIndex;
            playerIndex=getPlayerIndex();
            MoveNumber(1, playerIndex, playerIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = -1;
            playerIndex = getPlayerIndex();
            MoveNumber(1, playerIndex, playerIndex - 1);
        }
        printArrey();
       
    }
}
