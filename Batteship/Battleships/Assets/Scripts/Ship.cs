public abstract class Ship {

    private int lengthOfShip;
    private string nameOfShip;
    private int numberOfShips;
    private Coordinate coordinateOfShip;

    public int getLengthOfShip()
    {
        return lengthOfShip;
    }

    public void setLengthOfShip(int length)
    {
        lengthOfShip = length;
    }

    public string getNameOfShip()
    {
        return nameOfShip;
    }

    public void setNameOfShip (string name)
    {
        nameOfShip = name;
    }

    public virtual void drawShipOnBoard()
    {

    }
	
}
