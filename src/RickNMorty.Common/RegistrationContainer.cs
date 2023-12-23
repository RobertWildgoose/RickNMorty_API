using ApiUtilities.Common;
using ApiUtilities.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RickNMorty.Common.Interfaces;
using RickNMorty.Common.Services;

namespace RickNMorty.Common
{
	public class RegistrationContainer : BaseRegistrationContainer
	{
		public RegistrationContainer(IServiceCollection collection) : base(collection)
		{
			collection.AddSingleton<IApiConfig, ApiConfig>();
		}

		public override void ExtendRegistration(IServiceCollection collection)
		{
			base.ExtendRegistration(collection);
			collection.AddSingleton<ICharacterService, CharacterService>();
			collection.AddSingleton<ILocationService, LocationService>();
			collection.AddSingleton<IEpisodeService, EpisodeService>();
		}
	}
}
