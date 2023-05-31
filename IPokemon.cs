namespace gamefreak.clases;
interface IPokemon
{
    void Add(PokemonDTO Pokemon);
    void Delete(int id);
    void Udate(int id, PokemonDTO Pokemon);
    List<PokemonDTO> All();
}