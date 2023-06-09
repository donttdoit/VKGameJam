using UnityEngine;

public class QuestItem
{
    private QuestItemType _questItemType;
    private int _amount;

    public QuestItem(QuestItemType type, int amount)
    {
        _amount = amount;
        _questItemType = type;
    }

    public Sprite GetSprite()
    {
        switch (_questItemType)
        {
            default:
            case QuestItemType.FLUFF: return ItemAssets.Instance.Fluff;
            case QuestItemType.POLLEN: return ItemAssets.Instance.Pollen;
        }
    }

    public int GetAmount()
    {
        return _amount;
    }

    public QuestItemType GetQuestItemType()
    {
        return _questItemType;
    }
}