using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherTools.Blazor.Models;
using System.Security.Cryptography.X509Certificates;

namespace CypherTools.Blazor.Services
{
    public class SessionService
    {

        public List<Character> UserCharacters { get; private set; }
        private bool IsInitialized { get; set; } = false;


        private ILocalStorageService localStorageService = null;
        public SessionService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public void AddCharacter(Character character)
        {
            character.CharacterId = UserCharacters.Count == 0 ? 1 : UserCharacters.Max(x => x.CharacterId) + 1;
            UserCharacters.Add(character);
        }

        public async Task Initialize()
        {
            if (!IsInitialized)
            {
                UserCharacters = await localStorageService.GetItemAsync<List<Character>>("UserCharacters") ?? new List<Character>() ;
                IsInitialized = true;
            }
        }

        public async Task SaveData()
        {
            await localStorageService.SetItemAsync<List<Character>>("UserCharacters", UserCharacters);
        }
    }
}
