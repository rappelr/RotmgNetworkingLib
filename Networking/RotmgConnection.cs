using RotmgNetworkingLib.Messaging;
using RotmgNetworkingLib.Messaging.Incoming;
using RotmgNetworkingLib.Models;
using System;

namespace RotmgNetworkingLib.Networking
{
    public class RotmgConnection
    {
        public readonly RotmgSocket Socket;

        public Server TargetServer, CurrentServer;

        public bool PrintPackets;

        public event OnConnect OnConnect = delegate { };
        public event OnDisconnect OnDisconnect = delegate { };

        public event OnRecievePacket OnRecievePacket = delegate { };
        public event OnEmitPacket OnEmitPacket = delegate { };

        public event OnRecievePacket<NewTick> OnNewTick = delegate { };
        public event OnRecievePacket<BuyResult> OnBuyResult = delegate { };
        public event OnRecievePacket<CreateSuccess> OnCreateSuccess = delegate { };
        public event OnRecievePacket<EnemyShoot> OnEnemyShoot = delegate { };
        public event OnRecievePacket<Failure> OnFailure = delegate { };
        public event OnRecievePacket<Goto> OnGoto = delegate { };
        public event OnRecievePacket<InvitedToGuild> OnInvitedToGuild = delegate { };
        public event OnRecievePacket<InvResult> OnInvResult = delegate { };
        public event OnRecievePacket<MapInfo> OnMapInfo = delegate { };
        public event OnRecievePacket<Ping> OnPing = delegate { };
        public event OnRecievePacket<QuestRedeemResponse> OnQuestRedeemResponse = delegate { };
        public event OnRecievePacket<Reconnect> OnReconnect = delegate { };
        public event OnRecievePacket<Text> OnText = delegate { };
        public event OnRecievePacket<TradeAccepted> OnTradeAccepted = delegate { };
        public event OnRecievePacket<TradeDone> OnTradeDone = delegate { };
        public event OnRecievePacket<TradeRequested> OnTradeRequested = delegate { };
        public event OnRecievePacket<TradeStart> OnTradeStart = delegate { };
        public event OnRecievePacket<Update> OnUpdate = delegate { };
        public event OnRecievePacket<VaultContent> OnVaultUpdate = delegate { };

        public bool Connected => Socket.Connected;

        public RotmgConnection()
        {
            Socket = new RotmgSocket(new SocketListener(this));
            PrintPackets = false;
            TargetServer = null;
            CurrentServer = null;
        }

        public void Emit(OutgoingPacket packet)
        {
            if (packet is null)
                throw new ArgumentNullException(nameof(packet));


            bool cancel = false;

            try
            {
                OnEmitPacket.Invoke(packet, ref cancel);
            }
            catch
            {
                cancel = false;
            }

            if (cancel)
            {
                if (PrintPackets)
                    Console.WriteLine("OUT> " + packet.GetType().Name + " CANCELLED");
                return;
            }

            if (PrintPackets)
                Console.WriteLine("OUT> " + packet.GetType().Name);


            Socket.WritePacket(packet);
        }

        public void Connect(Server server)
        {
            TargetServer = server;
            Connect();
        }

        public virtual void Connect(bool ignoreState = true)
        {
            if (TargetServer is null)
                throw new RotmgNetworkingException("Failed to connect: given target server is null");

            if (Connected)
            {
                if (ignoreState)
                    return;
                throw new InvalidOperationException("RotmgConnection already connected");
            }

            Socket.Connect(TargetServer.DNS);
        }

        public virtual void Disconnect(bool ignoreState = true)
        {
            if (!Connected)
            {
                if (ignoreState)
                    return;

                throw new InvalidOperationException("ServerConnection not connected");
            }
            else
                Socket.Close();
        }

        private class SocketListener : ISocketListener
        {
            private readonly RotmgConnection _connection;

            internal SocketListener(RotmgConnection connection)
            {
                _connection = connection;
            }


            public void OnSocketConnect()
            {
                _connection.CurrentServer = _connection.TargetServer;

                try
                {
                    _connection.OnConnect.Invoke();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            public void OnSocketDisconnect()
            {
                _connection.CurrentServer = null;

                try
                {
                    _connection.OnDisconnect.Invoke();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            public void OnSocketReadPacket(IncomingPacket packet)
            {
                if (packet is null)
                    return;

                bool cancel = false;

                try
                {
                    _connection.OnRecievePacket.Invoke(packet, ref cancel);
                }
                catch
                {
                    cancel = false;
                }

                if (cancel)
                {
                    if (_connection.PrintPackets)
                        Console.WriteLine("IN<< " + packet.GetType().Name + " CANCELLED");
                    return;
                }

                if (_connection.PrintPackets)
                    Console.WriteLine("IN<< " + packet.GetType().Name);

                try
                {
                    switch (packet)
                    {
                        case NewTick newTick:
                            _connection.OnNewTick.Invoke(newTick);
                            break;
                        case BuyResult buyResult:
                            _connection.OnBuyResult.Invoke(buyResult);
                            break;
                        case CreateSuccess createSuccess:
                            _connection.OnCreateSuccess.Invoke(createSuccess);
                            break;
                        case EnemyShoot enemyShoot:
                            _connection.OnEnemyShoot.Invoke(enemyShoot);
                            break;
                        case Failure failure:
                            _connection.OnFailure.Invoke(failure);
                            break;
                        case Goto gotoPacket:
                            _connection.OnGoto.Invoke(gotoPacket);
                            break;
                        case InvitedToGuild invitedToGuild:
                            _connection.OnInvitedToGuild.Invoke(invitedToGuild);
                            break;
                        case InvResult invResult:
                            _connection.OnInvResult.Invoke(invResult);
                            break;
                        case MapInfo mapInfo:
                            _connection.OnMapInfo.Invoke(mapInfo);
                            break;
                        case Ping ping:
                            _connection.OnPing.Invoke(ping);
                            break;
                        case QuestRedeemResponse questRedeemResponse:
                            _connection.OnQuestRedeemResponse.Invoke(questRedeemResponse);
                            break;
                        case Reconnect reconnect:
                            _connection.OnReconnect.Invoke(reconnect);
                            break;
                        case Text text:
                            _connection.OnText.Invoke(text);
                            break;
                        case TradeAccepted tradeAccepted:
                            _connection.OnTradeAccepted.Invoke(tradeAccepted);
                            break;
                        case TradeDone tradeDone:
                            _connection.OnTradeDone.Invoke(tradeDone);
                            break;
                        case TradeRequested tradeRequested:
                            _connection.OnTradeRequested.Invoke(tradeRequested);
                            break;
                        case TradeStart tradeStart:
                            _connection.OnTradeStart.Invoke(tradeStart);
                            break;
                        case Update update:
                            _connection.OnUpdate.Invoke(update);
                            break;
                        case VaultContent vaultUpdate:
                            _connection.OnVaultUpdate.Invoke(vaultUpdate);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

    public delegate void OnConnect();

    public delegate void OnDisconnect();

    public delegate void OnRecievePacket(IncomingPacket packet, ref bool cancel);

    public delegate void OnEmitPacket(OutgoingPacket packet, ref bool cancel);

    public delegate void OnRecievePacket<T>(T packet) where T : IncomingPacket;
}
