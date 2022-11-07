using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProMap
{
    {
        public static int ProcBarVal = 0;
        public static int Frame_Len = 0xF0;
        private static string SoftRef = "";
        private static int Start_Address1 = 0;
        private static int End_Address1 = 0;
        private static int cmd_Length1 = 0;
        private static int Start_Address2 = 0;
        private static int cmd_Length2 = 0;

		
        public static bool Crouse_EasyU25()
        {
            ProcBarVal = 0;
            string resp = "";

            // Zone 1 Variables
            Start_Address1 = DumpConnection.Start_Address();            // Start Address Of Zone 1
            End_Address1 = DumpConnection.End_Address();                // Start Address Of Zone 1
            cmd_Length1 = Start_Address1 - End_Address1;                // Length Of Zone 1

            int NumOfFrames1 = cmd_Length1 / Frame_Len;             	// Number Of Commands Of Zone 1 With The Lenght F1
            int rest1 = cmd_Length1 % Frame_Len;                    	// Length Of The Last Frame
            int last_add1 = End_Address1 - rest1 + 1;   				// Start Address Of The Last Frame

            string[] cmd1 = new string[cmd_Length1];
            string[] Frames1 = new string[NumOfFrames1];
            string[] Final_cmd1 = new string[NumOfFrames1 + 1];

            // Zone 2 Variables
            Start_Address2 = 0x20000;                               	// Start Address Of Zone 1
            cmd_Length2 = 0x20000;                                  	// Length Of Zone 1

            int NumOfFrames2 = cmd_Length2 / Frame_Len;             	// Number Of Commands Of Zone 1 With The Lenght F1
            int rest2 = cmd_Length1 % Frame_Len;                    	// Length Of The Last Frame
            int last_add2 = Start_Address2 + cmd_Length2 - rest2;   	// Start Address Of The Last Frame

            string[] cmd2 = new string[cmd_Length2];
            string[] Frames2 = new string[NumOfFrames2];
            string[] Final_cmd2 = new string[NumOfFrames2 + 1];


            // Progress Bar Variables
            double ProgBarRatio1 = (double)(NumOfFrames1) / (double)(NumOfFrames1 + NumOfFrames2); // Nesbate Zone 1 Az Progress Bar
            double ProgBarRatio2 = 1 - ProgBarRatio1; // Nesbate Zone 2 Az Progress Bar

            Logger.Write(" ");
            Logger.Write("** Download to ECU");
            Logger.Write("** ECU ID:  " + AutoDetection.SpecificationID);
            Logger.Write("** soft ref:  " + AutoDetection.Softref);
            Logger.Write("** boot ref:  " + AutoDetection.Bootref);
            Logger.Write("** calibration:  " + AutoDetection.Calibref);
            Logger.Write(" ");

            // Initialize Board
            CanECUs.CAN_IC_Init("07 E0", "FF FF");
            Thread.Sleep(100);

            // Send Commands
            // 02 10 81 - Connetion
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 10 81");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 21 91 - SoftRef
                CanECUs.CAN_Regular_Send("07 E0", "02 21 91");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
                if (resp.Substring(12, 2) == "7F" || resp == "")
                {
                    Message.messageBox_Show_Ok("xs", "ای سی یو شناسایی نشد");
                    return false;
                }
            SoftRef = CanECUs.Can_SR_Normalize(resp);

            // 02 21 81
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 21 81");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");           

            // 02 10 85
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 10 85");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");          

            // 02 10 85
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 10 85");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 21 91 - SoftRef
                CanECUs.CAN_Regular_Send("07 E0", "02 21 91");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            if (resp.Substring(12, 2) == "7F")
            {
                Message.messageBox_Show_Ok("xs", "ای سی یو شناسایی نشد");
                return false;
            }

            // 02 21 81
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 10 81");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 10 85
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 10 85");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 3E 00
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 3E 00");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 3E 00
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 3E 00");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 3E 00
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 3E 00");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 02 27 01
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 27 01");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(9, 2) == "7F");

            // 06 27 02 35 01 A4 D1
            CanECUs.CAN_Regular_Send("07 E0", "06 27 02 35 01 A4 D1");
            Thread.Sleep(50);
            CanECUs.CAN_GetData(ref resp);
            if (resp.Substring(9, 2) == "7F")
            {
                Message.messageBox_Show_Ok("xs", "پاکسازی ای سی یو با خطا مواجه شد");
                return false;
            }

            // 02 31 01
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "02 31 01");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            // 08 34 04 00 00 00 0C 00 00
            do
            {
                CanECUs.CAN_Regular_Send("07 E0", "08 34 04 00 00 00 0C 00 00");
                Thread.Sleep(50);
                CanECUs.CAN_GetData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            frm_Main._FrmMainObj.UpdateMessage("شروع ناحیه اول");
            cmd1 = DumpConnection.Read(Start_Address1, cmd_Length1); // Read Full Command Of Zone 1

            // Divide Command To Frames With The Length 0xF0
            for (int i = 0; i < NumOfFrames1; i++)
                for (int j = 0; j < Frame_Len; j++)
                    Frames1[i] += cmd1[j + i * Frame_Len] + " ";

            // Add F1 36 To The Beginning Of The Frames
            for (int i = 0; i < NumOfFrames1; i++)
            {
                Final_cmd1[i] = "F1 36 " + Frames1[i];
                Final_cmd1[i] = Final_cmd1[i].Trim();
            }

            // Create The Last Frame Of Command
            string last_frame = DumpConnection.Last_Frame(last_add1, rest1);
            Final_cmd1[NumOfFrames1] = (rest1 + 1).ToString("X2") + " 36 " + last_frame;

            for (int i = 0; i < NumOfFrames1 + 1; i++)
            {
                CanECUs.CAN_Regular_Send("07 E0", Final_cmd1[i]);
                Thread.Sleep(15);
                CanECUs.CAN_GetData(ref resp);
                UpdateProgressBar(NumOfFrames1, i, ProgBarRatio1);


                if (resp.Trim() == "" || resp.Substring(12, 2) == "7F" || resp.Substring(9, 5) != "01 76")
                {
                    Message.messageBox_Show_Ok("xs", "دانلود با خطا مواجه شد");
                    return false;
                }
            }

            frm_Main._FrmMainObj.UpdateMessage("شروع ناحیه دوم");
            cmd2 = DumpConnection.Read(Start_Address2, cmd_Length2); // Read Full Command Of Zone 2

            // Divide Command To Frames With The Length 0xF0
            for (int i = 0; i < NumOfFrames2; i++)
                for (int j = 0; j < Frame_Len; j++)
                    Frames2[i] += cmd2[j + i * Frame_Len] + " ";

            // Add F1 36 To The Beginning Of The Frames
            for (int i = 0; i < NumOfFrames2; i++)
                Final_cmd2[i] = "F1 36 " + Frames2[i].Trim();

            // Create The Last Frame Of Command
            Final_cmd2[NumOfFrames2] = (rest2+1).ToString("X2") + " 36 " + DumpConnection.Last_Frame(last_add2, rest2);
            for (int i = 0; i < NumOfFrames2 + 1; i++)
            {
                CanECUs.CAN_Regular_Send("07 E0", Final_cmd2[i]);
                Thread.Sleep(15);
                CanECUs.CAN_GetData(ref resp);
                UpdateProgressBar(NumOfFrames2, i, ProgBarRatio2);


                if (resp.Trim() == "" || resp.Substring(12, 2) == "7F" || resp.Substring(9, 5) != "01 76")
                {
                    Message.messageBox_Show_Ok("xs", "دانلود با خطا مواجه شد");
                    return false;
                }
            }

            frm_Main._FrmMainObj.UpdateMessage("پایان دانلود");
            return true;
        }

        public static void UpdateProgressBar(int TotalNumber, int counter, double Ratio)
        {
            double progbar_value = (counter * 100) / TotalNumber;
            ProcBarVal = (int)(progbar_value * Ratio);
            frm_Main._FrmMainObj.ProgressBar_Set(ProcBarVal);
        }

    }
}