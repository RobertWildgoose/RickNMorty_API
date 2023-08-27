# RickNMorty API NuGet Package

A .NET library for easy integration with the Rick and Morty API. This library provides services to interact with characters, locations, and episodes from the "Rick and Morty" universe.
### Wrapper API around the following  [API](https://rickandmortyapi.com/)
# Installation

You can install the package via NuGet Package Manager or by using the .NET CLI.

```bash
nuget install RickNMorty.API
```
or

```bash
dotnet add package RickNMorty.API
```

# Usage
## Installation
First, install the NuGet package in your project.

## Register Services
In your application's startup or configuration class, register the services provided by the RickNMorty.API library.


```csharp
using Microsoft.Extensions.DependencyInjection;
using RickNMorty.API; // Replace with actual namespace

public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ICharacterService, CharacterService>();
    services.AddScoped<ILocationService, LocationService>();
    services.AddScoped<IEpisodeService, EpisodeService>();
}
```

## Using Services
Now you can inject and use the services in your application components.

## Character Service
### Getting All Characters
Retrieve a list of all characters from the "Rick and Morty" universe.

```csharp
using RickNMorty.API; // Replace with actual namespace

public class MyService
{
    private readonly ICharacterService _characterService;

    public MyService(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    public void FetchAllCharacters()
    {
        var allCharacters = _characterService.GetAll();
        // Process the characters
    }
}
```
### Getting a Character by ID
Retrieve a specific character using their ID.

```csharp
using RickNMorty.API; // Replace with actual namespace

public class MyService
{
    private readonly ICharacterService _characterService;

    public MyService(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    public void FetchCharacterById(int characterId)
    {
        var character = _characterService.GetItemsByID(characterId);
        // Process the character
    }
}
```

## Location Service
### Getting All Locations
Retrieve a list of all locations from the "Rick and Morty" universe.

```csharp
using RickNMorty.API; // Replace with actual namespace

public class MyService
{
    private readonly ILocationService _locationService;

    public MyService(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public void FetchAllLocations()
    {
        var allLocations = _locationService.GetAll();
        // Process the locations
    }
}
```
### Getting a Location by ID
Retrieve a specific location using its ID.

```csharp
using RickNMorty.API; // Replace with actual namespace

public class MyService
{
    private readonly ILocationService _locationService;

    public MyService(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public void FetchLocationById(int locationId)
    {
        var location = _locationService.GetItemsByID(locationId);
        // Process the location
    }
}
```

## Episode Service
### Getting All Episodes
Retrieve a list of all episodes from the "Rick and Morty" universe.

```csharp
using RickNMorty.API; // Replace with actual namespace

public class MyService
{
    private readonly IEpisodeService _episodeService;

    public MyService(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
    }

    public void FetchAllEpisodes()
    {
        var allEpisodes = _episodeService.GetAll();
        // Process the episodes
    }
}
```

### Getting an Episode by ID
Retrieve a specific episode using its ID.

```csharp
using RickNMorty.API; // Replace with actual namespace

public class MyService
{
    private readonly IEpisodeService _episodeService;

    public MyService(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
    }

    public void FetchEpisodeById(int episodeId)
    {
        var episode = _episodeService.GetItemsByID(episodeId);
        // Process the episode
    }
}
```

## Error Handling
In case of API errors, the services may throw exceptions. Handle these exceptions appropriately in your application.

```csharp
try
{
    var character = _characterService.GetCharacterByID(characterId);
}
catch (RickNMortyApiException ex)
{
    // Handle the exception here
}
```
# Contributing
If you find any issues or want to contribute, please open an issue or create a pull request on the GitHub repository.

# License
This project is licensed under the MIT License.
