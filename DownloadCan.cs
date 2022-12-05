using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProMap
{
    class DownloadCan
    {
        public static int procBarVal = 0;
        public const int FRAME_LEN = 0xF0;
        private static string softRef = "";
        private static int startAddress1 = 0;
        private static int endAddress1 = 0;
        private static int cmdLength1 = 0;
        private static int startAddress2 = 0;
        private static int cmdLength2 = 0;
        private const string DOWNLOAD_FINISHED_MSG = "پایان دانلود";
        private const string DOWNLOAD_FAILED_ERROR = "دانلود با خطا مواجه شد";
        private const string ECU_NOT_DETECTED_ERROR = "ای سی یو شناسایی نشد";
        private const string CLEARING_ERROR = "پاکسازی ای سی یو با خطا مواجه شد";
        private const string ENTERED_TO_ZONE_1 = "شروع ناحیه اول";
        private const string ENTERED_TO_ZONE_2 = "شروع ناحیه دوم";
		
        public static bool crouseEasyU2_5()
        {
            procBarVal = 0;
            string resp = "";

            startAddress1 = DumpConnection.startAddress();
            endAddress1 = DumpConnection.endAddress();
            cmdLength1 = startAddress1 - endAddress1;
			
            int numOfFrames1 = cmdLength1 / FRAME_LEN;
            int rest1 = cmdLength1 % FRAME_LEN;
            int last_add1 = endAddress1 - rest1 + 1;

            string[] cmd1 = new string[cmdLength1];
            string[] frames1 = new string[numOfFrames1];
            string[] finalcmd1 = new string[numOfFrames1 + 1];

            startAddress2 = 0x20000;
            cmdLength2 = 0x20000;

            int numOfFrames2 = cmdLength2 / FRAME_LEN;
            int rest2 = cmdLength1 % FRAME_LEN;
            int last_add2 = startAddress2 + cmdLength2 - rest2;

            string[] cmd2 = new string[cmdLength2];
            string[] frames2 = new string[numOfFrames2];
            string[] finalcmd2 = new string[numOfFrames2 + 1];      

            double progBarRatio1 = (double)(numOfFrames1) / (double)(numOfFrames1 + numOfFrames2);
            double progBarRatio2 = 1 - progBarRatio1;

            Logger.Write(" ");
            Logger.Write("** Download to ECU");
            Logger.Write("** ECU ID:  " + AutoDetection.SpecificationID);
            Logger.Write("** soft ref:  " + AutoDetection.Softref);
            Logger.Write("** boot ref:  " + AutoDetection.Bootref);
            Logger.Write("** calibration:  " + AutoDetection.Calibref);
            Logger.Write(" ");

            CanECUs.icInit("07 E0", "FF FF");
            Thread.Sleep(100);

            do
            {
                CanECUs.sendCommand("07 E0", "02 10 81");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

                CanECUs.sendCommand("07 E0", "02 21 91");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
                if (resp.Substring(12, 2) == "7F" || resp == "")
                {
                    Message.messageBox_Show_Ok("xs", ECU_NOT_DETECTED_ERROR);
                    return false;
                }
            softRef = CanECUs.srNormalize(resp);

            do
            {
                CanECUs.sendCommand("07 E0", "02 21 81");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");           

            do
            {
                CanECUs.sendCommand("07 E0", "02 10 85");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");          

            do
            {
                CanECUs.sendCommand("07 E0", "02 10 85");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

                CanECUs.sendCommand("07 E0", "02 21 91");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            if (resp.Substring(12, 2) == "7F")
            {
                Message.messageBox_Show_Ok("xs", ECU_NOT_DETECTED_ERROR);
                return false;
            }

            do
            {
                CanECUs.sendCommand("07 E0", "02 10 81");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            do
            {
                CanECUs.sendCommand("07 E0", "02 10 85");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            do
            {
                CanECUs.sendCommand("07 E0", "02 3E 00");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            do
            {
                CanECUs.sendCommand("07 E0", "02 3E 00");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            do
            {
                CanECUs.sendCommand("07 E0", "02 3E 00");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            do
            {
                CanECUs.sendCommand("07 E0", "02 27 01");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(9, 2) == "7F");

            CanECUs.sendCommand("07 E0", "06 27 02 35 01 A4 D1");
            Thread.Sleep(50);
            CanECUs.getData(ref resp);
            if (resp.Substring(9, 2) == "7F")
            {
                Message.messageBox_Show_Ok("xs", CLEARING_ERROR);
                return false;
            }

            do
            {
                CanECUs.sendCommand("07 E0", "02 31 01");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            do
            {
                CanECUs.sendCommand("07 E0", "08 34 04 00 00 00 0C 00 00");
                Thread.Sleep(50);
                CanECUs.getData(ref resp);
            } while (resp.Substring(12, 2) == "7F");

            frm_Main._FrmMainObj.UpdateMessage(ENTERED_TO_ZONE_1);
            cmd1 = DumpConnection.read(startAddress1, cmdLength1);

            for (int i = 0; i < numOfFrames1; i++)
                for (int j = 0; j < FRAME_LEN; j++)
                    frames1[i] += cmd1[j + i * FRAME_LEN] + " ";

            for (int i = 0; i < numOfFrames1; i++)
            {
                finalcmd1[i] = "F1 36 " + frames1[i];
                finalcmd1[i] = finalcmd1[i].Trim();
            }

            string last_frame = DumpConnection.lastFrame(last_add1, rest1);
            finalcmd1[numOfFrames1] = (rest1 + 1).ToString("X2") + " 36 " + last_frame;

            for (int i = 0; i < numOfFrames1 + 1; i++)
            {
                CanECUs.sendCommand("07 E0", finalcmd1[i]);
                Thread.Sleep(15);
                CanECUs.getData(ref resp);
                UpdateProgressBar(numOfFrames1, i, progBarRatio1);
            
                if (resp.Trim() == "" || resp.Substring(12, 2) == "7F" || resp.Substring(9, 5) != "01 76")
                {
                    Message.messageBox_Show_Ok("xs", DOWNLOAD_FAILED_ERROR);
                    return false;
                }
            }

            frm_Main._FrmMainObj.UpdateMessage(ENTERED_TO_ZONE_2);
            cmd2 = DumpConnection.read(startAddress2, cmdLength2);

            for (int i = 0; i < numOfFrames2; i++)
                for (int j = 0; j < FRAME_LEN; j++)
                    frames2[i] += cmd2[j + i * FRAME_LEN] + " ";

            for (int i = 0; i < numOfFrames2; i++)
                finalcmd2[i] = "F1 36 " + frames2[i].Trim();

            finalcmd2[numOfFrames2] = (rest2+1).ToString("X2") + " 36 " + DumpConnection.lastFrame(last_add2, rest2);
            for (int i = 0; i < numOfFrames2 + 1; i++)
            {
                CanECUs.sendCommand("07 E0", finalcmd2[i]);
                Thread.Sleep(15);
                CanECUs.getData(ref resp);
                UpdateProgressBar(numOfFrames2, i, progBarRatio2);

                if (resp.Trim() == "" || resp.Substring(12, 2) == "7F" || resp.Substring(9, 5) != "01 76")
                {
                    Message.messageBox_Show_Ok("xs", DOWNLOAD_FAILED_ERROR);
                    return false;
                }
            }

            frm_Main._FrmMainObj.UpdateMessage(DOWNLOAD_FINISHED_MSG);
            return true;
        }

        public static void UpdateProgressBar(int TotalNumber, int counter, double Ratio)
        {
            double progbar_value = (counter * 100) / TotalNumber;
            procBarVal = (int)(progbar_value * Ratio);
            frm_Main._FrmMainObj.ProgressBar_Set(procBarVal);
        }

    }
}