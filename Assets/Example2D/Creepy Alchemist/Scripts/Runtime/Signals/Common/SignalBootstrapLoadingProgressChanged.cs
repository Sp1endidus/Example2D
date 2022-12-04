namespace Example2D.CreepyAlchemist.Runtime.Signals.Common {
    public readonly struct SignalBootstrapLoadingProgressChanged {
        public readonly float Progress;

        public SignalBootstrapLoadingProgressChanged(float progress) {
            Progress = progress;
        }
    }
}