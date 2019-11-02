using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public List<Button> btnList = new List<Button>();

    bool playerTurn = true;
    bool click = false;

    private List<List<Button>> matrix;
    // Start is called before the first frame update
    void Start()
    {
        getButtons();
        AddListener1();
    }

    void getButtons()
    {
        GameObject[] objectList = GameObject.FindGameObjectsWithTag("ButtonChess");
        matrix = new List<List<Button>>();
/*        for (int i = 0; i < objectList.Length; i++)
        {
            btnList.Add(objectList[i].GetComponent<Button>());
        }*/
        for (int i = 0; i < 14; i++)
        {
            matrix.Add(new List<Button>());
            for (int j = 0; j < 15; j++)
            {
                matrix[i].Add(objectList[(i * 15) + j].GetComponent<Button>());
            }
        }


    }
   
    void AddListener1()
    {
        foreach(List<Button> btn in matrix)
        {
            foreach (Button button in btn)
            {
                button.onClick.AddListener(() => ClickButton());
                Debug.Log("alo");
            }
        }
        
    }


        void ClickButton()
        {
            string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            int index = int.Parse(name);
            Debug.Log("this buttons was click: " + index);
            click = true;

            if (click)
            {
                if (playerTurn)
                {
                    playerTurn = !playerTurn;
                    UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "X";
                    UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

                }
                else
                {
                    playerTurn = !playerTurn;
                    UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "O";
                    UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

                }
            }
            Debug.Log("this buttons was click: " + name);
        }

        void checkWin()
        {
            GameObject[] objectList = GameObject.FindGameObjectsWithTag("ButtonChess");
            for (int i = 0; i < objectList.Length; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (i % j == 0)
                    {

                    }
                }
            }
        }

    }

