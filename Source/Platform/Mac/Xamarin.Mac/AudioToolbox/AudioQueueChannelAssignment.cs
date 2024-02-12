using System;
using CoreFoundation;

namespace AudioToolbox;

public struct AudioQueueChannelAssignment
{
	private readonly IntPtr deviceUID;

	private readonly uint channelNumber;

	public AudioQueueChannelAssignment(CFString deviceUID, uint channelNumber)
	{
		this.deviceUID = deviceUID.Handle;
		this.channelNumber = channelNumber;
	}
}
