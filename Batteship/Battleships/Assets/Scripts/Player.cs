public class Player {

    private string playerName;
    private int playerScore;

    public string getPlayerName()
    {
        return playerName;
    }

    public void setPlayerName(string name)
    {
        playerName = name;
    }

    public int getPlayerScore()
    {
        return playerScore;
    }

    public void setPlayerScore(int score)
    {
        playerScore = score;
    }

    public void addPointsToScore (int points)
    {
        playerScore += points;
    }
}
