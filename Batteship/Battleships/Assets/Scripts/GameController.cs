using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//TODO FOR NOW:
//TODO trafianie przez komputer w ustawione statki
//TODO plansza komputera - losowanie statkow
//TODO zmienianie ruchow graczy komputer - uzytkownik
//TODO gameover 


public class GameController : MonoBehaviour{

    public Text[] buttonPlayerList;
    private string playerChoice = "x";
    BoardGame enemyBoard = new BoardGame();
    BoardGame playerBoard = new BoardGame();
    public bool isPlayerMove = true;
    System.Random rand = new System.Random(System.DateTime.Now.Millisecond);        //maszyna losująca...

    public void hit(BoardGame board, Coordinate coor)                           //TODO fajny efekt na trafianie
    {
        board.boardGame[coor.getCoordinateX(), coor.getCoordinateY()] = 99;
    }                    

    public void notHit(BoardGame board, Coordinate coor)                     //jeszcze lepszy efekt na nie trafienie
    {
        board.boardGame[coor.getCoordinateX(), coor.getCoordinateY()] = 666;
    }               

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonPlayerList.Length; i++)
        {
            buttonPlayerList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void blockOtherCell(Vector3 posit)
    {
        Vector3 positionOtherCell;
        bool posX;
        bool posY;
        for (int i = 0; i < buttonPlayerList.Length; i++)
        {
            positionOtherCell = buttonPlayerList[i].GetComponentInParent<Button>().transform.position;

            posX = ((positionOtherCell.x + 12 > posit.x - 20) && (positionOtherCell.x - 12 < posit.x - 20))
                || ((positionOtherCell.x - 12 < posit.x + 20) && (positionOtherCell.x + 12 > posit.x + 20));
            posY = ((positionOtherCell.y + 12 > posit.y - 20) && (positionOtherCell.y - 12 < posit.y - 20))
                || ((positionOtherCell.y - 12 < posit.y + 20) && (positionOtherCell.y + 12 > posit.y + 20));

            if (posX && posY)
            {
                buttonPlayerList[i].GetComponentInParent<Button>().interactable = false;
            }
        }
    }

    private void Awake()
    {
        setEnemyShipsOnTheBoard();
        SetGameControllerReferenceOnButtons();
        wypisz();
    }

    public void EndSetShips()
    {
        for (int i = 0; i < buttonPlayerList.Length; i++)
        {
            buttonPlayerList[i].GetComponentInParent<Button>().interactable = false;
            
        }
        /*for (int j =0; j < buttonPlayerList.Length; j++)
        {
            buttonPlayerList[j].GetComponentInParent<Button>().colors = ColorBlock.defaultColorBlock;
        }*/
        Debug.Log("Statki zostaly ustawione");
    }

    public string GetPlayerChoice()
    {
        return playerChoice;
    }

    public void EndTurn()
    {
        int value = 0;

        for (int i =0; i < buttonPlayerList.Length; i++)
        {
            if (buttonPlayerList[i].text == playerChoice)
            {
                value++;
                
            }

            if (value == 10)
            {
                EndSetShips();
            }
        }

        Debug.Log("Jeszcze jeden"); 
    }

    
    public void setEnemyShipsOnTheBoard()
    {
        
        Ship[] ships = new Ship[10];
        ships[0] = new Titanic();
        ships[1] = new SailingShip();
        ships[2] = new SailingShip();
        ships[3] = new Yacht();
        ships[4] = new Yacht();
        ships[5] = new Yacht();
        ships[6] = new Boat();
        ships[7] = new Boat();
        ships[8] = new Boat();
        ships[9] = new Boat();



        foreach (Ship oneShip in ships)         //losowanie dla 10 statków
        {
            Coordinate coor = new Coordinate();
            Coordinate coorTemp = new Coordinate();         //tymczasowe wspolrzedne
            int sideOfTheWorld = 0;                         //oznaczenie stron swiata (w ktora strone idziemy)



            //----------------------z tego sie bedzie rezygnować, mamy tablice statków!(zmienic tez w klasie)-----------------------


            coor.setCoordinateX(rand.Next(0, 9));
            coor.setCoordinateY(rand.Next(0, 9));

            if (enemyBoard.boardGame[coor.getCoordinateX(), coor.getCoordinateY()] == 0)       //jeśli wylosowana wspołrz ma wartosc 0 to stawiamy statek
            {
                enemyBoard.setValueOfCell(coor, 1);
                coorTemp.setCoordinateX(coor.getCoordinateX());                                           //przypisujemy ta wspolrzedna do tymczasowej
                coorTemp.setCoordinateY(coor.getCoordinateY());
            }

            for (int m = 1; m < oneShip.getLengthOfShip(); m++)                     //i czy jeszcze można stawiać statek (od jednego bo jeden już postawiliśmy)
            {

                sideOfTheWorld = rand.Next(1, 4);                               //losujemy strone świata

                while (enemyBoard.boardGame[coor.getCoordinateX(), coor.getCoordinateY()] != 0 &&                           // musi być wolne miejsce
                  coor.getCoordinateX() == coorTemp.getCoordinateX() && coor.getCoordinateY() == coorTemp.getCoordinateY())     //ktoraś z osi musi się zmienić

                {
                    switch (sideOfTheWorld)         //1-zach, 2-pn, 3-wsch, 4-pd
                    {
                        case 1:
                            if (coorTemp.getCoordinateX() - 1 >= 0)
                            {
                                coor.setCoordinateX(coor.getCoordinateX() - 1);
                            }
                            else
                                sideOfTheWorld = 2;
                            break;

                        case 2:
                            if (coorTemp.getCoordinateY() - 1 >= 0)
                            {
                                coor.setCoordinateY(coor.getCoordinateY() - 1);
                            }
                            else
                                sideOfTheWorld = 3;
                            break;

                        case 3:
                            if (coorTemp.getCoordinateX() + 1 <= 9)
                            {
                                coor.setCoordinateX(coor.getCoordinateX() + 1);
                            }
                            else
                                sideOfTheWorld = 4;
                            break;
                        case 4:
                            if (coorTemp.getCoordinateX() + 1 <= 9)
                            {
                                coor.setCoordinateX(coor.getCoordinateX() + 1);
                            }
                            else
                                sideOfTheWorld = 1;
                            break;


                    }

                }

                enemyBoard.setValueOfCell(coor, 1);
                //jak znajdziemy kojelne miejsce to inne strony świata wyszarzamy (pole =2), nie można już tam postawić statku
                //jeśli statek jest pojedynczym polem (sideOfTheWorld=0) wyszarzamy dookoła
                switch (sideOfTheWorld)         //1-zach, 2-pn, 3-wsch, 4-pd
                {
                    case 1:
                        if (coor.getCoordinateX() + 1 <= 9 && coor.getCoordinateY() - 1 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() - 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() - 1] = 2;

                        if (coor.getCoordinateX() + 1 <= 9 && coor.getCoordinateY() + 1 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() + 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() + 1] = 2;

                        if (coor.getCoordinateX() + 2 <= 9 && coor.getCoordinateY() <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() + 2, coor.getCoordinateY()] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 2, coor.getCoordinateY()] = 2;

                        if (coor.getCoordinateX() + 2 <= 9 && coor.getCoordinateY() - 1 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() + 2, coor.getCoordinateY() - 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 2, coor.getCoordinateY() - 1] = 2;

                        if (coor.getCoordinateX() + 2 <= 9 && coor.getCoordinateY() + 1 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() + 2, coor.getCoordinateY() + 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 2, coor.getCoordinateY() + 1] = 2;

                        break;

                    case 2:
                        if (coor.getCoordinateX() - 1 >= 0 && coor.getCoordinateY() + 1 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() + 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() + 1] = 2;

                        if (coor.getCoordinateX() + 1 <= 9 && coor.getCoordinateY() + 1 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() + 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() + 1] = 2;

                        if (coor.getCoordinateX() <= 9 && coor.getCoordinateY() + 2 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX(), coor.getCoordinateY() + 2] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX(), coor.getCoordinateY() + 2] = 2;

                        if (coor.getCoordinateX() - 1 >= 0 && coor.getCoordinateY() + 2 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() + 2] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() + 2] = 2;

                        if (coor.getCoordinateX() + 1 <= 9 && coor.getCoordinateY() + 2 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() + 2] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() + 2] = 2;
                        break;

                    case 3:

                        if (coor.getCoordinateX() - 1 >= 0 && coor.getCoordinateY() - 1 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() - 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() - 1] = 2;

                        if (coor.getCoordinateX() - 1 >= 0 && coor.getCoordinateY() + 1 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() + 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() + 1] = 2;

                        if (coor.getCoordinateX() - 2 >= 0 && coor.getCoordinateY() <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() - 2, coor.getCoordinateY()] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 2, coor.getCoordinateY()] = 2;

                        if (coor.getCoordinateX() - 2 >= 0 && coor.getCoordinateY() - 1 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() - 2, coor.getCoordinateY() - 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 2, coor.getCoordinateY() - 1] = 2;

                        if (coor.getCoordinateX() - 2 >= 0 && coor.getCoordinateY() + 1 <= 9
                            && enemyBoard.boardGame[coor.getCoordinateX() - 2, coor.getCoordinateY() + 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 2, coor.getCoordinateY() + 1] = 2;
                        break;

                    case 4:
                        if (coor.getCoordinateX() - 1 >= 0 && coor.getCoordinateY() - 1 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() - 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() - 1] = 2;

                        if (coor.getCoordinateX() + 1 <= 9 && coor.getCoordinateY() - 1 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() - 1] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() - 1] = 2;

                        if (coor.getCoordinateX() <= 9 && coor.getCoordinateY() - 2 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX(), coor.getCoordinateY() - 2] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX(), coor.getCoordinateY() - 2] = 2;

                        if (coor.getCoordinateX() - 1 >= 0 && coor.getCoordinateY() - 2 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() - 2] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() - 1, coor.getCoordinateY() - 2] = 2;

                        if (coor.getCoordinateX() + 1 <= 9 && coor.getCoordinateY() - 2 >= 0
                            && enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() - 2] != 1)
                            enemyBoard.boardGame[coor.getCoordinateX() + 1, coor.getCoordinateY() - 2] = 2;
                        break;


                }

                coorTemp.setCoordinateX(coor.getCoordinateX());                                           //przypisujemy ta wspolrzedna do tymczasowej
                coorTemp.setCoordinateY(coor.getCoordinateY());
            }

            wypisz();
        }

    }

    //---------------------HELP----------------------
    void wypisz()
    {
        
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                Debug.Log(enemyBoard.boardGame[i, j]); 
                }
            }
        
    }

    public void playersChange()                  //zmiana gracza
    {
        if (isPlayerMove)
        {
            playerMove();
        }
        else
            computerMove();
    }            

    public void computerMove()                  // TODO maszynka losująca do trafiania
    {
        Coordinate coordOfComputerHit = new Coordinate();

        coordOfComputerHit.setCoordinateX(rand.Next(0, 9));
        coordOfComputerHit.setCoordinateY(rand.Next(0, 9));

        checkIsHit(playerBoard, coordOfComputerHit);
    }

    public void playerMove ()          //TODO celowanie przez użytkownika w plansze komputera
    {
        Coordinate coordFromPlayer= new Coordinate();

        checkIsHit(enemyBoard, coordFromPlayer);
    }                 

    public void checkIsHit(BoardGame board, Coordinate coor)         //TODO sprawdzanie czy sie trafilo, dla kompa i usera
    {
        if (board.boardGame[coor.getCoordinateX(), coor.getCoordinateY()] == 1)
        {
            hit(board, coor);
        }
        else
            notHit(board, coor);
    }                    

    public void setUserShipsOnBoard() { }              //TODO sprawdzanie poprawności w wybranych polach dla statkow

    public void isGameOver()
    {
        if (numberOfOne(enemyBoard) == 0 || numberOfOne(playerBoard) == 0)
            gameOver();
    }

    public int numberOfOne(BoardGame board)
    {
        int howManyOne = 0;
        for (int i = 0; i <= 9; i++)
        {
            for (int j = 0; j <=9; j++)
            {
                if (board.boardGame[i, j] == 1)
                    howManyOne++;
            }
        }
        return howManyOne;
    }
    public void gameOver()                              //cos fajnego na koniec
    {
        Debug.Log("YOU LOOOOOSE");
    }
}
