using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProMap
{
    // This Class Is Created For Reading Download Data From .bin Files In The Dump Folder
    // And Save The Commands In Variables
    class DumpConnection
    {
        // This Method Reads All The Command From The .bin File And 
        // Returns All The Command Frames With The Length 0xF0 Except The Last One
        // Which Is Shorter Than 0xF0
        public static string[] Read(int Add_Start, int Stream_Leng)
        {
            string[] cmd = new string[Stream_Leng];
            string DumpFileName = "./Dump/" + AutoDetection.BinFileName;
            BinaryReader binReader = new BinaryReader(File.Open(DumpFileName, FileMode.Open));
            binReader.BaseStream.Seek(Add_Start, SeekOrigin.Begin); // Jump To The Start Address

            // Read Bytes From .bin File And Save Into Cmd Variable As Hex String
            for (int i = 0; i < Stream_Leng; i++)
                cmd[i] = binReader.ReadByte().ToString("X2");

            binReader.Close();
            return cmd; // cmd Is A Long Command Read From .bin File
        }

        // It Returns The Last Fame Of The Command With The Length Shorter Than 0xF0
        public static string Last_Frame(int Last_Add, int Last_Leng)
        {
            string last_cmd = "";
            string DumpFileName = "./Dump/" + AutoDetection.BinFileName;
            BinaryReader binReader = new BinaryReader(File.Open(DumpFileName, FileMode.Open));
            binReader.BaseStream.Seek(Last_Add, SeekOrigin.Begin); // Jump To The Start Address

            // Read Bytes From .bin File And Save Into Cmd Variable As Hex String
            for (int i = 0; i < Last_Leng; i++)
                last_cmd += binReader.ReadByte().ToString("X2") + " ";

            last_cmd = last_cmd.Trim();
            binReader.Close();
            return last_cmd;
        }

        // It Returns The Start Address Of The Command Of The 1st Zone As Aan Integer
        public static int Start_Address()
        {
            int Start_Address = 0;

            string DumpFileName = "./Dump/" + AutoDetection.BinFileName;

            byte[] allBytes = System.IO.File.ReadAllBytes(DumpFileName);
            string cmd = BitConverter.ToString(allBytes).Replace("-", "");
            string pattern = "42244890";

            Start_Address = cmd.IndexOf(pattern);
            Start_Address += 8;
            Start_Address /= 2;

            return Start_Address + 12;
        }

        // It Returns The End Address Of The Command Of The 1st Zone As An Integer
        public static int End_Address()
        {
            int End_Address = 0;

            string DumpFileName = "./Dump/" + AutoDetection.BinFileName;

            byte[] allBytes = System.IO.File.ReadAllBytes(DumpFileName);
            string cmd = BitConverter.ToString(allBytes).Replace("-", "");
            string pattern = "90482442";

            End_Address = cmd.IndexOf(pattern);
            End_Address += 8;
            End_Address /= 2;

            return End_Address + 11;
        }
    }
}