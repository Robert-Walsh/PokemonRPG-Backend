public class InventoryEntry {
    public int Id {get; set;}
    public int InventoryId {get; set;}
    public int ItemId {get; set;}
}

public class Item {
    public int Id {get; set;}
    public string Name {get; set;}
    public int EffectTypeId {get; set;}
}

public class EffectType{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
}