using System;
using System.Text;
using OpenTK.Audio.OpenAL;
using ZMusicInterop;

public static class Program
{
    public static unsafe void Main(string[] args)
    {
        var fileName = Encoding.UTF8.GetBytes("av_exqui.xm");

        void* song;
        SoundStreamInfo_ info;
        fixed (byte* pFileName = fileName)
        {
            song = ZMusic.ZMusic_OpenSongFile((sbyte*)pFileName, EMidiDevice_.MDEV_DEFAULT, null);
            ZMusic.ZMusic_GetStreamInfo(song, &info);
        }

        Console.WriteLine("Sample rate: " + info.mSampleRate);
        Console.WriteLine("Number of channels: " + info.mNumChannels);

        if (info.mNumChannels < 0)
        {
            throw new Exception("If mNumChannels is negative, the samples should be interpreted as 16-bit integers.");
        }

        ZMusic.ZMusic_Start(song, 0, 1);

        var device = ALC.OpenDevice(null);
        var context = ALC.CreateContext(device, (int*)null);
        ALC.MakeContextCurrent(context);
        AL.GetError();
        using (var stream = new AudioStream(info.mSampleRate, info.mNumChannels))
        {
            var data = new float[stream.ChannelCount * stream.BlockLength];

            stream.Play(buffer =>
            {
                fixed (float* p = data)
                {
                    ZMusic.ZMusic_FillStream(song, p, sizeof(float) * data.Length);
                }
                for (var i = 0; i < buffer.Length; i++)
                {
                    var sample = (short)Math.Clamp((int)(32768 * data[i]), short.MinValue, short.MaxValue);
                    buffer[i] = sample;
                }
            });

            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
        ALC.DestroyContext(context);
        ALC.CloseDevice(device);

        ZMusic.ZMusic_Close(song);
    }
}
