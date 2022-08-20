using Newtonsoft.Json;
using SpaceOfMiniGames.WebApi.Models.ModelsDto.TokenController;
using System.Text;

namespace SpaceOfMiniGames.WebApi.IntegrationTests
{
    public class TokenControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public TokenControllerIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Token_WhenCalled_ReturnsToken()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Token");

            var model = new TokenRequest
            {
                Login = "sirion",
                Password = "1234",
            };

            postRequest.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.Token);
            Assert.NotNull(tokenResponse.Expired);
            Assert.True(tokenResponse.IsSuccess);
            Assert.Empty(tokenResponse.Message);
            Assert.True(tokenResponse.UserInfo.UserRoles.Count == 3);
        }
    }
}