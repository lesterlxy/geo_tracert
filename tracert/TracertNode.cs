using System.Net;
using System.Net.NetworkInformation;

namespace VRK.Net {
    /// <summary>
    /// Contains data about a node encountered using Tracert
    /// </summary>
    public class TracertNode {
        /// <summary>
        /// Constructs a new object from the IPAddress of the node and the round trip time taken
        /// </summary>
        /// <param name="address"></param>
        /// <param name="roundTripTime"></param>
        internal TracertNode(IPAddress address, long roundTripTime, IPStatus status) {
            _address = address;
            _roundTripTime = roundTripTime;
            _status = status;
        }

        private readonly IPAddress _address;

        /// <summary>
        /// The IPAddress of the node
        /// </summary>
        public IPAddress Address => _address;

        private readonly long _roundTripTime;

        /// <summary>
        /// The time taken to go to the node and come back to the originating node in milliseconds.
        /// </summary>
        public long RoundTripTime => _roundTripTime;

        private readonly IPStatus _status;

        /// <summary>
        /// The IPStatus of request send to the node
        /// </summary>
        public IPStatus Status => _status;
    }
}
