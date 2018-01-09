﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Startup
{
    public class SomethingReadyNotifier
    {
        private readonly SynchronizationContext synchronizationContext;

        public startup_step Startup_Step = null;
        /// <summary>
        /// Create a new <see cref="SomethingReadyNotifier"/> instance. 
        /// </summary>
        /// <param name="synchronizationContext">
        /// The synchronization context that will be used to raise
        /// <see cref="SomethingReady"/> events.
        /// </param>
        public SomethingReadyNotifier(SynchronizationContext synchronizationContext, startup_step xStartup_Step)
        {
            this.synchronizationContext = synchronizationContext;
            Startup_Step = xStartup_Step;
        }

        /// <summary>
        /// Event raised when something is ready. The event is always raised
        /// by posting on the synchronization context provided to the constructor.
        /// </summary>
        public event EventHandler SomethingReady;

        private void OnSomethingReady()
        {
            SomethingReady?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Causes the SomethingReady event to be raised.
        /// </summary>
        /// <remarks>
        /// Can safely be called from any thread. Always returns immediately without
        /// waiting for the event to be handled.
        /// </remarks>
        public void NotifySomethingReady()
        {
            this.synchronizationContext.Post(
                    state => OnSomethingReady(),
                    state: null);
        }
    }
}
