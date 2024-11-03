using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;

/// <summary>
/// Tracert
/// </summary>
///
namespace VRK.Net {
    /// <summary>
    /// A component which provides network route tracing functionality similar to tracert.exe
    /// </summary>
    public class Tracert : Component {
        private Ping _ping;
        private List<TracertNode> _nodes;
        private bool _isDone;
        private IPAddress _destination;
        private PingOptions _options;

        /// <summary>
        /// Fires when route tracing is done
        /// </summary>
        public event EventHandler Done;

        /// <summary>
        /// Fires when a node is found in the route
        /// </summary>
        public event EventHandler<RouteNodeFoundEventArgs> RouteNodeFound;

        public Tracert() {
            _timeout = 5000; //Default timeout of Ping
        }

        private int _maxHops = 30;

        public int MaxHops {
            get => _maxHops;
            set => _maxHops = value;
        }

        /// <summary>
        /// The list of nodes in the route
        /// </summary>
        public TracertNode[] Nodes {
            get {
                lock (_nodes) {
                    return _nodes.ToArray();
                }
            }
        }

        private string _hostNameOrAddress;

        /// <summary>
        /// The host name or address of the destination node
        /// </summary>
        public string HostNameOrAddress {
            get => _hostNameOrAddress;
            set => _hostNameOrAddress = value;
        }

        private int _timeout;

        /// <summary>
        /// The maximum amount of time to wait for the Ping request to an intermediate node
        /// </summary>
        public int TimeOut {
            get => _timeout;
            set => _timeout = value;
        }

        /// <summary>
        /// Indicates whether the route tracing is complete
        /// </summary>
        public bool IsDone {
            get => _isDone;
            private set {
                _isDone = value;
                if (value && Done != null) {
                    Done(this, EventArgs.Empty);
                }
                if (_isDone) {
                    Dispose();
                }
            }
        }
        private static byte[] _buffer;
        private static byte[] Buffer {
            get {
                if (_buffer == null) {
                    _buffer = new byte[32];
                    for (int i = 0; i < Buffer.Length; i++) {
                        _buffer[i] = 0x65;
                    }
                }
                return _buffer;
            }
        }

        /// <summary>
        /// Starts the route tracing process. The HostNameOrAddress field should already be set
        /// </summary>
        public void Trace() {
            if (_ping != null) {
                throw new InvalidOperationException("This object is already in use");
            }
            _nodes = new List<TracertNode>();
            try {
                _destination = Dns.GetHostEntry(_hostNameOrAddress).AddressList[0];
            } catch (System.Net.Sockets.SocketException) {
                _destination = IPAddress.Parse(_hostNameOrAddress);
            }
            if (IPAddress.IsLoopback(_destination)) {
                ProcessNode(_destination, IPStatus.Success);
            } else {
                _ping = new Ping();
                _ping.PingCompleted += new PingCompletedEventHandler(OnPingCompleted);
                _options = new PingOptions(1, true);
                _ping.SendAsync(_destination, _timeout, Tracert.Buffer, _options, null);
            }
        }

        private void OnPingCompleted(object sender, PingCompletedEventArgs e) {
            ProcessNode(e.Reply.Address, e.Reply.Status);
            _options.Ttl += 1;  // Increment ttl until exception is not thrown
            if (!IsDone) {
                lock (this) {
                    //The expectation was that SendAsync will throw an exception
                    if (_ping == null) {
                        ProcessNode(_destination, IPStatus.Unknown);
                    } else {
                        _ping.SendAsync(_destination, _timeout, Tracert.Buffer, _options, null);
                    }
                }
            }
        }

        protected void ProcessNode(IPAddress address, IPStatus status) {
            long roundTripTime = 0;

            if (status == IPStatus.TtlExpired || status == IPStatus.Success) {
                Ping pingIntermediate = new Ping();

                try {
                    //Compute roundtrip time to the address by pinging it
                    PingReply reply = pingIntermediate.Send(address, _timeout);
                    roundTripTime = reply.RoundtripTime;
                    status = reply.Status;
                } catch (PingException e) {
                    //Do nothing
                    System.Diagnostics.Trace.WriteLine(e);
                } finally {
                    pingIntermediate.Dispose();
                }
            }

            TracertNode node = new TracertNode(address, roundTripTime, status);

            lock (_nodes) {
                _nodes.Add(node);
            }

            if (RouteNodeFound != null) {
                RouteNodeFound(this, new RouteNodeFoundEventArgs(node, IsDone));
            }

            IsDone = address.Equals(_destination);

            lock (_nodes) {
                if (!IsDone && _nodes.Count >= _maxHops - 1) {
                    ProcessNode(_destination, IPStatus.Success);
                }
            }
        }

        protected override void Dispose(bool disposing) {
            try {
                lock (this) {
                    if (_ping != null) {
                        _ping.Dispose();
                        _ping = null;
                    }
                }
            } finally {
                base.Dispose(disposing);
            }
        }
    }
}