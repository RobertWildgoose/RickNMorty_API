using ApiUtilities.Common;
using ApiUtilities.Common.Interfaces;
using ApiUtilities.Common.Registration;
using Microsoft.Extensions.DependencyInjection;
using RickNMorty.Common.Interfaces;
using RickNMorty.Common.Services;
using System.Collections.ObjectModel;

namespace RickNMorty.Common
{
	public class RegistrationContainer : BaseServiceRegistration
	{
		private readonly IServiceCollection _serviceCollection;

		public RegistrationContainer(IServiceCollection serviceCollection) : base(serviceCollection)
		{
			_serviceCollection = serviceCollection;
			_serviceCollection.AddSingleton<IBaseConfiguration, ApiConfiguration>();
		}

		protected override void RegisterOverride()
		{
			_serviceCollection.AddSingleton<ICharacterService, CharacterService>();
			_serviceCollection.AddSingleton<ILocationService, LocationService>();
			_serviceCollection.AddSingleton<IEpisodeService, EpisodeService>();
		}
	}
}
