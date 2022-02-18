using APIComLib.Models;
using APIComLib.Models.State;
using APIComLib.Models.Settings;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Text;
using stateRgbw = APIComLib.Models.State.Rgbw;
using stateRoot = APIComLib.Models.State.Root;
using settingsRoot = APIComLib.Models.Settings.Root;

namespace APIComLib
{
    enum Effects
    {
        NONE,
        FADE,
        RGB,
        POLICE,
        RELAX,
        STROBO,
        BELL
    }
    public class APICommunication
    {
        HttpClient client;
        string APIAddress;

        string getStateEndpoint = "/api/rgbw/state";
        string setStateEndpoint = "/api/rgbw/set";
        string getStateExtEndpoint = "/api/rgbw/extended/state";
        string setStateExtEndpoint = "/api/rgbw/extended/set";
        string getSettingsEndpoint = "/api/settings/state";
        string setSettingsEndpoint = "/api/settings/set";


        wLightboxConstraints constraints = new wLightboxConstraints();
        public APICommunication(HttpClient client, string APIAddress)
        {
            this.client = client;
            this.APIAddress = APIAddress;
        }

        private async Task<stateRgbw> GetStateAsync(bool isExtended)
        {
            string endpoint;
            if (isExtended)
                endpoint = getStateEndpoint;
            else 
                endpoint = getStateExtEndpoint;

            HttpResponseMessage response = await client.GetAsync(APIAddress+endpoint);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var deserializedResponseBody = JsonConvert.DeserializeObject<stateRoot>(responseBody);

            return deserializedResponseBody.rgbw;
        }
        private async Task<stateRgbw> SetStateAsync(stateRgbw rgbw, bool isExtended)
        {
            var data = AddRootState(rgbw);

            string endpoint;
            if (isExtended)
                endpoint = setStateEndpoint;
            else
                endpoint = setStateExtEndpoint;

            HttpResponseMessage response = await client.PostAsync(APIAddress + endpoint, data);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            string responseBody = await response.Content.ReadAsStringAsync();

            var deserializedResponseBody = JsonConvert.DeserializeObject<stateRoot>(responseBody);

            return deserializedResponseBody.rgbw;
        }
        private StringContent AddRootState(stateRgbw rgbw)
        {
            stateRoot root = new stateRoot(rgbw);
            var requestBody = JsonConvert.SerializeObject(root);
            return new StringContent(requestBody, Encoding.UTF8, "application/json");
        }
        public async Task<stateRgbw> getCurrentStateAsync()
        {
            return await GetStateAsync(isExtended: false);
        }
        public async Task<stateRgbw> getCurrentStateExtAsync()
        {
            return await GetStateAsync(isExtended: true);
        }
        public async Task<stateRgbw> setColorAsync(string color, int colorFade)
        {
            var state = new stateRgbw();
            var durations = new DurationsMs();
            if (color.Length == constraints.color1ChannelLength || color.Length == constraints.color4ChannelLength || color.Length == constraints.color5ChannelLength)
            {
                state.desiredColor = color;
                state.effectID = 0;
            }
            else
                throw new ArgumentOutOfRangeException("color", "Color must consist of 1, 4 or 5 channels.");

            if (colorFade >= constraints.colorFadeMin && colorFade <= constraints.colorFadeMax)
            {
                durations.colorFade = colorFade;
                state.durationsMs = durations;
            }
            else
                throw new ArgumentOutOfRangeException("colorFade", $"Value of colorFade must be between {constraints.colorFadeMin} and {constraints.colorFadeMax}.");

            try
            {
                return await SetStateAsync(state,isExtended: false);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
        public async Task<stateRgbw> setColorExtAsync(string color, int colorFade)
        {
            var state = new stateRgbw();
            var durations = new DurationsMs();
            if (color.Length == constraints.color1ChannelLength || color.Length == constraints.color4ChannelLength || color.Length == constraints.color5ChannelLength)
            {
                state.desiredColor = color;
                state.effectID = 0;
            }
            else
                throw new ArgumentOutOfRangeException("color", "Color must consist of 1, 4 or 5 channels.");

            if (colorFade >= constraints.colorFadeMin && colorFade <= constraints.colorFadeMax)
            {
                durations.colorFade = colorFade;
                state.durationsMs = durations;
            }
            else
                throw new ArgumentOutOfRangeException("colorFade", $"Value of colorFade must be between {constraints.colorFadeMin} and {constraints.colorFadeMax}.");

            try
            {
                return await SetStateAsync(state, isExtended: true);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
        public async Task<stateRgbw> setEffectAsync(int effectID, int effectFade, int effectStep)
        {
            var state = new stateRgbw();
            var durations = new DurationsMs();
            if (effectID >= constraints.effectIDMin && effectID <= constraints.effectIDMax)
            {
                state.effectID = effectID;
            }
            else
                throw new ArgumentOutOfRangeException("effectID", $"Value of effectID must be between {constraints.effectIDMin} and {constraints.effectIDMax}.");

            if (effectFade >= constraints.effectFadeMin && effectFade <= constraints.effectFadeMax)
            {
                durations.effectFade = effectFade;
            }
            else
                throw new ArgumentOutOfRangeException("effectFade", $"Value of effectFade must be between {constraints.effectFadeMin} and {constraints.effectFadeMax}.");

            if (effectStep >= constraints.effectStepMin && effectFade <= constraints.effectStepMax)
            {
                durations.effectStep = effectStep;
                state.durationsMs = durations;
            }
            else
                throw new ArgumentOutOfRangeException("effectStep", $"Value of effectStep must be between {constraints.effectStepMin} and {constraints.effectStepMax}.");

            try
            {
                return await SetStateAsync(state, isExtended: false);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
        public async Task<stateRgbw> setEffectExtAsync(int effectID, int effectFade, int effectStep)
        {
            var state = new stateRgbw();
            var durations = new DurationsMs();
            if (effectID >= constraints.effectIDMin && effectID <= constraints.effectIDMax)
            {
                state.effectID = effectID;
            }
            else
                throw new ArgumentOutOfRangeException("effectID", $"Value of effectID must be between {constraints.effectIDMin} and {constraints.effectIDMax}.");

            if (effectFade >= constraints.effectFadeMin && effectFade <= constraints.effectFadeMax)
            {
                durations.effectFade = effectFade;
            }
            else
                throw new ArgumentOutOfRangeException("effectFade", $"Value of effectFade must be between {constraints.effectFadeMin} and {constraints.effectFadeMax}.");

            if (effectStep >= constraints.effectStepMin && effectFade <= constraints.effectStepMax)
            {
                durations.effectStep = effectStep;
                state.durationsMs = durations;
            }
            else
                throw new ArgumentOutOfRangeException("effectStep", $"Value of effectStep must be between {constraints.effectStepMin} and {constraints.effectStepMax}.");

            try
            {
                return await SetStateAsync(state, isExtended: true);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
        public async Task<stateRgbw> setFavColorsAsync(OrderedDictionary favColors)
        {
            var state = new stateRgbw();

            for(int i=0; i < favColors.Count; i++)
            {
                if (!(favColors[i].ToString().Length == constraints.color1ChannelLength || favColors[i].ToString().Length == constraints.color4ChannelLength || favColors[i].ToString().Length == constraints.color5ChannelLength))
                {
                    throw new ArgumentOutOfRangeException($"favColor:{i}", $"Color must consist of 1, 4 or 5 channels.");
                }
            }

            state.favColors = favColors;

            try
            {
                return await SetStateAsync(state, isExtended: true);
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
        public async Task<Settings> GetSettingsAsync()
        {
            string endpoint = getSettingsEndpoint;
            HttpResponseMessage response = await client.GetAsync(APIAddress + endpoint);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var deserializedResponseBody = JsonConvert.DeserializeObject<settingsRoot>(responseBody);

            var fields = deserializedResponseBody.settings.rgbw.fieldsPreferences;

            foreach (var field in fields)
            {
                string temp = field[1].ToString();
                field.RemoveAt(1);
                field.Add("values",temp.Substring(1, temp.Length - 2).Split(',').Select(Int32.Parse).ToList());
            }

            return deserializedResponseBody.settings;
        }
        public async Task<Settings> SetSettingsAsync(Settings settings)
        {
            var data = AddRootSettings(settings);

            string endpoint = setSettingsEndpoint;
            HttpResponseMessage response = await client.PostAsync(APIAddress + endpoint, data);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            string responseBody = await response.Content.ReadAsStringAsync();

            var deserializedResponseBody = JsonConvert.DeserializeObject<settingsRoot>(responseBody);

            var fields = deserializedResponseBody.settings.rgbw.fieldsPreferences;

            foreach (var field in fields)
            {
                string temp = field[1].ToString();
                field.RemoveAt(1);
                field.Add("values", temp.Substring(1, temp.Length - 2).Split(',').Select(Int32.Parse).ToList());
            }

            return deserializedResponseBody.settings;
        }
        private StringContent AddRootSettings(Settings settings)
        {
            settingsRoot root = new settingsRoot(settings);
            var requestBody = JsonConvert.SerializeObject(root);
            return new StringContent(requestBody, Encoding.UTF8, "application/json");
        }
    }
}