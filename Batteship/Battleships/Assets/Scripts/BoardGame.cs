public class BoardGame {

    public int[,] boardGame = new int[10,10];
    

    public BoardGame()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                boardGame[i,j] = 0;
            }
        }
    }

    public void setValueOfCell (Coordinate coord, int value)
    {
        boardGame[coord.getCoordinateX(), coord.getCoordinateY()] = value;
    }

    
}