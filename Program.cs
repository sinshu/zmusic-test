using System;
using System.Text;
using ZMusicInterop;

public static class Program
{
    public static unsafe void Main(string[] args)
    {
        var fileName = Encoding.UTF8.GetBytes("av_exqui.xm");

        var info = new SoundStreamInfo_();

        fixed (byte* pFileName = fileName)
        {
            var song = ZMusic.ZMusic_OpenSongFile((sbyte*)pFileName, EMidiDevice_.MDEV_DEFAULT, null);
            ZMusic.ZMusic_GetStreamInfo(song, &info);
            ZMusic.ZMusic_Close(song);
        }

        Console.WriteLine(info.mSampleRate);
        Console.WriteLine(info.mNumChannels);
    }
}
