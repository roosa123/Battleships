public class Yacht : Ship {

    private new int lengthOfShip = 2;
    private new string nameOfShip = "Yacht";
    private new int numberOfShips = 3;

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

    public new int getNumberOfShips()
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
