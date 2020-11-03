using CypherTools.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CypherTools.Blazor.Services
{
    public class DiscordWebhookService
    {
        private HttpClient HttpClient { get; set; }

        public DiscordWebhookService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public async Task SendDieRollWebhook(string url, RollResult rollResult)
        {
            DiscordWebHookModel dwhm = new DiscordWebHookModel();

            string Title = $"Rolled for {rollResult.Reason}";
            string Description = "";
            if (rollResult.OriginalTargetNumber != 0)
            {
                Title = rollResult.Success ? " SUCCESS!" : " FAILURE";
                Description = "**Difficulty:** {rollResult.ModifiedTargetNumber} TN({rollResult.ModifiedTargetNumber * 3})\n";
            }



            dwhm.username = rollResult.CharacterName;
            dwhm.embeds.Add(
                new DiscordWebHookEmbed()
                {
                    title = Title,
                    description = Description + $"**Trained** {rollResult.Trained}\n**Other Modifiers** {rollResult.Modifiers}\n**Final Difficulty:** {rollResult.ModifiedTargetNumber}\n**Roll:** {rollResult.Result} Beats difficulty {(rollResult.Result / 3) + rollResult.Modifiers + rollResult.Trained} (TN: {((rollResult.Result / 3) + rollResult.Modifiers + rollResult.Trained) * 3})",
                    author = new DiscordWebHookEmbedAuthor { author = $"{rollResult.Reason} - {rollResult.Type} - {rollResult.Stat}" },
                    footer = new DiscordWebHookEmbedFooter { text = rollResult.SpecialText }
                });

            await SendWebHook(url, dwhm);
        }

        public async Task SendAbilityWebhook(string url, CharacterAbility characterAbility, string characterName)
        {
            DiscordWebHookModel dwhm = new DiscordWebHookModel();

            dwhm.username = characterName;
            dwhm.embeds.Add(
                new DiscordWebHookEmbed()
                {
                    title = $"SUCCESS!/FAILURE!",
                    description = "**Difficulty:** 3 TN(3)\n**Trained** -1\n**Final Difficulty:** 2\n**Roll:** 18 Beats difficulty 8 (TN: 18)",
                    author = new DiscordWebHookEmbedAuthor { author = $"Fin Piercer - Attack - Speed" },
                    footer = new DiscordWebHookEmbedFooter { text = $"Special: +2 Damage" }
                });

            await SendWebHook(url, dwhm);
        }

        public async Task SendWebHook(string url, DiscordWebHookModel discordWebHookModel)
        {
            var payload = new StringContent(JsonSerializer.Serialize(discordWebHookModel, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8, "application/json");

            await HttpClient.PostAsync(url, payload);
        }
    }

    public class DiscordWebHookModel
    {
        public string username { get; set; }
        public List<DiscordWebHookEmbed> embeds { get; set; } = new List<DiscordWebHookEmbed>();
    }

    public class DiscordWebHookEmbed
    {
        public string title { get; set; }
        public string description { get; set; }
        public DiscordWebHookEmbedAuthor author { get; set; } = new DiscordWebHookEmbedAuthor();
        public DiscordWebHookEmbedFooter footer { get; set; } = new DiscordWebHookEmbedFooter();
    }

    public class DiscordWebHookEmbedAuthor
    {
        public string author { get; set; }
    }

    public class DiscordWebHookEmbedFooter
    {
        public string text { get; set; }
    }
}
