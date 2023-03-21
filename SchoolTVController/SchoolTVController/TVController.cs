using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SchoolTVController;
using System.Windows.Media.Imaging;
using System.IO;

namespace TVControl
{
    public class TVController
    {
        public enum eState
        {
            Off = 0,
            On,
            ERROR
        }
        const string AccessToken = "981e0e15-c03e-4e77-bbb4-efba620d711d";
        public delegate Task<bool> Event();
        const string APIPoint = "https://api.smartthings.com/v1/";
        const float MaxTimeOut = 13.0f;

        public static async Task<bool> SwitchTV(TVData data, eState state, bool update = true)
        {
            //목표 상태를 문자열로 변환
            string targetState = "off";
            switch (state)
            {
                case eState.Off:
                    targetState = "off";
                    break;
                case eState.On:
                    targetState = "on";
                    break;
            }

            //HTTP로 전달할 명령 데이터 생성
            //Json에서 사용하기 위하여 commandData로 묶어서 사용합니다
            var commandData = new
            {
                commands = new[]
                {
                    new
                    {
                        component = "main",
                        capability = "switch", //전원
                        command = targetState,
                        arguments = Array.Empty<string>(),
                    },
                },
            };
            SchoolTVController.MainWindow.FindTVViewPanel(data, out SchoolTVController.TVViewer viewer);

            DataSender sender = new DataSender();
            sender.Viewer = viewer;
            sender.Data = data;
            sender.CommandData = commandData;
            sender.RightAfterRequest = () => {
                sender.Viewer.ONOFFTextBlock.Text = "Loading...";
            };
            sender.SuccessCondition = async () => {
                var result = await GetTVSwitch(data);
                if (result == state)
                    return true;
                return false;
            };
            sender.SuccessMessage = $"[SWITCH] TV switched to {targetState}. Device: {data.Name}";
            sender.FailMessage = $"[SWITCH] Failed to switch TV to {targetState}: Device: {data.Name}";

            return await SendCommand(sender);
        }
        public static async Task<bool> ChangeTVChannel(TVData data, string channel)
        {
            var commandData = new
            {
                commands = new[]
                {
                        new
                        {
                            component = "main",
                            capability = "tvChannel",
                            command = "setTvChannel",
                            arguments = new[] { channel }
                        }
                    },
                sequence = Guid.NewGuid().ToString()
            };

            SchoolTVController.MainWindow.FindTVViewPanel(data, out SchoolTVController.TVViewer viewer);

            DataSender sender = new DataSender();
            sender.Viewer = viewer;
            sender.Data = data;
            sender.CommandData = commandData;
            sender.RightAfterRequest = () => {
                sender.Viewer.ChannelTextBlock.Text = "Loading...";
                sender.Viewer.ChannelNameTextBlock.Text = "Loading...";
            };
            sender.SuccessCondition = async () => {
                var result = await GetTVChannel(data);
                if (result == channel)
                    return true;
                return false;
            };
            sender.SuccessMessage = $"[CHANNEL] TV's channel is set to {channel}. Device: {sender.Data.Name}";
            sender.FailMessage = $"[CHANNEL] Failed to set TV's channel to {channel}. Device: {sender.Data.Name}";

            return await SendCommand(sender);
        }
        public static async Task<bool> ChangeTVChannelName(TVData data, string channel)
        {
            var commandData = new
            {
                commands = new[]
                {
                        new
                        {
                            component = "main",
                            capability = "tvChannel",
                            command = "setTvChannelName",
                            arguments = new[] { channel }
                        }
                    },
                sequence = Guid.NewGuid().ToString()
            };

            SchoolTVController.MainWindow.FindTVViewPanel(data, out SchoolTVController.TVViewer viewer);

            DataSender sender = new DataSender();
            sender.Viewer = viewer;
            sender.Data = data;
            sender.CommandData = commandData;
            sender.RightAfterRequest = () => {
                sender.Viewer.ChannelTextBlock.Text = "Loading...";
                sender.Viewer.ChannelNameTextBlock.Text = "Loading...";
            };
            sender.SuccessCondition = async () => {
                var result = await GetTVChannel(data);
                if (result == channel)
                    return true;
                return false;
            };
            sender.SuccessMessage = $"[CHANNEL] TV's channel is set to {channel}. Device: {sender.Data.Name}";
            sender.FailMessage = $"[CHANNEL] Failed to set TV's channel to {channel}. Device: {sender.Data.Name}";

            return await SendCommand(sender);
        }
        public static async Task<bool> ChangeTVMediaInput(TVData data, string mediaInputName)
        {
            // change channel
            var commandData = new
            {
                commands = new[]
                {
                    new
                    {
                        component = "main",
                        capability = "mediaInputSource",
                        command = "setInputSource",
                        arguments = new[] { mediaInputName }
                    }
                },
                sequence = Guid.NewGuid().ToString()
            };

            SchoolTVController.MainWindow.FindTVViewPanel(data, out SchoolTVController.TVViewer viewer);

            DataSender sender = new DataSender();
            sender.Viewer = viewer;
            sender.Data = data;
            sender.CommandData = commandData;
            sender.RightAfterRequest = () =>
            {
                sender.Viewer.MediaInputTextBlock.Text = "Loading...";
            };
            sender.SuccessCondition = async () =>
            {
                var result = await GetTVMediaInput(data);
                if (result == mediaInputName)
                    return true;
                return false;
            };
            sender.SuccessMessage = $"[MEDIA] TV's MediaInput is set to {mediaInputName}. Device: {sender.Data.Name}";
            sender.FailMessage = $"[CHANNEL] Failed to set TV's MediaInput to {mediaInputName}. Device: {sender.Data.Name}";

            return await SendCommand(sender);
        }
        public static async Task<bool> ChangeTVMute(TVData data, bool mute)
        {
            var muteCommandData = new
            {
                commands = new[]
                {
                    new
                    {
                        component = "main",
                        capability = "audioMute",
                        command = "mute",
                        arguments = Array.Empty<string>(),
                    }
                 },
                sequence = Guid.NewGuid().ToString()
            };
            var unmuteCommandData = new
            {
                commands = new[]
    {
                    new
                    {
                        component = "main",
                        capability = "audioMute",
                        command = "unmute",
                        arguments = Array.Empty<string>(),
                    }
                 },
                sequence = Guid.NewGuid().ToString()
            };

            SchoolTVController.MainWindow.FindTVViewPanel(data, out SchoolTVController.TVViewer viewer);

            DataSender sender = new DataSender();
            sender.Viewer = viewer;
            sender.Data = data;
            sender.CommandData = mute == true ? muteCommandData : unmuteCommandData;
            sender.RightAfterRequest = () => {
                if(sender.Viewer.AdvancedController != null)
                {
                    sender.Viewer.AdvancedController.MuteTextBlock.Text = "Loading...";
                }
            };
            sender.SuccessCondition = async () => {
                var result = await GetTVMute(data);
                if (result == mute)
                    return true;
                return false;
            };
            string muteState = mute == true ? "mute" : "unmute";
            sender.SuccessMessage = $"[MUTE] TV's channel is {muteState}. Device: {sender.Data.Name}";
            sender.FailMessage = $"[MUTE] Failed to set TV's {muteState}. Device: {sender.Data.Name}";

            return await SendCommand(sender);
        }
        static async Task<bool> SendCommand(DataSender sender)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            sender.Viewer.isWorking = true;

