using AutoBogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Prodesp.API;
using Prodesp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Prodesp.Tests
{
    public class ImunobiologicoControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;
        private readonly HttpClient _httpClient;
        protected Imunobiologico _imunobiologicoInput;

        public ImunobiologicoControllerTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
            _httpClient = _factory.CreateClient();
        }

        public async Task DisposeAsync()
        {
            _httpClient.Dispose();
        }

        public async Task InitializeAsync()
        {
            await Registrar_InformandoDadosDoImunobiologico_DeveRetornarSucesso();
        }

        [Fact]
        public async Task Registrar_InformandoDadosDoImunobiologico_DeveRetornarSucesso()
        {
            _imunobiologicoInput = new AutoFaker<Imunobiologico>()
                .RuleFor(p => p.AnoLote, faker => faker.Random.Int(DateTime.Now.Year - 30 , DateTime.Now.Year));
            StringContent content = new StringContent(JsonConvert.SerializeObject(_imunobiologicoInput), Encoding.UTF8, "application/json");

            var httpClientRequest = await _httpClient.PostAsync("api/Imunobiologico", content);
            var imunobiologicoModelOutput = JsonConvert.DeserializeObject<Imunobiologico>(await httpClientRequest.Content.ReadAsStringAsync());
          
            Assert.NotEqual(_imunobiologicoInput.Id, imunobiologicoModelOutput.Id);  
            Assert.Equal(System.Net.HttpStatusCode.Created, httpClientRequest.StatusCode);
            _imunobiologicoInput = imunobiologicoModelOutput;
            _output.WriteLine(imunobiologicoModelOutput.Id.ToString());
        }

        [Fact]
        public async Task Buscar_InformandoIdDoImunobiologico_DeveRetornarSucesso()
        {
            var httpClientRequest = await _httpClient.GetAsync("api/Imunobiologico/" + _imunobiologicoInput.Id);

            var imunobiologicoModelOutput = JsonConvert.DeserializeObject<Imunobiologico>(await httpClientRequest.Content.ReadAsStringAsync());

            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
            Assert.NotNull(imunobiologicoModelOutput);
            _output.WriteLine(imunobiologicoModelOutput.ToString());
        }

        [Fact]
        public async Task Buscar_InformandoIdInexistente_DeveRetornarNaoEncontrado()
        {
            var httpClientRequest = await _httpClient.GetAsync("api/Imunobiologico/" + Guid.NewGuid().ToString());

            var imunobiologicoModelOutput = JsonConvert.DeserializeObject<Imunobiologico>(await httpClientRequest.Content.ReadAsStringAsync());

            Assert.Equal(System.Net.HttpStatusCode.NotFound, httpClientRequest.StatusCode);
            Assert.Equal(imunobiologicoModelOutput.Id, Guid.Empty);
        }

        [Fact]
        public async Task Atualizar_InformandoDadosDoImunobiologico_DeveRetornarSucesso()
        {
            _imunobiologicoInput = new AutoFaker<Imunobiologico>()
                .RuleFor(p => p.AnoLote, faker => faker.Random.Int(DateTime.Now.Year - 30, DateTime.Now.Year));
            StringContent content = new StringContent(JsonConvert.SerializeObject(_imunobiologicoInput), Encoding.UTF8, "application/json");

            var httpClientRequest = await _httpClient.PutAsync("api/Imunobiologico/", content);
            var imunobiologicoModelOutput = JsonConvert.DeserializeObject<Imunobiologico>(await httpClientRequest.Content.ReadAsStringAsync());


            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
            _imunobiologicoInput = imunobiologicoModelOutput;
            _output.WriteLine(imunobiologicoModelOutput.Id.ToString());
        }

        [Fact]
        public async Task Excluir_InformandoIdDoImunobiologico_DeveRetornarSucesso()
        {
            var httpClientRequest = await _httpClient.DeleteAsync("api/Imunobiologico/" + _imunobiologicoInput.Id);

            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
        }
    }
}
