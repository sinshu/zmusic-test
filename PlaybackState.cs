﻿using System;

/// <summary>
/// Indicates the current playback state.
/// </summary>
public enum PlaybackState
{
    /// <summary>
    /// Playback is currently stopped.
    /// </summary>
    Stopped = 1,

    /// <summary>
    /// Playback is currently ongoing.
    /// </summary>
    Playing,

    /// <summary>
    /// Playback is currently paused.
    /// </summary>
    Paused
}
