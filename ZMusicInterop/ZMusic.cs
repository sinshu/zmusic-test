using System.Runtime.InteropServices;

namespace ZMusicInterop;

public static unsafe partial class ZMusic
{
    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ZMusic_GetLastError();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_SetCallbacks([NativeTypeName("const ZMusicCallbacks *")] ZMusicCallbacks_* callbacks);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_SetGenMidi([NativeTypeName("const uint8_t *")] byte* data);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_SetWgOpn([NativeTypeName("const void *")] void* data, [NativeTypeName("unsigned int")] uint len);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_SetDmxGus([NativeTypeName("const void *")] void* data, [NativeTypeName("unsigned int")] uint len);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ZMusicConfigurationSetting *")]
    public static extern ZMusicConfigurationSetting_* ZMusic_GetConfiguration();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("EMIDIType")]
    public static extern EMIDIType_ ZMusic_IdentifyMIDIType([NativeTypeName("uint32_t *")] uint* id, int size);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ZMusic_MidiSource")]
    public static extern void* ZMusic_CreateMIDISource([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint length, [NativeTypeName("EMIDIType")] EMIDIType_ miditype);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_MIDIDumpWave([NativeTypeName("ZMusic_MidiSource")] void* source, [NativeTypeName("EMidiDevice")] EMidiDevice_ devtype, [NativeTypeName("const char *")] sbyte* devarg, [NativeTypeName("const char *")] sbyte* outname, int subsong, int samplerate);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ZMusic_MusicStream")]
    public static extern void* ZMusic_OpenSong([NativeTypeName("ZMusicCustomReader *")] ZMusicCustomReader_* reader, [NativeTypeName("EMidiDevice")] EMidiDevice_ device, [NativeTypeName("const char *")] sbyte* Args);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ZMusic_MusicStream")]
    public static extern void* ZMusic_OpenSongFile([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("EMidiDevice")] EMidiDevice_ device, [NativeTypeName("const char *")] sbyte* Args);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ZMusic_MusicStream")]
    public static extern void* ZMusic_OpenSongMem([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] nuint size, [NativeTypeName("EMidiDevice")] EMidiDevice_ device, [NativeTypeName("const char *")] sbyte* Args);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ZMusic_MusicStream")]
    public static extern void* ZMusic_OpenCDSong(int track, int cdid);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_FillStream([NativeTypeName("ZMusic_MusicStream")] void* stream, void* buff, int len);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_Start([NativeTypeName("ZMusic_MusicStream")] void* song, int subsong, [NativeTypeName("zmusic_bool")] byte loop);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Pause([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Resume([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Update([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_IsPlaying([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Stop([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Close([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_SetSubsong([NativeTypeName("ZMusic_MusicStream")] void* song, int subsong);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_IsLooping([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_IsMIDI([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_VolumeChanged([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_WriteSMF([NativeTypeName("ZMusic_MidiSource")] void* source, [NativeTypeName("const char *")] sbyte* fn, int looplimit);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_GetStreamInfo([NativeTypeName("ZMusic_MusicStream")] void* song, [NativeTypeName("SoundStreamInfo *")] SoundStreamInfo_* info);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ChangeMusicSettingInt([NativeTypeName("EIntConfigKey")] EIntConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] void* song, int value, int* pRealValue);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ChangeMusicSettingFloat([NativeTypeName("EFloatConfigKey")] EFloatConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] void* song, float value, float* pRealValue);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ChangeMusicSettingString([NativeTypeName("EStringConfigKey")] EStringConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] void* song, [NativeTypeName("const char *")] sbyte* value);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ZMusic_GetStats([NativeTypeName("ZMusic_MusicStream")] void* song);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("struct SoundDecoder *")]
    public static extern SoundDecoder* CreateDecoder([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint size, [NativeTypeName("zmusic_bool")] byte isstatic);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SoundDecoder_GetInfo([NativeTypeName("struct SoundDecoder *")] SoundDecoder* decoder, int* samplerate, [NativeTypeName("ChannelConfig *")] ChannelConfig_* chans, [NativeTypeName("SampleType *")] SampleType_* type);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint SoundDecoder_Read([NativeTypeName("struct SoundDecoder *")] SoundDecoder* decoder, void* buffer, [NativeTypeName("size_t")] nuint length);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SoundDecoder_Close([NativeTypeName("struct SoundDecoder *")] SoundDecoder* decoder);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void FindLoopTags([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint size, [NativeTypeName("uint32_t *")] uint* start, [NativeTypeName("zmusic_bool *")] byte* startass, [NativeTypeName("uint32_t *")] uint* end, [NativeTypeName("zmusic_bool *")] byte* endass);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const ZMusicMidiOutDevice *")]
    public static extern ZMusicMidiOutDevice_* ZMusic_GetMidiDevices(int* pAmount);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int ZMusic_GetADLBanks([NativeTypeName("const char *const **")] sbyte*** pNames);

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CD_Stop();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CD_Pause();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte CD_Resume();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CD_Eject();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte CD_UnEject();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CD_Close();

    [DllImport("zmusic.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte CD_Enable([NativeTypeName("const char *")] sbyte* drive);

    public static bool ChangeMusicSetting([NativeTypeName("EIntConfigKey")] EIntConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] void* song, int value, int* pRealValue = null)
    {
        return (ChangeMusicSettingInt(key, song, value, pRealValue)) != 0;
    }

    public static bool ChangeMusicSetting([NativeTypeName("EFloatConfigKey")] EFloatConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] void* song, float value, float* pRealValue = null)
    {
        return (ChangeMusicSettingFloat(key, song, value, pRealValue)) != 0;
    }

    public static bool ChangeMusicSetting([NativeTypeName("EStringConfigKey")] EStringConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] void* song, [NativeTypeName("const char *")] sbyte* value)
    {
        return (ChangeMusicSettingString(key, song, value)) != 0;
    }
}
