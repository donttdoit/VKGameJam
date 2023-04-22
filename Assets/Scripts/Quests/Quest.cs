public class Quest
{
    private bool _isFinished = false;
    private QuestItem _questItemPollen;
    private QuestItem _questItemFluff;

    public Quest(int pollenAmount, int fluffAmount)
    {
        _questItemPollen = new QuestItem(QuestItemType.POLLEN, pollenAmount);
        _questItemFluff = new QuestItem(QuestItemType.FLUFF, fluffAmount);
    }

    public void FinishQuest()
    {
        _isFinished = true;
    }

    public int GetPollenAmount()
    {
        return _questItemPollen.GetAmount();
    }

    public int GetFluffAmount()
    {
        return _questItemFluff.GetAmount();
    }

    public QuestItem GetQuestItemPollen()
    {
        return _questItemPollen;
    }

    public QuestItem GetQuestItemFluff()
    {
        return _questItemFluff;
    }

    public bool IsFinished()
    {
        return _isFinished;
    }
}