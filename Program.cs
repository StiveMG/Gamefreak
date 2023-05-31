using gamefreak.clases;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Pokemon Pokemon = new Pokemon();
List<PokemonDTO> listadoPokemons = new List<PokemonDTO>();

app.MapPost("/gamefreak/pokemon", (PokemonDTO pokemon) => {
    Pokemon.Add(pokemon);
});

app.MapGet("/gamefreak/pokemon", () => {
    return Results.Ok(Pokemon.All());
});

app.MapPost("/gamefreak/pokemons", (PokemonDTO[] Pokemon) => {
    for (int i = 0; i < Pokemon.Length; i++) 
    {
        listadoPokemons.Add(Pokemon[i]);
    }
});

app.MapGet("/gamefreak/pokemons/{tipo}", (string tipo) => {
    return Results.Ok(listadoPokemons.Single(Pokemon => Pokemon.Tipo == tipo));
});

app.MapGet("/gamefreak/pokemon/{id}", (int id) => {
    return Results.Ok(listadoPokemons.Single(Pokemon => Pokemon.Id == id));
});

app.MapPut("/gamefreak/pokemon/{id}", (PokemonDTO pokemon, int id) => {
    PokemonDTO pokemonBD = listadoPokemons.Single(pokemon => pokemon.Id == id);
    pokemonBD.Nombre = pokemon.Nombre;
    pokemonBD.Tipo = pokemon.Tipo;
    pokemonBD.Habilidades = pokemon.Habilidades;
    pokemonBD.Defensa = pokemon.Defensa;

    return Results.Ok(listadoPokemons);
});

app.MapDelete("/gamefreak/pokemon/{id}", (int id) => {
    listadoPokemons.RemoveAll(Pokemon =>Pokemon.Id == id);
    return Results.Ok(listadoPokemons);
});