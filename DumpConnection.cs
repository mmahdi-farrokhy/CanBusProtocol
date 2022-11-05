using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProMap
{
    // This class is created for resding download data from .bin files in the Dump folder
    // and save the commands in variables
    class DumpConnection
    {
        // This method reads all the command from the .bin file and 
        // returns all the command frames with the length 0xF0 except the last one
        // which is shorter than 0xF0
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
            return cmd; // cmd is a long command read from .bin file
        }

        // It returns the last frame of the command with the length shorter than 0xF0
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

        // It returns the start address of the command of the 1st zone as an integer
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

        // It returns the end address of the command of the 1st zone as an integer
        public static int End_Address()
        {
            int End_Address = 0;

            string DumpFileName = "./Dump/" + AutoDetection.BinFileName;
            //BinaryReader binReader = new BinaryReader(File.Open(DumpFileName, FileMode.Open));

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