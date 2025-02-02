﻿using TagCloud.ResultMonad;

namespace TagCloud.Readers
{
    public interface IFileReader
    {
        Result<string[]> ReadFile(string filename);
    }
}
