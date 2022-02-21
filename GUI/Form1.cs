using APIComLib;
using APIComLib.Models;
using APIComLib.Models.Settings;
using APIComLib.Models.State;
using Newtonsoft.Json;

namespace GUI
{
    public partial class Form1 : Form
    {
        public APICommunication connector;

        public APIComLib.Models.State.Rgbw currentState;

        public Settings currentSettings;

        public string storedJSON = @"{
                ""settings"": {
                ""deviceName"": ""My BleBox device name"",
                ""tunnel"": {
                            ""enabled"": 1
                },
                ""statusLed"": {
                            ""enabled"": 1
                },
                ""rgbw"": {
                            ""colorMode"": 1,
                    ""outputMode"": 1,
                    ""pwmFreq"": 600,
                    ""buttonMode"": 4,
                    ""fieldsPreferences"": [
                    {
                                ""name"": ""buttonMode"",
                        ""values"": [
                        4
                        ]
                    },
                    {
                                ""name"": ""colorMode"",
                        ""values"": [
                        1
                        ]
                    },
                    {
                                ""name"": ""outputMode"",
                        ""values"": [
                        1
                        ]
                    },
                    {
                                ""name"": ""pwmFreq"",
                        ""values"": [
                        600
                        ]
                    }
                    ]
                }
                    }
                }";
        public Form1()
        {
            InitializeComponent();
        }

        private void SetIP_Click(object sender, EventArgs e)
        {
            SetIP_Form setIP_Form = new SetIP_Form();
            setIP_Form.ShowDialog();
            string address = "http://" + setIP_Form.IPAddress;

            HttpClient client = new HttpClient();

            connector = new APICommunication(client, address);

            MessageBox.Show("Successfuly set IP address");

            GetStatus.Enabled = true;
            SetColor.Enabled = true;
            SetEffect.Enabled = true;
            GetSettings.Enabled = true;
            SetSettings.Enabled = true;
            GetJSON.Enabled = true;
        }

        private async void GetStatus_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if(!ExtParam.Checked)
                    currentState = await connector.GetCurrentStateAsync();
                else
                    currentState = await connector.GetCurrentStateExtAsync();
                storedJSON = JsonConvert.SerializeObject(currentState);
                CurrentColor.Text = currentState.currentColor;
                CurrentEffect.Text = Effects.getEffect(currentState.effectID);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Exception occured. Status code {ex.StatusCode}");
            }
        }

        private async void SetColor_ClickAsync(object sender, EventArgs e)
        {
            SetColor_Form setColor_Form = new SetColor_Form();
            setColor_Form.ShowDialog();

            try
            {
                if (!ExtParam.Checked)
                    currentState = await connector.SetColorAsync(setColor_Form.colorValue,setColor_Form.colorFade);
                else
                    currentState = await connector.SetColorExtAsync(setColor_Form.colorValue, setColor_Form.colorFade);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Exception occured. Code {ex.StatusCode}");
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Exception occured. Value of {ex.ParamName} is invalid. {ex.Message}", "Error");
            }
            storedJSON = JsonConvert.SerializeObject(currentState);
            CurrentColor.Text = currentState.currentColor;
            CurrentEffect.Text = Effects.getEffect(currentState.effectID);
        }

        private async void SetEffect_ClickAsync(object sender, EventArgs e)
        {
            SetEffect_Form setEffect_Form = new SetEffect_Form();
            setEffect_Form.ShowDialog();

            try
            {
                if (!ExtParam.Checked)
                    currentState = await connector.SetEffectAsync(setEffect_Form.effectID, setEffect_Form.effectFade, setEffect_Form.effectStep);
                else
                    currentState = await connector.SetEffectExtAsync(setEffect_Form.effectID, setEffect_Form.effectFade, setEffect_Form.effectStep);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Exception occured. Code {ex.StatusCode}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Exception occured. Value of {ex.ParamName} is invalid. {ex.Message}", "Error");
            }
            storedJSON = JsonConvert.SerializeObject(currentState);
            CurrentColor.Text = currentState.currentColor;
            CurrentEffect.Text = Effects.getEffect(currentState.effectID);
        }

        private async void SetFavColors_ClickAsync(object sender, EventArgs e)
        {
            SetFavColors_Form SetFavColors_Form = new SetFavColors_Form();
            SetFavColors_Form.ShowDialog();

            try
            {
                    currentState = await connector.SetFavColorsAsync(SetFavColors_Form.favColors);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Exception occured. Code {ex.StatusCode}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Exception occured. Value of {ex.ParamName} is invalid. {ex.Message}", "Error");
            }
            storedJSON = JsonConvert.SerializeObject(currentState);
            CurrentColor.Text = currentState.currentColor;
            CurrentEffect.Text = Effects.getEffect(currentState.effectID);
        }

        private async void GetSettings_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                currentSettings = await connector.GetSettingsAsync();
                storedJSON = JsonConvert.SerializeObject(currentState);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Exception occured. Status code {ex.StatusCode}");
            }
        }

        private async void SetSettings_ClickAsync(object sender, EventArgs e)
        {
            SetSettings_Form SetSettings_Form = new SetSettings_Form();
            SetSettings_Form.ShowDialog();

            try
            {
                currentSettings = await connector.SetSettingsAsync(SetSettings_Form.settings);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Exception occured. Code {ex.StatusCode}");
            }
            storedJSON = JsonConvert.SerializeObject(currentState);
        }

        private void GetJSON_Click(object sender, EventArgs e)
        {
            JSONView_Form JSONView_Form = new JSONView_Form(storedJSON);
            JSONView_Form.ShowDialog();
        }

        private void ExtParam_CheckedChanged(object sender, EventArgs e)
        {
            if(ExtParam.Checked)
                SetFavColors.Enabled = true;
            else
                SetFavColors.Enabled = false;
        }
    }
}