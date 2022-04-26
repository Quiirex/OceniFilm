﻿using System;
using OceniFilm.Models.Igralci;

namespace OceniFilm.Services
{
	public class ActorService : IActorService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ActorService(HttpClient httpClient, IConfiguration configuration)
		{
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Igralec> GetActorInfoAsync(string ime, string priimek)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Igralec>(_configuration["IgralciAPI"] + "/api/Igralci/info/" + ime + "/" + priimek);
            }
            catch (HttpRequestException)
            {
                return new Igralec();
            }
        }
    }
}
