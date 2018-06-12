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



    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonPlayerList.Length; i++)
        {
            buttonPlayerList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
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
        System.Random rand = new System.Random(System.DateTime.Now.Millisecond);        //maszyna losująca...
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

    public void gameOver() { }
}
