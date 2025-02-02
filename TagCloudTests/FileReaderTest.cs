﻿using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using TagCloud.Readers;
using TextReader = TagCloud.Readers.TextReader;

namespace TagCloudTests
{
    public class FileReaderTest
    {
        private IFileReader reader;

        [SetUp]
        public void SetUp()
        {
            reader = new TextReader();
        }

        [Test]
        public void ReadFile_ShouldReturnsFailResult()
        {
           reader.ReadFile("abc").Error.Should().Be("File abc not found." +
                                                    " Please check that file exists");
        }

        [Test]
        public void ReadFile_ShouldRead()
        {
            var fileInfo = new FileInfo(Environment.CurrentDirectory + "\\test.txt");
            using (var writer = fileInfo.CreateText())
                writer.Write("test\ntext");
            
            var lines = reader.ReadFile(Environment.CurrentDirectory + "\\test.txt");

            fileInfo.Delete();
            lines.GetValueOrThrow().Should().Contain("test").And.Contain("text");
        }
    }
}
