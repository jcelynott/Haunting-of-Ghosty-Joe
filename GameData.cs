/// <summary>
/// A simple class to hold and access data across the game's scenes
/// </summary>
public static class GameData
{
    public static bool isDangerTurn = false, isHidden = false, controlLocked = false, lastTurnDanger = false;
    public static float spawnRate = .3f, turnLength = 7, buttonTimeGrace = 0.15f; //spawnrate is normal chance a bad thing will happen. Turn length is seconds (here, 5 seconds per 5 minutes)
    public static int turnNumber = 0, turncount = 28, gracePeriod = 1, wordsCompleted = 0, wordsNeeded = 30;

    //Resets all data to default values
    public static void ResetData()
    {
        isDangerTurn = false; isHidden = false; controlLocked = false; lastTurnDanger = false;
        spawnRate = .8f; turnLength = 7; buttonTimeGrace = 0.2f;
        turnNumber = 0; turncount = 28; gracePeriod = 1; wordsCompleted = 0; wordsNeeded = 30;
    }
}
