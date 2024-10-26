﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegatesConsoleApp
{

    public class VideoEventArgs : EventArgs
    {
        public required Video Video { get; set; }        
    }

    public class VideoEncoder
    {
        // 1. - Define a delegate
        // 2. - Define an event based on that delegate
        // 3. - Raise the event

        /* 
         * in .NET framework, no need to declare event handler 
         */

        //public delegate void VideoEncodedEventHandler(object sender, VideoEventArgs args);
        //public event VideoEncodedEventHandler? VideoEncoded;

        // OR

        public event EventHandler<VideoEventArgs>? VideoEncoded;

        public void Encode(Video video) 
        {
            Console.WriteLine("Encoding Video : "  );
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs() { Video = video });
        }
    }
}
