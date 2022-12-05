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
        private const string canBudrate3B = "06 04 13";//CanBaudrate_500k_B
        private const string initMsg = "1E F1 01 01 65 14 EE C4 E4 B5 94 E4 A6 65 65 65 65 65 65 65 65 65 65 65 0E";
        private const string icInitMsg = "1B 00 80 00 0E 00 00 00 00 00 00 00 00 00 00 00 00 11 00 00 00 00 00 00 00 00 ";
        private const string canInitCmdStart = "1B 00 20 00 0E 00 00 ";
        private const string canInitCmdMiddle = " 00 00 00 00 00 00 00 00 4";
        private const string canInitCmdEnd = " 00 00 00 00 00 00 00";
        private const string sumcheckCmdStart = "1B 00 2";
        private const string sumcheckCmdMiddle = " 00 0E 00 00 ";
        private const string sumcheckCmdEnd = " 20 00 00 00 00 00 00 00 00 00 00 00";
        private const string bigSizeByte = "Size Byte Is Larger Than Real Size";
        private const string smallSizeByte = "Size Byte Is Smaller Than Real Size";

        public static bool icInit(string header2B, string mask2B)
        {
            int m_1 = 0x10;
            int m_2 = 0x20;
            int m_3 = 0x30;
            bool logi = init();

            Connections.SendCommand(initMsg, 100);

            if (logi)
            {
                logi = initMob(m_1, header2B, mask2B);
                if (logi)
                {
                    logi = initMob(m_2, header2B, mask2B);
                    if (logi)
                        logi = initMob(m_3, header2B, mask2B);
                }
            }

            Connections.clearBuffer();
          

            return logi;
        }

        private static bool init()
        {
            string initialMsg = AutoDetection.AddSumCheck(icInitMsg + canBudrate3B);
            Connections.SendCommand(initialMsg, 100);
            return Connections.ReadNbyte().Contains("60");
        }

        private static bool initMob(int MOB, string header2B, string mask2B)
        {
            string initializeMsg;
            string header = header2B.Trim() + "8";
            string mob = ((MOB / 0x10)).ToString("X1");
            string canInitMsg = canInitCmdStart + header + canInitCmdMiddle + mob + " FF FF " + mask2B + canInitCmdEnd;      
            initializeMsg = AutoDetection.AddSumCheck(canInitMsg);       
            return Connections.SendCommand(initializeMsg, 200);
        }

        private static bool sendFrame(string header2B, string command8B)
        {
            command8B = command8B.Trim();
            int commandSize = ((command8B.Length + 1) / 3);
            string initialMsg;
            string sumCheckCommand = sumcheckCmdStart + commandSize + sumcheckCmdMiddle + header2B + " " + command8B + sumcheckCmdEnd;

            if (command8B != "")
            {
                initialMsg = AutoDetection.AddSumCheck(sumCheckCommand);
                return Connections.SendCommand(initialMsg, 1);//100
            }
            else
                return true;
        }       
        
        public static bool sendCommand(string header2B, string body)
        {
            string cmd = "";
            int msgCount;
            int ctr = 0;
            int numOfBytes = ((body.Length + 1) / 3) - 1;
            int givenSize = int.Parse(body.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

            if (body == "")
                return false;

            if (numOfBytes < givenSize)
            {
                Message.messageBox_Show_Ok("xs", bigSizeByte);
                return false;
            }
            else if (numOfBytes > givenSize)
            {
                Message.messageBox_Show_Ok("xs", smallSizeByte);
                return false;
            }
            else
            {
                if (numOfBytes < 8)
                {
                    cmd = (body + " 00 00 00 00 00 00 00 00").Substring(0, 23);
                    sendFrame(header2B, cmd);
                }
                else
                {
                    if ((numOfBytes + 1) % 7 == 0)
                        msgCount = (numOfBytes + 1) / 7;
                    else
                        msgCount = ((numOfBytes + 1) / 7) + 1;

                    string[] MsgArr = new string[msgCount];
                    int NumOfRows = 0x1000 + numOfBytes;

                    MsgArr[0] = NumOfRows.ToString("X2").Substring(0, 2) + " " + 
                                NumOfRows.ToString("X2").Substring(2, 2) + " " + 
                                body.Substring( 3, 17);

                    for (int i = 1; i < msgCount ; i++)
                    {
                        if (i % 16 == 0)
                            ctr++;

                        MsgArr[i] = "2" + (i - (16 * ctr)).ToString("X1") + " " + 
                                    (body + " 00 00 00 00 00 00 00 00").Substring(i * 21, 20);
                    }

                    for (int i=0; i<msgCount; i++)
                        sendFrame(header2B, MsgArr[i]);
                }
                return true;
            }
        }

        public static bool getData(ref string ecuCommand)
        {
            string data = "";
            string header = "";
            string frame = "";
            string sizeByte = "";
            string body = "";
            string tmpBody = "";
            int headerIndex = 0;
            int sizeByteIndex = 0;
            int bodyIndex = 0;
            int sizeOfCommand = 0;
            int bodyLength = 0;
            int msgCount = 0;

            Connections.readMsg(ref data, ref frame);

            if (data.Substring(0, 5) == "07 E8")
            {
                headerIndex = 0;
                header = data.Substring(headerIndex, 5);
                sizeByteIndex = 6;
                sizeByte = data.Substring(sizeByteIndex, 2);

                if (sizeByte == "30")
                    sizeOfCommand = 8;
                else
                    sizeOfCommand = int.Parse(sizeByte, System.Globalization.NumberStyles.HexNumber);

                bodyIndex = 9;
                if (sizeByte == "30")
                    bodyIndex = 6;
                bodyLength = data.Length - bodyIndex;
                tmpBody = data.Substring(bodyIndex, bodyLength);
            }

            if ((sizeOfCommand + 1) % 7 == 0)
                msgCount = (sizeOfCommand + 1) / 7;
            else
                msgCount = ((sizeOfCommand + 1) / 7) + 1;

            if (sizeOfCommand < 8)          
                body = tmpBody;
            else
            {
                tmpBody = tmpBody.Replace("60 6D 11 07 E8 08 ", "");
                tmpBody = tmpBody.Replace("6D 11 07 E8 08 ", "");

                tmpBody = tmpBody.Replace(tmpBody.Substring(18, 3), "NNN");
                if(msgCount > 2)
                    for (int i = 3; i <= msgCount; i++)
                        tmpBody = tmpBody.Replace(tmpBody.Substring((i*24)-30, 3), "NNN");
					
                tmpBody = tmpBody.Replace("NNN", "");
            }

            if (tmpBody.Length > (sizeOfCommand * 3) - 1)
                tmpBody = tmpBody.Substring(0, (sizeOfCommand * 3) - 1);

            tmpBody = tmpBody.Trim();
            body = tmpBody;

            ecuCommand = header + " " + sizeByte + " " + body;

            return (ecuCommand != "");
        }

        public static string srNormalize(string sr)
        {
            string softRef = "";
            int[] dec = new int[10];
            char[] chars = new char[10];

            for (int i = 0; i < 10; i++)
                softRef += System.Convert.ToChar(strToHex(sr.Substring(i * 3, 2).ToString())).ToString();

            return softRef;
        }

        public static string brNormalize(string br)
        {
            string result = "";
            int[] dec = new int[10];
            char[] chars = new char[10];

            for (int i = 0; i < 10; i++)
                result += System.Convert.ToChar(strToHex(br.Substring(i * 3, 2).ToString())).ToString();

            return result;
        }
        
        public static string caNormalize(string ca)
        {
            string result = "";
            int[] dec = new int[10];
            char[] chars = new char[10];

            for (int i = 0; i < 10; i++)
                result += System.Convert.ToChar(strToHex(ca.Substring(i * 3, 2).ToString())).ToString();

            return result;
        }

        static public int strToHex(string byteToConvert)
        {
            int result = 0;
            char b1 = byteToConvert[0];
            char b0 = byteToConvert[1];
            int mult1 = 0;
            int mult0 = 0;

            switch (b0)
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

            switch (b1)
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

            result = (mult1 * 16) + mult0;

            return result;
        }
    }
}