            var headers = new
            {
                Authorization = $"Bearer {AccessToken}",
                Content_Type = "application/json",
            };

            var client = new HttpClient();
            //권한 설정
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", headers.Content_Type);

            var response = await client.GetAsync(APIPoint + $"devices/{sender.Data.DeviceID}/status");
            //var content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(JsonConvert.DeserializeObject(content));

            if (response.IsSuccessStatusCode == true)
            {
                //통신 시도
                response = await client.PostAsync(APIPoint + $"devices/{sender.Data.DeviceID}/commands",
                                                      new StringContent(JObject.FromObject(sender.CommandData).ToString(), System.Text.Encoding.UTF8, "application/json"));

                sender.RightAfterRequest?.Invoke();
                while ((await sender.SuccessCondition()) == false)
                {
                    if(stopWatch.Elapsed.Seconds > MaxTimeOut)
                    {
                        sender.Viewer.isWorking = false;
                        sender.Viewer.Refresh();
                        Console.WriteLine($"Time Out Error getting device status. Device: {sender.Data.Name}, {response.StatusCode}");
                        return false;
                    }
                }

                sender.Viewer.isWorking = false;
                //최종 통신 결과
                if (response.IsSuccessStatusCode)
                {
                    //성공 시 True 반환
                    Console.WriteLine(sender.SuccessMessage);
                    sender.Viewer.Refresh();
                    return true;
                }
                else
                {
                    //실패 시 False 반환
                    Console.WriteLine(sender.FailMessage + ", " + response.StatusCode);
                    sender.Viewer.Refresh();
                    return false;
                }
            }
            else
            {
                sender.Viewer.isWorking = false;
                Console.WriteLine($"Error getting device status. Device: {sender.Data.Name}, {response.StatusCode}");
                return false;
            }
        }

