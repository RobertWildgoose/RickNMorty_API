# RickNMorty.Common NuGet Package

## Overview

The RickNMorty.Common package provides a convenient wrapper for interacting with the Rick and Morty API. This package includes services for retrieving character, episode, and location data from the API, making it easier to integrate Rick and Morty data into your .NET applications.

## Installation
To install the RickNMorty.Common package, use the following command in the Package Manager Console:

```c#
Install-Package RickNMorty.Common
```

Or with .NET CLI:

```c#
dotnet add package RickNMorty.Common
```

## Configuration

Ensure that you have registered the necessary services in your IoC container. The following example demonstrates how to register these services using the built-in dependency injection in ASP.NET Core:

```c#
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddSingleton<IBaseConfiguration, ApiConfiguration>();
    }
}
```

## Usage
### Character Service
The CharacterService provides methods to fetch character data from the Rick and Morty API.

#### Get All Characters

```c#
public async Task<CharactersResponse> GetAllCharacters(int page)
{
    var characters = await characterService.GetAllCharacters(page);
    // Use characters as needed
}
```

#### Get Character by ID

```c#
public async Task<Character> GetCharacter(int characterId)
{
    var character = await characterService.GetCharacter(characterId);
    // Use character as needed
}
```

#### Get Multiple Characters by IDs

```c#
public async Task<List<Character>> GetCharacters(IEnumerable<int> characterIds)
{
    var characters = await characterService.GetCharacters(characterIds);
    // Use characters as needed
}
```

### Episode Service
The EpisodeService provides methods to fetch episode data from the Rick and Morty API.

#### Get All Episodes

```c#
public async Task<EpisodeResponse> GetAllEpisodes(int page)
{
    var episodes = await episodeService.GetAllEpisodes(page);
    // Use episodes as needed
}
```

#### Get Episode by ID

```c#
public async Task<Episode> GetEpisode(int episodeId)
{
    var episode = await episodeService.GetEpisode(episodeId);
    // Use episode as needed
}
```

#### Get Multiple Episodes by IDs

```c#
public async Task<List<Episode>> GetEpisodes(IEnumerable<int> episodeIds)
{
    var episodes = await episodeService.GetEpisodes(episodeIds);
    // Use episodes as needed
}
```

### Location Service
The LocationService provides methods to fetch location data from the Rick and Morty API.

#### Get Location by ID

```c#
public async Task<Location> GetLocation(int locationId)
{
    var location = await locationService.GetLocation(locationId);
    // Use location as needed
}
```

#### Get Multiple Locations by IDs

```c#
public async Task<List<Location>> GetLocations(IEnumerable<int> locationIds)
{
    var locations = await locationService.GetLocations(locationIds);
    // Use locations as needed
}
```

#### Get All Locations

```c#
public async Task<LocationResponse> GetLocations(int page)
{
    var locations = await locationService.GetLocations(page);
    // Use locations as needed
}
```

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments
This package uses data provided by the [Rick and Morty API.](https://rickandmortyapi.com/)

## Contributing
Contributions are welcome! Please open an issue or submit a pull request on GitHub.















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
