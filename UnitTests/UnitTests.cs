using APIComLib;
using APIComLib.Models;
using APIComLib.Models.Settings;
using APIComLib.Models.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using stateRgbw = APIComLib.Models.State.Rgbw;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        string address = "http://127.0.0.1";

        [TestMethod]
        public async Task Get_current_state_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                  ""colormode"": 1,
                  ""effectid"": 2,
                  ""desiredcolor"": ""ff00300000"",
                  ""currentcolor"": ""ff00300000"",
                  ""lastoncolor"": ""ff00300000"",
                  ""durationsms"": {
                              ""colorfade"": 1000,
                    ""effectfade"": 1500,
                    ""effectstep"": 2000
                  }
                      }
                  }"),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            stateRgbw returnedRgbw = await ApiCom.GetCurrentStateAsync();

            var expectedRgbw = new stateRgbw();

            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 2;
            expectedRgbw.desiredColor = "ff00300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;
            expectedRgbw.durationsMs = durations;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
        }
        [TestMethod]
        public async Task Get_current_state_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");

            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.GetCurrentStateAsync();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }
        [TestMethod]
        public async Task Get_current_state_returns_valid_ext_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                ""colorMode"": 1,
                ""effectID"": 2,
                ""desiredColor"": ""ff00300000"",
                ""currentColor"": ""ff00300000"",
                ""lastOnColor"": ""ff00300000"",
                ""durationsMs"": {
                            ""colorFade"": 1000,
                    ""effectFade"": 1500,
                    ""effectStep"": 2000
                },
                ""effectNames"": {
                            ""0"": ""NONE"",
                    ""1"": ""FADE"",
                    ""2"": ""RGB"",
                    ""3"": ""POLICE"",
                    ""4"": ""RELAX"",
                    ""5"": ""STROBO"",
                    ""6"": ""BELL""
                },
                ""favColors"": {
                            ""0"": ""ff00000000"",
                    ""1"": ""00ff000000"",
                    ""2"": ""0000ff0000"",
                    ""3"": ""000000ff00"",
                    ""4"": ""00000000ff"",
                    ""5"": ""ff00ff0000"",
                    ""6"": ""ffff000000"",
                    ""7"": ""00ffff0000"",
                    ""8"": ""ff80000000"",
                    ""9"": ""0080ff0000""
                }
                    }
            }
            "),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            stateRgbw returnedRgbw = await ApiCom.GetCurrentStateExtAsync();

            var expectedRgbw = new stateRgbw();

            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 2;
            expectedRgbw.desiredColor = "ff00300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;
            expectedRgbw.durationsMs = durations;

            var effectNames = new OrderedDictionary();
            effectNames.Add(0, "NONE");
            effectNames.Add(1, "FADE");
            effectNames.Add(2, "RGB");
            effectNames.Add(3, "POLICE");
            effectNames.Add(4, "RELAX");
            effectNames.Add(5, "STROBO");
            effectNames.Add(6, "BELL");
            expectedRgbw.effectNames = effectNames;

            var favColors = new OrderedDictionary();
            favColors.Add(0, "ff00000000");
            favColors.Add(1, "00ff000000");
            favColors.Add(2, "0000ff0000");
            favColors.Add(3, "000000ff00");
            favColors.Add(4, "00000000ff");
            favColors.Add(5, "ff00ff0000");
            favColors.Add(6, "ffff000000");
            favColors.Add(7, "00ffff0000");
            favColors.Add(8, "ff80000000");
            favColors.Add(9, "0080ff0000");
            expectedRgbw.favColors = favColors;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
            Assert.AreEqual(expectedRgbw.effectNames.Count, returnedRgbw.effectNames.Count);
            Assert.AreEqual(expectedRgbw.favColors.Count, returnedRgbw.favColors.Count);
            for (int i =0;i<expectedRgbw.effectNames.Count;i++)
            {
                Assert.AreEqual(expectedRgbw.effectNames[i].ToString(), returnedRgbw.effectNames[i].ToString());
            }
            for (int i = 0; i < expectedRgbw.favColors.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.favColors[i].ToString(), returnedRgbw.favColors[i].ToString());
            }
        }
        [TestMethod]
        public async Task Get_current_state_ext_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");

            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.GetCurrentStateExtAsync();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }
        [TestMethod]
        public async Task Set_color_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                  ""colormode"": 1,
                  ""effectid"": 0,
                  ""desiredcolor"": ""ffff300000"",
                  ""currentcolor"": ""ff00300000"",
                  ""lastoncolor"": ""ff00300000"",
                  ""durationsms"": {
                              ""colorfade"": 1000,
                    ""effectfade"": 1500,
                    ""effectstep"": 2000
                  }
                      }
                  }"),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            stateRgbw returnedRgbw = await ApiCom.SetColorAsync("ffff300000", 1000);

            var expectedRgbw = new stateRgbw();

            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 0;
            expectedRgbw.desiredColor = "ffff300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;

            expectedRgbw.durationsMs = durations;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
        }
        [TestMethod]
        public async Task Set_color_returns_HTTP_code_400()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
           {
               await ApiCom.SetColorAsync("ffff300000", 1000);
           });
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_color_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetColorAsync("ffff300000", 1000);
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_color_returns_Arg_Out_Of_Range_Ex_color()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetColorAsync("ffff3", 1000);
            });
            Assert.AreEqual("color", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_color_returns_Arg_Out_Of_Range_Ex_colorFade()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetColorAsync("ffff300000", 0);
            });
            Assert.AreEqual("colorFade", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_color_ext_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                ""colorMode"": 1,
                ""effectID"": 0,
                ""desiredColor"": ""ffff300000"",
                ""currentColor"": ""ff00300000"",
                ""lastOnColor"": ""ff00300000"",
                ""durationsMs"": {
                            ""colorFade"": 1000,
                    ""effectFade"": 1500,
                    ""effectStep"": 2000
                },
                ""effectNames"": {
                            ""0"": ""NONE"",
                    ""1"": ""FADE"",
                    ""2"": ""RGB"",
                    ""3"": ""POLICE"",
                    ""4"": ""RELAX"",
                    ""5"": ""STROBO"",
                    ""6"": ""BELL""
                },
                ""favColors"": {
                            ""0"": ""ff00000000"",
                    ""1"": ""00ff000000"",
                    ""2"": ""0000ff0000"",
                    ""3"": ""000000ff00"",
                    ""4"": ""00000000ff"",
                    ""5"": ""ff00ff0000"",
                    ""6"": ""ffff000000"",
                    ""7"": ""00ffff0000"",
                    ""8"": ""ff80000000"",
                    ""9"": ""0080ff0000""
                }
                    }
            }
            "),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            stateRgbw returnedRgbw = await ApiCom.SetColorExtAsync("ffff300000", 1000);

            var expectedRgbw = new stateRgbw();

            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 0;
            expectedRgbw.desiredColor = "ffff300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;
            expectedRgbw.durationsMs = durations;

            var effectNames = new OrderedDictionary();
            effectNames.Add(0, "NONE");
            effectNames.Add(1, "FADE");
            effectNames.Add(2, "RGB");
            effectNames.Add(3, "POLICE");
            effectNames.Add(4, "RELAX");
            effectNames.Add(5, "STROBO");
            effectNames.Add(6, "BELL");
            expectedRgbw.effectNames = effectNames;

            var favColors = new OrderedDictionary();
            favColors.Add(0, "ff00000000");
            favColors.Add(1, "00ff000000");
            favColors.Add(2, "0000ff0000");
            favColors.Add(3, "000000ff00");
            favColors.Add(4, "00000000ff");
            favColors.Add(5, "ff00ff0000");
            favColors.Add(6, "ffff000000");
            favColors.Add(7, "00ffff0000");
            favColors.Add(8, "ff80000000");
            favColors.Add(9, "0080ff0000");
            expectedRgbw.favColors = favColors;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
            Assert.AreEqual(expectedRgbw.effectNames.Count, returnedRgbw.effectNames.Count);
            Assert.AreEqual(expectedRgbw.favColors.Count, returnedRgbw.favColors.Count);
            for (int i = 0; i < expectedRgbw.effectNames.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.effectNames[i].ToString(), returnedRgbw.effectNames[i].ToString());
            }
            for (int i = 0; i < expectedRgbw.favColors.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.favColors[i].ToString(), returnedRgbw.favColors[i].ToString());
            }
        }
        [TestMethod]
        public async Task Set_color_ext_returns_HTTP_code_400()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetColorExtAsync("ffff300000", 1000);
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_color_ext_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetColorExtAsync("ffff300000", 1000);
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_color_ext_returns_Arg_Out_Of_Range_Ex_color()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetColorExtAsync("ffff3", 1000);
            });
            Assert.AreEqual("color", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_color_ext_returns_Arg_Out_Of_Range_Ex_colorFade()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetColorExtAsync("ffff300000", 0);
            });
            Assert.AreEqual("colorFade", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_effect_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                  ""colormode"": 1,
                  ""effectid"": 5,
                  ""desiredcolor"": ""ffff300000"",
                  ""currentcolor"": ""ff00300000"",
                  ""lastoncolor"": ""ff00300000"",
                  ""durationsms"": {
                              ""colorfade"": 1000,
                    ""effectfade"": 1500,
                    ""effectstep"": 2000
                  }
                      }
                  }"),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            stateRgbw returnedRgbw = await ApiCom.SetEffectAsync(5,1500,2000);

            var expectedRgbw = new stateRgbw();

            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 5;
            expectedRgbw.desiredColor = "ffff300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;
            expectedRgbw.durationsMs = durations;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
        }
        [TestMethod]
        public async Task Set_effect_returns_HTTP_code_400()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            var ex =await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetEffectAsync(5, 1500, 2000);
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_effect_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetEffectAsync(5, 1500, 2000);
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_effect_returns_Arg_Out_Of_Range_Ex_effectID()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetEffectAsync(-1, 1500, 2000);
            });
            Assert.AreEqual("effectID", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_effect_returns_Arg_Out_Of_Range_Ex_effectFade()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetEffectAsync(5, 0, 2000);
            });
            Assert.AreEqual("effectFade", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_effect_returns_Arg_Out_Of_Range_Ex_effectStep()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetEffectAsync(5, 1500, 0);
            });
            Assert.AreEqual("effectStep", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_effect_ext_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                ""colorMode"": 1,
                ""effectID"": 5,
                ""desiredColor"": ""ffff300000"",
                ""currentColor"": ""ff00300000"",
                ""lastOnColor"": ""ff00300000"",
                ""durationsMs"": {
                            ""colorFade"": 1000,
                    ""effectFade"": 1500,
                    ""effectStep"": 2000
                },
                ""effectNames"": {
                            ""0"": ""NONE"",
                    ""1"": ""FADE"",
                    ""2"": ""RGB"",
                    ""3"": ""POLICE"",
                    ""4"": ""RELAX"",
                    ""5"": ""STROBO"",
                    ""6"": ""BELL""
                },
                ""favColors"": {
                            ""0"": ""ff00000000"",
                    ""1"": ""00ff000000"",
                    ""2"": ""0000ff0000"",
                    ""3"": ""000000ff00"",
                    ""4"": ""00000000ff"",
                    ""5"": ""ff00ff0000"",
                    ""6"": ""ffff000000"",
                    ""7"": ""00ffff0000"",
                    ""8"": ""ff80000000"",
                    ""9"": ""0080ff0000""
                }
                    }
            }
            "),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            stateRgbw returnedRgbw = await ApiCom.SetEffectExtAsync(5, 1500, 2000);

            var expectedRgbw = new stateRgbw();

            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 5;
            expectedRgbw.desiredColor = "ffff300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;
            expectedRgbw.durationsMs = durations;

            var effectNames = new OrderedDictionary();
            effectNames.Add(0, "NONE");
            effectNames.Add(1, "FADE");
            effectNames.Add(2, "RGB");
            effectNames.Add(3, "POLICE");
            effectNames.Add(4, "RELAX");
            effectNames.Add(5, "STROBO");
            effectNames.Add(6, "BELL");
            expectedRgbw.effectNames = effectNames;

            var favColors = new OrderedDictionary();
            favColors.Add(0, "ff00000000");
            favColors.Add(1, "00ff000000");
            favColors.Add(2, "0000ff0000");
            favColors.Add(3, "000000ff00");
            favColors.Add(4, "00000000ff");
            favColors.Add(5, "ff00ff0000");
            favColors.Add(6, "ffff000000");
            favColors.Add(7, "00ffff0000");
            favColors.Add(8, "ff80000000");
            favColors.Add(9, "0080ff0000");
            expectedRgbw.favColors = favColors;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
            Assert.AreEqual(expectedRgbw.effectNames.Count, returnedRgbw.effectNames.Count);
            Assert.AreEqual(expectedRgbw.favColors.Count, returnedRgbw.favColors.Count);
            for (int i = 0; i < expectedRgbw.effectNames.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.effectNames[i].ToString(), returnedRgbw.effectNames[i].ToString());
            }
            for (int i = 0; i < expectedRgbw.favColors.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.favColors[i].ToString(), returnedRgbw.favColors[i].ToString());
            }
        }
        [TestMethod]
        public async Task Set_effect_ext_returns_HTTP_code_400()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetEffectExtAsync(5, 1500, 2000);
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_effect_ext_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetEffectExtAsync(5, 1500, 2000);
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_effect_ext_returns_Arg_Out_Of_Range_Ex_effectID()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetEffectExtAsync(-1, 1500, 2000);
            });
            Assert.AreEqual("effectID", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_effect_ext_returns_Arg_Out_Of_Range_Ex_effectFade()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetEffectExtAsync(5, 0, 2000);
            });
            Assert.AreEqual("effectFade", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_effect_ext_returns_Arg_Out_Of_Range_Ex_effectStep()
        {

            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);


            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetEffectExtAsync(5, 1500, 0);
            });
            Assert.AreEqual("effectStep", ex.ParamName);
        }
        [TestMethod]
        public async Task Set_favColors_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""rgbw"": {
                ""colorMode"": 1,
                ""effectID"": 5,
                ""desiredColor"": ""ffff300000"",
                ""currentColor"": ""ff00300000"",
                ""lastOnColor"": ""ff00300000"",
                ""durationsMs"": {
                            ""colorFade"": 1000,
                    ""effectFade"": 1500,
                    ""effectStep"": 2000
                },
                ""effectNames"": {
                            ""0"": ""NONE"",
                    ""1"": ""FADE"",
                    ""2"": ""RGB"",
                    ""3"": ""POLICE"",
                    ""4"": ""RELAX"",
                    ""5"": ""STROBO"",
                    ""6"": ""BELL""
                },
                ""favColors"": {
                            ""0"": ""ff00000000"",
                    ""1"": ""00ff000000"",
                    ""2"": ""0000ff0000"",
                    ""3"": ""000000ff00"",
                    ""4"": ""00000000ff"",
                    ""5"": ""ff00ff0000""
                }
                    }
            }
            "),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            var setfavColors = new OrderedDictionary();
            setfavColors.Add(0, "ff00000000");
            setfavColors.Add(1, "00ff000000");
            setfavColors.Add(2, "0000ff0000");
            setfavColors.Add(3, "000000ff00");
            setfavColors.Add(4, "00000000ff");
            setfavColors.Add(5, "ff00ff0000");
            stateRgbw returnedRgbw = await ApiCom.SetFavColorsAsync(setfavColors);

            var expectedRgbw = new stateRgbw();
            expectedRgbw.colorMode = 1;
            expectedRgbw.effectID = 5;
            expectedRgbw.desiredColor = "ffff300000";
            expectedRgbw.currentColor = "ff00300000";
            expectedRgbw.lastOnColor = "ff00300000";

            var durations = new DurationsMs();
            durations.colorFade = 1000;
            durations.effectFade = 1500;
            durations.effectStep = 2000;
            expectedRgbw.durationsMs = durations;

            var effectNames = new OrderedDictionary();
            effectNames.Add(0, "NONE");
            effectNames.Add(1, "FADE");
            effectNames.Add(2, "RGB");
            effectNames.Add(3, "POLICE");
            effectNames.Add(4, "RELAX");
            effectNames.Add(5, "STROBO");
            effectNames.Add(6, "BELL");
            expectedRgbw.effectNames = effectNames;

            var favColors = new OrderedDictionary();
            favColors.Add(0, "ff00000000");
            favColors.Add(1, "00ff000000");
            favColors.Add(2, "0000ff0000");
            favColors.Add(3, "000000ff00");
            favColors.Add(4, "00000000ff");
            favColors.Add(5, "ff00ff0000");
            expectedRgbw.favColors = favColors;

            Assert.AreEqual(expectedRgbw.colorMode, returnedRgbw.colorMode);
            Assert.AreEqual(expectedRgbw.effectID, returnedRgbw.effectID);
            Assert.AreEqual(expectedRgbw.desiredColor, returnedRgbw.desiredColor);
            Assert.AreEqual(expectedRgbw.currentColor, returnedRgbw.currentColor);
            Assert.AreEqual(expectedRgbw.lastOnColor, returnedRgbw.lastOnColor);
            Assert.AreEqual(expectedRgbw.durationsMs.colorFade, returnedRgbw.durationsMs.colorFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectFade, returnedRgbw.durationsMs.effectFade);
            Assert.AreEqual(expectedRgbw.durationsMs.effectStep, returnedRgbw.durationsMs.effectStep);
            Assert.AreEqual(expectedRgbw.effectNames.Count, returnedRgbw.effectNames.Count);
            Assert.AreEqual(expectedRgbw.favColors.Count, returnedRgbw.favColors.Count);
            for (int i = 0; i < expectedRgbw.effectNames.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.effectNames[i].ToString(), returnedRgbw.effectNames[i].ToString());
            }
            for (int i = 0; i < expectedRgbw.favColors.Count; i++)
            {
                Assert.AreEqual(expectedRgbw.favColors[i].ToString(), returnedRgbw.favColors[i].ToString());
            }
        }
        [TestMethod]
        public async Task Set_favColors_returns_HTTP_code_400()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            var setfavColors = new OrderedDictionary();
            setfavColors.Add(0, "ff00000000");
            setfavColors.Add(1, "00ff000000");
            setfavColors.Add(2, "0000ff0000");
            setfavColors.Add(3, "000000ff00");
            setfavColors.Add(4, "00000000ff");
            setfavColors.Add(5, "ff00ff0000");

            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetFavColorsAsync(setfavColors);
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_favColors_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");

            var setfavColors = new OrderedDictionary();
            setfavColors.Add(0, "ff00000000");
            setfavColors.Add(1, "00ff000000");
            setfavColors.Add(2, "0000ff0000");
            setfavColors.Add(3, "000000ff00");
            setfavColors.Add(4, "00000000ff");
            setfavColors.Add(5, "ff00ff0000");

            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetFavColorsAsync(setfavColors);
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);

        }
        [TestMethod]
        public async Task Set_favColors_returns_Arg_Out_Of_Range_Ex_favColor()
        {
            var httpClient = new HttpClient();

            var ApiCom = new APICommunication(httpClient, address);

            var setfavColors = new OrderedDictionary();
            setfavColors.Add(0, "ff00000000");
            setfavColors.Add(1, "00ff000000");
            setfavColors.Add(2, "0000ff0000");
            setfavColors.Add(3, "00000");
            setfavColors.Add(4, "00000000ff");
            setfavColors.Add(5, "ff00ff0000");

            var ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await ApiCom.SetFavColorsAsync(setfavColors);
            });
            Assert.AreEqual("favColor:3", ex.ParamName);
        }

        [TestMethod]
        public async Task Get_settings_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
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
                }"),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            Settings returnedSettings = await ApiCom.GetSettingsAsync();

            var expectedSettings = new Settings();
            expectedSettings.deviceName = "My BleBox device name";

            var tunnel = new Tunnel(1);
            expectedSettings.tunnel = tunnel;

            var statusLed = new StatusLed(1);
            expectedSettings.statusLed = statusLed;

            var rgbw = new APIComLib.Models.Settings.Rgbw(1,1,600,4);

            var fieldsPreferences = new List<OrderedDictionary>();
            var buttonMode = new OrderedDictionary();
            buttonMode.Add("name","buttonMode");
            buttonMode.Add("values", new List<int>() { 4 });
            fieldsPreferences.Add(buttonMode);
            var colorMode = new OrderedDictionary();
            colorMode.Add("name", "colorMode");
            colorMode.Add("values", new List<int>() { 1 });
            fieldsPreferences.Add(colorMode);
            var outputMode = new OrderedDictionary();
            outputMode.Add("name", "outputMode");
            outputMode.Add("values", new List<int>() { 1 });
            fieldsPreferences.Add(outputMode);
            var pwmFreq = new OrderedDictionary();
            pwmFreq.Add("name", "pwmFreq");
            pwmFreq.Add("values", new List<int>() { 600 });
            fieldsPreferences.Add(pwmFreq);
            rgbw.fieldsPreferences = fieldsPreferences;
            expectedSettings.rgbw = rgbw;


            Assert.AreEqual(expectedSettings.deviceName,returnedSettings.deviceName);
            Assert.AreEqual(expectedSettings.tunnel.enabled, returnedSettings.tunnel.enabled);
            Assert.AreEqual(expectedSettings.statusLed.enabled, returnedSettings.statusLed.enabled);
            Assert.AreEqual(expectedSettings.rgbw.colorMode, returnedSettings.rgbw.colorMode);
            Assert.AreEqual(expectedSettings.rgbw.outputMode, returnedSettings.rgbw.outputMode);
            Assert.AreEqual(expectedSettings.rgbw.pwmFreq, returnedSettings.rgbw.pwmFreq);
            Assert.AreEqual(expectedSettings.rgbw.buttonMode, returnedSettings.rgbw.buttonMode);
            Assert.AreEqual(expectedSettings.rgbw.fieldsPreferences.Count, returnedSettings.rgbw.fieldsPreferences.Count);
            for (int i = 0; i < expectedSettings.rgbw.fieldsPreferences.Count; i++)
            {
                Assert.AreEqual(expectedSettings.rgbw.fieldsPreferences[i][0], returnedSettings.rgbw.fieldsPreferences[i][0]);
                CollectionAssert.AreEqual((List<int>)expectedSettings.rgbw.fieldsPreferences[i][1], (List<int>)returnedSettings.rgbw.fieldsPreferences[i][1]);
            }
        }
        [TestMethod]
        public async Task Get_settings_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");

            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.GetSettingsAsync();
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }
        [TestMethod]
        public async Task Set_settings_returns_valid_state()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""settings"": {
                ""deviceName"": ""My BleBox"",
                ""tunnel"": {
                            ""enabled"": 0
                },
                ""statusLed"": {
                            ""enabled"": 0
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
                }"),
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            var setSettings = new Settings();
            setSettings.deviceName = "My BleBox";

            var setTunnel = new Tunnel(0);
            setSettings.tunnel = setTunnel;

            var setStatusLed = new StatusLed(0);
            setSettings.statusLed = setStatusLed;

            var setRgbw = new APIComLib.Models.Settings.Rgbw(1,1,600,4);
            setSettings.rgbw = setRgbw;

            Settings returnedSettings = await ApiCom.SetSettingsAsync(setSettings);

            var expectedSettings = new Settings();
            expectedSettings.deviceName = "My BleBox";

            var tunnel = new Tunnel(0);
            expectedSettings.tunnel = tunnel;

            var statusLed = new StatusLed(0);
            expectedSettings.statusLed = statusLed;

            var rgbw = new APIComLib.Models.Settings.Rgbw(1,1,600,4);

            var fieldsPreferences = new List<OrderedDictionary>();
            var buttonMode = new OrderedDictionary();
            buttonMode.Add("name", "buttonMode");
            buttonMode.Add("values", new List<int>() { 4 });
            fieldsPreferences.Add(buttonMode);
            var colorMode = new OrderedDictionary();
            colorMode.Add("name", "colorMode");
            colorMode.Add("values", new List<int>() { 1 });
            fieldsPreferences.Add(colorMode);
            var outputMode = new OrderedDictionary();
            outputMode.Add("name", "outputMode");
            outputMode.Add("values", new List<int>() { 1 });
            fieldsPreferences.Add(outputMode);
            var pwmFreq = new OrderedDictionary();
            pwmFreq.Add("name", "pwmFreq");
            pwmFreq.Add("values", new List<int>() { 600 });
            fieldsPreferences.Add(pwmFreq);
            rgbw.fieldsPreferences = fieldsPreferences;
            expectedSettings.rgbw = rgbw;


            Assert.AreEqual(expectedSettings.deviceName, returnedSettings.deviceName);
            Assert.AreEqual(expectedSettings.tunnel.enabled, returnedSettings.tunnel.enabled);
            Assert.AreEqual(expectedSettings.statusLed.enabled, returnedSettings.statusLed.enabled);
            Assert.AreEqual(expectedSettings.rgbw.colorMode, returnedSettings.rgbw.colorMode);
            Assert.AreEqual(expectedSettings.rgbw.outputMode, returnedSettings.rgbw.outputMode);
            Assert.AreEqual(expectedSettings.rgbw.pwmFreq, returnedSettings.rgbw.pwmFreq);
            Assert.AreEqual(expectedSettings.rgbw.buttonMode, returnedSettings.rgbw.buttonMode);
            Assert.AreEqual(expectedSettings.rgbw.fieldsPreferences.Count, returnedSettings.rgbw.fieldsPreferences.Count);
            for (int i = 0; i < expectedSettings.rgbw.fieldsPreferences.Count; i++)
            {
                Assert.AreEqual(expectedSettings.rgbw.fieldsPreferences[i][0], returnedSettings.rgbw.fieldsPreferences[i][0]);
                CollectionAssert.AreEqual((List<int>)expectedSettings.rgbw.fieldsPreferences[i][1], (List<int>)returnedSettings.rgbw.fieldsPreferences[i][1]);
            }
        }
        [TestMethod]
        public async Task Set_settings_returns_HTTP_code_400()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, address);

            var setSettings = new Settings();
            setSettings.deviceName = "My BleBox";

            var setTunnel = new Tunnel(0);
            setSettings.tunnel = setTunnel;

            var setStatusLed = new StatusLed(0);
            setSettings.statusLed = setStatusLed;

            var setRgbw = new APIComLib.Models.Settings.Rgbw(1,1,600,4);
            setSettings.rgbw = setRgbw;


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetSettingsAsync(setSettings);
            });
            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
        }
        [TestMethod]
        public async Task Set_settings_returns_HTTP_code_404()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var ApiCom = new APICommunication(httpClient, "http://127.0.0.2");

            var setSettings = new Settings();
            setSettings.deviceName = "My BleBox";

            var setTunnel = new Tunnel(0);
            setSettings.tunnel = setTunnel;

            var setStatusLed = new StatusLed(0);
            setSettings.statusLed = setStatusLed;

            var setRgbw = new APIComLib.Models.Settings.Rgbw(1,1,600,4);
            setSettings.rgbw = setRgbw;


            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await ApiCom.SetSettingsAsync(setSettings);
            });
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }
    }
}