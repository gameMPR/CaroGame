using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

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
        for (int i = 0; i < 14; i++)
        {
            matrix.Add(new List<Button>());
            for (int j = 0; j < 15; j++)
            {
                matrix[i].Add(objectList[(i * 15) + j].GetComponent<Button>());
                // xác định tọa độ x y của nút
                objectList[(i * 15) + j].GetComponent<ButtonSingle>().posX =j;
                objectList[(i * 15) + j].GetComponent<ButtonSingle>().posY = i;
                //end
                
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
                button.onClick.AddListener(() => EndGame(button));
            }
        }
        
    }

        void ClickButton()
        {
            string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            int index = int.Parse(name);
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

    private void EndGame(Button button)
    {
        if (isEndGame(button))
        {
            Debug.Log("End Game");
        }
        
    }
    private bool isEndGame(Button button)
    {
        return isEndDoc(button) || isEndNgang(button) || isEndCheoChinh(button) || isEndCheoPhu(button);
    }
    private bool isEndNgang(Button button)
    {
        int posX= button.GetComponent<ButtonSingle>().posX ;
        int posY = button.GetComponent<ButtonSingle>().posY;
        int countLeft = 0;
        for(int i = posX; i >= 0; i--)
        {
            if (matrix[posY][i].GetComponentInChildren<Text>().text.Equals(button.GetComponentInChildren<Text>().text)) 
            {
                countLeft++;
            }
            else
            {
                break;
            }
        }
        int countRight = 0;
        for (int i = posX + 1; i < 15; i++)
        {
            if (matrix[posY][i].GetComponentInChildren<Text>().text.Equals(button.GetComponentInChildren<Text>().text))
            {
                countRight++;
            }
            else
            {
                break;
            }
        }
        return countLeft+countRight==5;
    }
    private bool isEndDoc(Button button)
    {
        int posX = button.GetComponent<ButtonSingle>().posX;
        int posY = button.GetComponent<ButtonSingle>().posY;
        int countUp = 0;
        for (int i = posY; i >= 0; i--)
        {
            if (matrix[i][posX].GetComponentInChildren<Text>().text.Equals(button.GetComponentInChildren<Text>().text))
            {
                countUp++;
            }
            else
            {
                break;
            }
        }
        int countDown = 0;
        for (int i = posY + 1; i < 15; i++)
        {
            if (matrix[i][posX].GetComponentInChildren<Text>().text.Equals(button.GetComponentInChildren<Text>().text))
            {
                countDown++;
            }
            else
            {
                break;
            }
        }
        return countUp + countDown == 5;
       
    }
    private bool isEndCheoChinh(Button button)
    {
        int posX = button.GetComponent<ButtonSingle>().posX;
        int posY = button.GetComponent<ButtonSingle>().posY;
        int countUp = 0;
        for (int i = 0; i < posY; i++)
        {
            if (matrix[posY + i][posX + i].GetComponentInChildren<Text>().text.Equals(button.GetComponentInChildren<Text>().text))
            {
                countUp++;
                Debug.Log("countUp:" + countUp);
            }
            else
            {
                break;
            }

        }

        int countDown = 0;
        for (int i = 1; i < 25; i++)
        {
            if (matrix[posY - i][posX - i].GetComponentInChildren<Text>().text.Equals(button.GetComponentInChildren<Text>().text))
            {
                countDown++;
                Debug.Log("countDown:" + countDown);
            }
            else
            {
                break;
            }

        }
        return countUp + countDown == 5;    
    }
    private bool isEndCheoPhu(Button button)
    {
        return false;
    }

}

