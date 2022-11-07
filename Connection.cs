		// Wait For The Given Time (ms) Until The Given Number Of Bytes Is Read From The Buffer
		// If The Read Number Of Bytes In This Time Is Less Than Excepted Returns False
		// Else Returns True
		public static bool WaitForBytes(int BytesToCheck = 1, int WaitingTime = 100)
        {
            bool result = false;
            DateTime TimeHolder = DateTime.Now;
            while ((DateTime.Now.Ticks < TimeHolder.Ticks + WaitingTime) && (serialPort1.BytesToRead < BytesToCheck))
                if (serialPort1.BytesToRead < 0)
                {
                    result = false;
                    return result;
                }

            result = (DateTime.Now.Millisecond < TimeHolder.Millisecond + WaitingTime);

            return result;
        }
        

        // This Function Receives The Data From Buffer As The Response Of The ECU
		// And Removes The Unwanted Bytes From It. Like 10, 21..22..23, Or 6D 11
        public static bool ReadMsg(ref string Response, ref string FrameByte)
        {
            Response = "";
            FrameByte = "";

            string Header2B = "";
            string BodySize = "";
            string Body = "";
            string[] CANBuffer = new string[2];
            string ErrorText = "";
            string ErrorMsg = "";
            string Continue = "30 00 10 00 00 00 00 00";
            string XX = "";
            int NumOfBytes = 0; // SizeByte In Integer
            int MsgCount = 0; // The Number Of Lines The Response Command Has
            int BodyBytes = 0; // The Number Of Bytes Necessary To Read
            int RestOfBody = 0; // Size Of The Rest Of Body After The Forst Frame

            Repeat:
            if (!WaitForBytes())
            {
                ErrorText = "No Data Received";
                goto ErrHandler;
            }

            CANBuffer[0] = serialPort1.ReadByte().ToString("X2");
            if (CANBuffer[0] != "6D")
                goto Repeat;
            // 6D Received

            if (!WaitForBytes())
            {
                ErrorText = "Bytes Lost After '6D'";
                goto ErrHandler;
            }

            CANBuffer[1] = serialPort1.ReadByte().ToString("X2");
            // 11 Received

            if (CANBuffer[0] == "6D" && CANBuffer[1] == "11")
            {
                if (!WaitForBytes(2, 100))
                {
                    ErrorText = "Header Bytes Lost After '6D 11'";
                    goto ErrHandler;
                }

                CANBuffer[0] = serialPort1.ReadByte().ToString("X2"); // 07
                CANBuffer[1] = serialPort1.ReadByte().ToString("X2"); // E8
            }
            else
                goto Repeat;

            Header2B = CANBuffer[0].Replace(" ", "") + " " + CANBuffer[1].Replace(" ", "");
            // "6D 11 07 E8" Received, The Header2B is "07 E8"

            if (!WaitForBytes(2, 100))
            {
                ErrorText = "Length Byte Lost";
                goto ErrHandler;
            }

            XX = serialPort1.ReadByte().ToString("X2"); // = 08
            BodySize = serialPort1.ReadByte().ToString("X2"); // Size Byte
            if (BodySize == "10")
            {
                BodySize = serialPort1.ReadByte().ToString("X2"); // The True Size Byte
                FrameByte = "10";
            }
            else
                FrameByte = "";
            // "6D 11 07 E8 SB" Received, Header: "07 E8", SizeByte: SB

            NumOfBytes = int.Parse(BodySize, System.Globalization.NumberStyles.HexNumber);

            if ((NumOfBytes + 1) % 7 == 0)
                MsgCount = (NumOfBytes + 1) / 7;
            else
                MsgCount = ((NumOfBytes + 1) / 7) + 1;

            if (MsgCount == 1)
            {
                BodyBytes = 7;
                RestOfBody = 0;
            }
            else if (MsgCount == 2)
            {
                BodyBytes = 19;
                RestOfBody = BodyBytes - 5;
            }
            else if (MsgCount > 2)
            {
                BodyBytes = (13 * MsgCount) - 6;
                RestOfBody = BodyBytes - 6;
            }

            // No Error Occured
            if (FrameByte == "") // Response Command Is Single Frame
                for (int i = 0; i < 7; i++)
                    Body += serialPort1.ReadByte().ToString("X2") + " ";

            else if (FrameByte == "10") // Response Command Is Multiframe
            {
                for (int i = 0; i < 6; i++)
                    Body += serialPort1.ReadByte().ToString("X2") + " ";               
                CanECUs.CAN_Send("07 E0", Continue);

                if (!WaitForBytes(RestOfBody, 1000))
                {
                    ErrorText = "Response Command Is Not Fully Received";
                    goto ErrHandler;
                }

                for (int i = 0; i < RestOfBody; i++)
                    Body += serialPort1.ReadByte().ToString("X2") + " ";
            }

            Body = Body.Trim(); // Removes The SPACE At The End Of The Command

            ErrorMsg = "";
            Response = Header2B + " " + BodySize + " " + Body; // 07 E8 + Size + Body: Body Contains "60 6D 11 07 E8 08" For Next Frames

            return true;

            // Error Occured
            ErrHandler:
            Header2B = "";
            Body = "";
            ErrorMsg = "[!ReadMsg] " + ErrorText;
            Message.messageBox_Show_Ok("xs", ErrorMsg);
            return false;
        }