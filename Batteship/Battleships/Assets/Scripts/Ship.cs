public abstract class Ship {

    protected int lengthOfShip;
    protected string nameOfShip;
    protected int numberOfShips;
    protected Coordinate coordinateOfShip;
    private int numberOfHits;

    public virtual int getLengthOfShip()
    {
        return lengthOfShip;
    }

    public virtual void setLengthOfShip(int length)
    {
        lengthOfShip = length;
    }

    public virtual string getNameOfShip()
    {
        return nameOfShip;
    }

    public virtual void setNameOfShip (string name)
    {
        nameOfShip = name;
    }

    public virtual int getNumberOfShips()
    {
        return numberOfShips;
    }

    public virtual void drawShipOnBoard()
    {

    }

    public bool isSunk
    {
        get
        {
            return NumberOfHits <= lengthOfShip;
        }
    }

    protected int NumberOfHits
    {
        get
        {
            return numberOfHits;
        }

        set
        {
            numberOfHits = value;
        }
    }
}
