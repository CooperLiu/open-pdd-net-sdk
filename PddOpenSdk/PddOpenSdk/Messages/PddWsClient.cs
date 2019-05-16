using System;
using PddOpenSdk.Common;
using WebSocket4Net;

namespace PddOpenSdk.Messages
{
    public class PddWsClient
    {
        public const string DEFAULT_WS_ADDRESS = "wss://message-api.pinduoduo.com";

        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _wsUrl;

        public event EventHandler<OnMessageEventArgs> OnMessage;

        private WebSocketChannel _socketChannel;

        public PddWsClient(string clientId, string clientSecret, string wsUrl = null)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _wsUrl = wsUrl ?? DEFAULT_WS_ADDRESS;
        }

        public void Connect()
        {
            _socketChannel = new WebSocketChannel(CreateWsConnection());
        }

        private WebSocket CreateWsConnection()
        {
            var systemTime = DateTime.Now.ToUnixTimeStampMillis();
            var sign = $"{_clientId}{systemTime}{_clientSecret}".Md5().Base64Encode();
            var url = $"{_wsUrl}/message/{_clientId}/{systemTime}/{systemTime}/{sign}";

            var ws = new WebSocket(url);
            ws.AutoSendPingInterval = 10 * 1000;
            ws.EnableAutoSendPing = true;

            ws.MessageReceived += (sender, e) =>
            {
                var message = e.Message;
                OnMessage?.Invoke(sender, new OnMessageEventArgs() { Message = message });
            };

            ws.Open();
            return ws;
        }


        public void Close()
        {
            _socketChannel.Close();
        }

    }

    internal class WebSocketChannel
    {
        private readonly WebSocket _socket;

        public bool IsConnected => _socket.State == WebSocketState.Open;

        public WebSocketChannel(WebSocket socket)
        {
            _socket = socket;
        }

        public void Send(string message)
        {
            _socket.Send(message);
        }

        public void Close()
        {
            _socket.Close();
        }

    }

    public class OnMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}