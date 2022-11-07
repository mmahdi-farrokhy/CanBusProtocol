using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace ProMap
{    
    class CanECUs
    {
        public const string CanBudrate_3B = "06 04 13";//CanBaudrate_500k_B

		// Initialize the IC for starting the connection procedure
        public static bool CAN_IC_Init(string Header_2B, string Mask_2B)
        {
            int M_1 = 0x10;
            int M_2 = 0x20;
            int M_3 = 0x30;

            Connections.SendCommand("1E F1 01 01 65 14 EE C4 E4 B5 94 E4 A6 65 65 65 65 65 65 65 65 65 65 65 0E", 100);

            bool Logi = CAN_Init();
            if (Logi)
            {
                Logi = CAN_Init_MOB(M_1, Header_2B, Mask_2B);
                if (Logi)
                {
                    Logi = CAN_Init_MOB(M_2, Header_2B, Mask_2B);
                    if (Logi)
                        Logi = CAN_Init_MOB(M_3, Header_2B, Mask_2B);
                }
            }

            Connections.clearBuffer();
          

            return Logi;
        }
               
		// Initialize the IC for CAN protocol
        public static bool CAN_Init()
        {
            string InitMsg;
            bool result;

            InitMsg = AutoDetection.AddSumCheck("1B 00 80 00 0E 00 00 00 00 00 00 00 00 00 00 00 00 11 00 00 00 00 00 00 00 00 " + CanBudrate_3B);
            Connections.SendCommand(InitMsg, 100);

            if (Connections.ReadNbyte().Contains("60"))
                result = true;
            else
                result = false;

            return result;
        }
		
		// Initialize the IC for CAN send and receive
        public static bool CAN_Init_MOB(int MOB, string Header_2B, string Mask_2B)
        {
            string InitMsg;

            InitMsg = AutoDetection.AddSumCheck("1B 00 20 00 0E 00 00 " + Header_2B.Substring(0, 4) + "8" + " 00 00 00 00 00 00 00 00 4" + ((MOB / 0x10)).ToString("X1") + " FF FF " + Mask_2B + " 00 00 00 00 00 00 00");
            bool result = Connections.SendCommand(InitMsg, 100);

            return result;
            System.Threading.Thread.Sleep(100);
        }

        // Send standard CAN Data Commands
        public static bool CAN_Send(string Header_2B, string Command_8B)
        {
            Command_8B = Command_8B.Trim();
            int Command_Count = ((Command_8B.Length + 1) / 3);
            string InitMsg;
            bool result = false;

            if (Command_8B == "")
                result = false;

            InitMsg = AutoDetection.AddSumCheck("1B 00 2" + Command_Count + " 00 0E 00 00 " + Header_2B + " " + Command_8B + " 20 00 00 00 00 00 00 00 00 00 00 00");
            result = Connections.SendCommand(InitMsg, 1);//100

            return result;            
        }       
        
        // Send CAN Data Commands Longer Than 8 Bytes
        public static bool CAN_Regular_Send(string Header2B, string Body)
        {
            int NumOfBytes = ((Body.Length + 1) / 3) - 1;
            string cmd = "";
            int MsgCount;
            int GivenSize = int.Parse(Body.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            bool result = false;
            int ctr = 0;

            if (Body == "")
                result = false;

            if (NumOfBytes < GivenSize)
            {
                Message.messageBox_Show_Ok("xs", "!Size Byte Is Larger Than Real Size");
                result = false;
            }
            else if (NumOfBytes > GivenSize)
            {
                Message.messageBox_Show_Ok("xs", "!Size Byte Is Smaller Than Real Size");
                result = false;
            }
            else
            {
                if (NumOfBytes < 8)
                {
                    cmd = (Body + " 00 00 00 00 00 00 00 00").Substring(0, 23);
                    CAN_Send(Header2B, cmd);
                }
                else
                {
                    if ((NumOfBytes + 1) % 7 == 0)
                        MsgCount = (NumOfBytes + 1) / 7;
                    else
                        MsgCount = ((NumOfBytes + 1) / 7) + 1;

                    string[] MsgArr = new string[MsgCount];
                    int NumOfRows = 0x1000 + NumOfBytes;

                    MsgArr[0] = NumOfRows.ToString("X2").Substring(0, 2) + " " + NumOfRows.ToString("X2").Substring(2, 2) + " " + Body.Substring( 3, 17);
                    for (int i = 1; i < MsgCount ; i++)
                    {
                        if (i % 16 == 0)
                            ctr++;
                        MsgArr[i] = "2" + (i - (16 * ctr)).ToString("X1") + " " + (Body + " 00 00 00 00 00 00 00 00").Substring(i * 21, 20);
                    }

                    for (int i=0; i<MsgCount; i++)
                        CAN_Send(Header2B, MsgArr[i]);
                }
                result = true;
            }
            return result;
        }

        //This Function Reads The Data From The Buffer And Extracts
        //The Header And The Body Of ECUs Response And Creates An Standard Command        
        public static bool CAN_GetData(ref string ECUCommand)
        {
            string Data = "";
            string Header = "";
            string Frame = "";
            string SizeByte = "";
            string Body = "";
            string tmp_Body = "";
            int Header_Index = 0;
            int SizeByte_Index = 0;
            int Body_Index = 0;
            int SizeOfCommand = 0; // Number Of Body Bytes
            int Body_Length = 0; //Length of body without Size Byte
            int MsgCount = 0;
            bool result = false;

            Connections.ReadMsg(ref Data, ref Frame);

            if (Data.Substring(0, 5) == "07 E8")
            {
                Header_Index = 0;
                Header = Data.Substring(Header_Index, 5);
                // Header Is Created
                SizeByte_Index = 6;
                SizeByte = Data.Substring(SizeByte_Index, 2);
                if (SizeByte == "30")
                    SizeOfCommand = 8;
                else
                    SizeOfCommand = int.Parse(SizeByte, System.Globalization.NumberStyles.HexNumber);
                // Size Byte Is Created
                Body_Index = 9;
                if (SizeByte == "30")
                    Body_Index = 6;
                Body_Length = Data.Length - Body_Index;
                tmp_Body = Data.Substring(Body_Index, Body_Length);
                // Temporary Body Is Created
            }

            if ((SizeOfCommand + 1) % 7 == 0)
                MsgCount = (SizeOfCommand + 1) / 7;
            else
                MsgCount = ((SizeOfCommand + 1) / 7) + 1;

            if (SizeOfCommand < 8)          
                Body = tmp_Body;
            else
            {
                // Remove The Initial And Header Bytes From Temporary Body
                tmp_Body = tmp_Body.Replace("60 6D 11 07 E8 08 ", "");
                tmp_Body = tmp_Body.Replace("6D 11 07 E8 08 ", "");

                // Remove The Frame Counters From Temporary Body
                tmp_Body = tmp_Body.Replace(tmp_Body.Substring(18, 3), "NNN"); // "21 " --> "NNN"
                if(MsgCount > 2)
                    for (int i = 3; i <= MsgCount; i++)
                        tmp_Body = tmp_Body.Replace(tmp_Body.Substring((i*24)-30, 3), "NNN"); // Replace 21, 22, 23 , ... With NNN

                tmp_Body = tmp_Body.Replace("NNN", ""); // Remove NNN From The Temporary Body
            }

            // Remove The "55" From The End Of Body
            if (tmp_Body.Length > (SizeOfCommand * 3) - 1)
                tmp_Body = tmp_Body.Substring(0, (SizeOfCommand * 3) - 1);

            tmp_Body = tmp_Body.Trim();
            Body = tmp_Body;

            ECUCommand = Header + " " + SizeByte + " " + Body;

            if (ECUCommand == "")
                result = false;
            else
                result = true;

            return result;
        }
		
		// Takes The SoftRef Extracted From ECU's Response Command And Turns It Into String Of Characters
        public static string Can_SR_Normalize(string SR)
        {
            string SoftRef = "";
            int[] dec = new int[10];
            char[] chars = new char[10];

            for (int i = 0; i < 10; i++)
                SoftRef += System.Convert.ToChar(Str2Hex(SR.Substring(i * 3, 2).ToString())).ToString();

            return SoftRef;
        }

		// Takes The BootRef Extracted From ECU's Response Command And Turns It Into String Of Characters
        public static string Can_BR_Normalize(string BR)
        {
            string Result = "";
            int[] dec = new int[10];
            char[] chars = new char[10];

            for (int i = 0; i < 10; i++)
                Result += System.Convert.ToChar(Str2Hex(BR.Substring(i * 3, 2).ToString())).ToString();

            return Result;
        }
        
		// Takes The Calibration Extracted From ECU's Response Command And Turns It Into String Of Characters
        public static string Can_CA_Normalize(string CA)
        {
            string Result = "";
            int[] dec = new int[10];
            char[] chars = new char[10];

            for (int i = 0; i < 10; i++)
                Result += System.Convert.ToChar(Str2Hex(CA.Substring(i * 3, 2).ToString())).ToString();

            return Result;
        }

		// Converts String Of 2 Characters (1 Hexadecimal Byte) Into A Character
        static public int Str2Hex(string Byte)
        {
            int Result = 0;
            char B1 = Byte[0];
            char B0 = Byte[1];
            int mult1 = 0;
            int mult0 = 0;

            switch (B0)
            {
                case '0':
                    mult0 = 0;
                    break;

                case '1':
                    mult0 = 1;
                    break;

                case '2':
                    mult0 = 2;
                    break;

                case '3':
                    mult0 = 3;
                    break;

                case '4':
                    mult0 = 4;
                    break;

                case '5':
                    mult0 = 5;
                    break;

                case '6':
                    mult0 = 6;
                    break;

                case '7':
                    mult0 = 7;
                    break;

                case '8':
                    mult0 = 8;
                    break;

                case '9':
                    mult0 = 9;
                    break;

                case 'A':
                    mult0 = 10;
                    break;

                case 'B':
                    mult0 = 11;
                    break;

                case 'C':
                    mult0 = 12;
                    break;

                case 'D':
                    mult0 = 13;
                    break;

                case 'E':
                    mult0 = 14;
                    break;

                case 'F':
                    mult0 = 15;
                    break;
            }

            switch (B1)
            {
                case '0':
                    mult1 = 0;
                    break;

                case '1':
                    mult1 = 1;
                    break;

                case '2':
                    mult1 = 2;
                    break;

                case '3':
                    mult1 = 3;
                    break;

                case '4':
                    mult1 = 4;
                    break;

                case '5':
                    mult1 = 5;
                    break;

                case '6':
                    mult1 = 6;
                    break;

                case '7':
                    mult1 = 7;
                    break;

                case '8':
                    mult1 = 8;
                    break;

                case '9':
                    mult1 = 9;
                    break;

                case 'A':
                    mult1 = 10;
                    break;

                case 'B':
                    mult1 = 11;
                    break;

                case 'C':
                    mult1 = 12;
                    break;

                case 'D':
                    mult1 = 13;
                    break;

                case 'E':
                    mult1 = 14;
                    break;

                case 'F':
                    mult1 = 15;
                    break;
            }

            Result = (mult1 * 16) + mult0;

            return Result;
        }
    }
}