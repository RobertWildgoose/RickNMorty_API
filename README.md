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
using RickNMorty.Common; // Replace with actual namespace

public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<RegistrationContainer>();
}
```

## Using Services
Now you can inject and use the services in your application components.

## Character Service
### Getting All Characters
Retrieve a list of all characters from the "Rick and Morty" universe.

```csharp
using RickNMorty.Common; // Replace with actual namespace

public class MyService
{
    private readonly ICharacterService _characterService;

    public MyService(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    public void FetchAllCharacters()
    {
        var allCharacters = _characterService.GetAllCharacters(1);
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
        var character = _characterService.GetCharacter(characterId);
        // Process the character
    }
}
```

### Getting a List of Characters by ID
Retrieve a specific list of characters using their ID.

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
        var characterList = new List<int>(){1,2,3}
        var character = _characterService.GetCharacters(characterList);
        // Process the character
    }
}
```

## Location Service
### Getting All Locations
Retrieve a list of all locations from the "Rick and Morty" universe.

```csharp
using RickNMorty.Common; // Replace with actual namespace

public class MyService
{
    private readonly ILocationService _locationService;

    public MyService(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public void FetchAllLocations()
    {
        var allLocations = _locationService.GetLocations(1);
        // Process the locations
    }
}
```
### Getting a Location by ID
Retrieve a specific location using its ID.

```csharp
using RickNMorty.Common; // Replace with actual namespace

public class MyService
{
    private readonly ILocationService _locationService;

    public MyService(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public void FetchLocationById(int locationId)
    {
        var location = _locationService.GetLocation(locationId);
        // Process the location
    }
}
```

### Getting a Location by ID
Retrieve a specific location using its ID.

```csharp
using RickNMorty.Common; // Replace with actual namespace

public class MyService
{
    private readonly ILocationService _locationService;

    public MyService(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public void FetchLocationsById()
    {
        var locationList = new List<int>(){1,2,3}
        var locations = _locationService.GetLocations(locationList);
        // Process the location
    }
}
```

## Episode Service
### Getting All Episodes
Retrieve a list of all episodes from the "Rick and Morty" universe.

```csharp
using RickNMorty.Common; // Replace with actual namespace

public class MyService
{
    private readonly IEpisodeService _episodeService;

    public MyService(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
    }

    public void FetchAllEpisodes()
    {
        var allEpisodes = _episodeService.GetAllEpisodes();
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
        var episode = _episodeService.GetEpisode(episodeId);
        // Process the episode
    }
}
```

### Getting a List Of Episodes by ID
Retrieve a specific list of episodes using their ID.

```csharp
using RickNMorty.Common; // Replace with actual namespace

public class MyService
{
    private readonly IEpisodeService _episodeService;

    public MyService(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
    }

    public void GetEpisodesById()
    {
        var episodesList = new List<int>(){1,2,3}
        var episodes = _episodeService.GetEpisodes(locationList);
        // Process the location
    }
}
```

# Contributing
If you find any issues or want to contribute, please open an issue or create a pull request on the GitHub repository.

# License
This project is licensed under the MIT License.
