public class Quest
{
    private int _pollenAmount;
    private int _fluffAmount;

    private bool _isFinished = false;

    public Quest(int pollenAmount, int fluffAmount)
    {
        _pollenAmount = pollenAmount;
        _fluffAmount = fluffAmount;
    }

    public void FinishQuest()
    {
        _isFinished = true;
    }

    public int GetPollenAmount()
    {
        return _pollenAmount;
    }

    public int GetFluffAmount()
    {
        return _fluffAmount;
    }

    public bool IsFinished()
    {
        return _isFinished;
    }
}