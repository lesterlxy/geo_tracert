using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace VRK.Net
{
    /// <summary>
    /// Provides data for the RouteCompleted event of Tracert
    /// </summary>
    public class RouteNodeFoundEventArgs : EventArgs
    {
        protected internal RouteNodeFoundEventArgs(TracertNode node, bool isDone)
        {
            this._node = node;
            this._isLastNode = isDone;
        }

        private bool _isLastNode;

        /// <summary>
        /// Indicates whether the value of the Node propert is the last node
        /// found by Tracert
        /// </summary>
        public bool IsLastNode
        {
            get { return _isLastNode; }
        }

        private TracertNode _node;

        /// <summary>
        /// A node encountered during the route tracing.
        /// </summary>
        public TracertNode Node
        {
            get { return _node; }
        }
    }
}
