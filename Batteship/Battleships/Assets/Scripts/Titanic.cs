public class Titanic : Ship {

    protected new int lengthOfShip = 4;
    protected new string nameOfShip = "Titanic";
    protected new int numberOfShips = 1;

    public new int LengthOfShip
    {
        get
        {
            return lengthOfShip;
        }

        set
        {
            lengthOfShip = value;
        }
    }
    
    public new string NameOfShip
    {
        get
        {
            return nameOfShip;
        }

        set
        {
            nameOfShip = value;
        }
    }

    override
    public  int getNumberOfShips()
    {
        return numberOfShips;
    }

    override
    public void drawShipOnBoard()
    {

    }

    public new void decreaseNumberOfShips()
    {
        numberOfShips--;
    }

    public new void decreaseLengthOfShip()
    {
        lengthOfShip--;
    }
}
