namespace gamefreak.clases;
public class Pokemon : IPokemon
{
    private List<PokemonDTO> BD;
    public Pokemon ()
    {
        this.BD = new List<PokemonDTO>();
    }
    public void Add (PokemonDTO Pokemon)
    {
        this.BD.Add (Pokemon);
    }
    public void Delete (int id)
    {
        this.BD.RemoveAll (pokemon => pokemon.Id == id);
    }
    public void Udate(int id, PokemonDTO Pokemon)
    {
        PokemonDTO pokemonUpdate = this.BD.Single(pokemon => pokemon.Id == id);
        pokemonUpdate = Pokemon;
    }
    public List<PokemonDTO> All()
    {
        return this.BD;
    }
}