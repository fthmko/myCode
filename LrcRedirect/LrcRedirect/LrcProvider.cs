using System;
using System.Collections.Generic;
using System.Text;

namespace LrcRedirect
{
    public interface LrcProvider
    {
        String Str { get; }
        void Search(String song, String artist, List<String> result);
        String Download(String path);
    }
}
