using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProMap
{
    class DumpConnection
    {
        private static string dumpFileName = "./Dump/" + AutoDetection.BinFileName;
		
        public static string[] read(int startAddress, int streamLength)
        {
            string[] cmd = new string[streamLength];
            BinaryReader reader = new BinaryReader(File.Open(dumpFileName, FileMode.Open));
            reader.BaseStream.Seek(startAddress, SeekOrigin.Begin);

            for (int i = 0; i < streamLength; i++)
                cmd[i] = reader.ReadByte().ToString("X2");

            reader.Close();
            return cmd;
        }

        public static string lastFrame(int lastFrameAddress, int lastFrameLength)
        {
            string lastFrame = "";
            BinaryReader binReader = new BinaryReader(File.Open(dumpFileName, FileMode.Open));
            binReader.BaseStream.Seek(lastFrameAddress, SeekOrigin.Begin);

            for (int i = 0; i < lastFrameLength; i++)
                lastFrame += binReader.ReadByte().ToString("X2") + " ";

            lastFrame = lastFrame.Trim();
            binReader.Close();
            return lastFrame;
        }

        public static int startAddress()
        {
            int startAddress = 0;
            string startPattern = "42244890";

            string cmd = getAllBytes();

            startAddress = cmd.IndexOf(startPattern);
            startAddress += 8;
            startAddress /= 2;
            startAddress += 12;

            return startAddress;
        }

        public static int endAddress()
        {
            int endAddress = 0;
            string pattern = "90482442";

            string cmd = getAllBytes();

            endAddress = cmd.IndexOf(pattern);
            endAddress += 8;
            endAddress /= 2;
            endAddress += 11;

            return endAddress;
        }

        private static string getAllBytes()
        {
            byte[] allBytes = System.IO.File.ReadAllBytes(dumpFileName);
            string cmd = BitConverter.ToString(allBytes).Replace("-", "");
            return cmd;
        }
    }
}