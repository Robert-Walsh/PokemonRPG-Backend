
public class PokemonBreed{
    public int Id {get; set;}
    public string Name {get; set;}
    public string ImageLocation {get;set;}
}

public class Pokedex{
    public int Id {get; set;}
    public int PokemonBreedId {get; set;}
    public string Entry {get; set;}
    public int EvolvesFromBreedId {get; set;}
    public int Generation {get; set;}
    public int Type1Id {get; set;}
    public int Type2Id {get; set;}
    public bool Type2Optional {get; set;}
}

public class Type {
    public int Id {get; set;}
    public string Name {get; set;}
}