        public class TVHealth
        {
            public eState State;
            public string Channel;
            public string ChannelName;
            public string MediaInput;
            public string MediaInputName;
            public bool Mute;
        }
        class DataSender
        {
            public TVData Data;
            public object CommandData;
            public System.Action RightAfterRequest;
            public Event SuccessCondition;
            public string SuccessMessage;
            public string FailMessage;
            public TVViewer Viewer;
        }

        public static async Task<TVHealth> GetAllInfo(TVData data, bool debug = true)
        {
            await TVControl.TVController.UpdateTV(data.DeviceID);
            //권한 설정
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);

            // get current TV status
            var response = await httpClient.GetAsync(APIPoint + $"devices/{data.DeviceID}/status");
            if (response.IsSuccessStatusCode)
            {
                var status = await response.Content.ReadAsStringAsync();

                var parsed = JObject.Parse(status);

                TVHealth helath = new TVHealth();

                var active = parsed["components"]["main"]["switch"]["switch"]["value"];
                Console.WriteLine(parsed);
                helath.Channel = parsed["components"]["main"]["tvChannel"]["tvChannel"]["value"].ToString();
                helath.ChannelName = parsed["components"]["main"]["tvChannel"]["tvChannelName"]["value"].ToString();
                helath.MediaInput = parsed["components"]["main"]["mediaInputSource"]["inputSource"]["value"].ToString();
                helath.MediaInputName = FindNowMediaInputSourceName(helath.MediaInput, parsed);
                helath.Mute = parsed["components"]["main"]["audioMute"]["mute"]["value"].ToString() == "muted" ? true : false;
                if (active.ToString() == "on")
                    helath.State = eState.On;
                else
                    helath.State = eState.Off;
                return helath;
            }
            else
            {
                if(debug)
                    Console.WriteLine($"Error getting device status. Device: {data.Name}, {response.StatusCode}");
                return null;
            }
        }
        static string FindNowMediaInputSourceName(string mediaInput, JObject parsed)
        {
            var v = parsed["components"]["main"]["samsungvd.mediaInputSource"]["supportedInputSourcesMap"]["value"];
            int index = 0;
            while (true)
            {
                try
                {
                    string str = v[index]["id"].ToString();
                    if (str == "dtv") str = "digitalTv";

                    if (str == mediaInput)
                    {
                        return v[index]["name"].ToString();
                    }
                    index++;
                }
                catch
                {
                    break;
                }
                if (index >= 100)
                    break;
            }
            return "ERROR";
        }

        public static async Task<eState> GetTVSwitch(TVData data)
        {
            var result = await GetAllInfo(data);
            return result.State;
        }
        public static async Task<string> GetTVChannel(TVData data)
        {
            var result = await GetAllInfo(data);
            return result.Channel;
        }
        public static async Task<string> GetTVMediaInput(TVData data)
        {
            var result = await GetAllInfo(data);
            return result.MediaInput;
        }
        public static async Task<bool> GetTVMute(TVData data)
        {
            var result = await GetAllInfo(data);
            return result.Mute;
        }

        public static async Task<bool> UpdateTV(string deviceID)
        {
            //HTTP로 전달할 명령 데이터 생성
            //Json에서 사용하기 위하여 commandData로 묶어서 사용합니다
            var commandData = new
            {
                commands = new[]
                {
                    new
                    {
                        component = "main",
                        capability = "refresh",
                        command = "refresh",
                        arguments = Array.Empty<string>(),
                    },
                },
            };

            var headers = new
            {
                Authorization = $"Bearer {AccessToken}",
                Content_Type = "application/json",
            };

            using (var client = new HttpClient())
            {
                //권한 설정
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", headers.Content_Type);
                //통신 시도
                var response = await client.PostAsync(APIPoint + $"devices/{deviceID}/commands",
                                                      new StringContent(JObject.FromObject(commandData).ToString(), System.Text.Encoding.UTF8, "application/json"));

                //최종 통신 결과
                if (response.IsSuccessStatusCode)
                {
                    //성공 시 True 반환
                    return true;
                }
                else
                {
                    //실패 시 False 반환
                    return false;
                }
            }
        }

    }
}
