public class Equipment : IEquipable
{
    public Equipment(Equip equipType, string name, int value)
    {
        EquipType = equipType;
        itemName = name;
        this.value = value;
    }

    public Equip EquipType { get; set; }
    private string itemName;
    private int value;

    public string ItemName { get { return itemName; } }

    int IEquipable.GetItemValue()
    {
        return value;
    }
}
