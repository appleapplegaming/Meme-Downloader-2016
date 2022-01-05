﻿namespace Dottik.MemeDownloader
{ 
    internal class MergeAudioAndVideo
    {
        public static void UseFFMPEG(string PathToAudio, string PathToVideo, string FinalFilePath)
        {
            Process proc = new();
            ProcessStartInfo startInfo = new();

            startInfo.FileName = "ffmpeg.exe";
            startInfo.Arguments = $" -i \"{PathToVideo}\" -i \"{PathToAudio}\" -c copy \"{FinalFilePath}.mp4\"";

            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            proc.StartInfo = startInfo;
            proc.Start();
            int pid = proc.Id;
            
            new Thread(() =>
            {
                KIllIfNotDead(pid);
            }).Start();

            proc.WaitForExit();
        }
        public static void KIllIfNotDead(int PID)
        {
            Thread.Sleep(25000);
            ProcessOptimizer.KillOrphanProcessPID(PID);
        }
    }
}
