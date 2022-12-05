		public static bool waitForBytes(int bytesToCheck = 1, int waitingTime = 100)
        {
            bool result = false;
            DateTime TimeHolder = DateTime.Now;
            while ((DateTime.Now.Ticks < TimeHolder.Ticks + waitingTime) && (serialPort1.BytesToRead < bytesToCheck))
                if (serialPort1.BytesToRead < 0)
                {
                    result = false;
                    return result;
                }

            result = (DateTime.Now.Millisecond < TimeHolder.Millisecond + waitingTime);

            return result;
        }
        
        public static bool readMsg(ref string response, ref string frameByte)
        {
            response = "";
            frameByte = "";

            string header2B = "";
            string bodySize = "";
            string body = "";
            string[] canBuffer = new string[2];
            string errorText = "";
            string errorMsg = "";
            string continueCommand = "30 00 10 00 00 00 00 00";
            string XX = "";
            int numOfBytes = 0;
            int msgCount = 0;
            int bodyBytes = 0;
            int restOfBody = 0;

            Repeat:
            if (!waitForBytes())
            {
                errorText = "No Data Received";
                goto ErrorHandler;
            }

            canBuffer[0] = serialPort1.ReadByte().ToString("X2");
            if (canBuffer[0] != "6D")
                goto Repeat;

            if (!waitForBytes())
            {
                errorText = "Bytes Lost After 6D";
                goto ErrorHandler;
            }

            canBuffer[1] = serialPort1.ReadByte().ToString("X2");

            if (canBuffer[0] == "6D" && canBuffer[1] == "11")
            {
                if (!waitForBytes(2, 100))
                {
                    errorText = "Header Bytes Lost After '6D 11'";
                    goto ErrorHandler;
                }

                canBuffer[0] = serialPort1.ReadByte().ToString("X2");
                canBuffer[1] = serialPort1.ReadByte().ToString("X2");
            }
            else
                goto Repeat;

            header2B = canBuffer[0].Replace(" ", "") + " " + canBuffer[1].Replace(" ", "");

            if (!waitForBytes(2, 100))
            {
                errorText = "Length Byte Lost";
                goto ErrorHandler;
            }

            XX = serialPort1.ReadByte().ToString("X2");
            bodySize = serialPort1.ReadByte().ToString("X2");
            if (bodySize == "10")
            {
                bodySize = serialPort1.ReadByte().ToString("X2");
                frameByte = "10";
            }
            else
                frameByte = "";

            numOfBytes = int.Parse(bodySize, System.Globalization.NumberStyles.HexNumber);

            if ((numOfBytes + 1) % 7 == 0)
                msgCount = (numOfBytes + 1) / 7;
            else
                msgCount = ((numOfBytes + 1) / 7) + 1;

            if (msgCount == 1)
            {
                bodyBytes = 7;
                restOfBody = 0;
            }
            else if (msgCount == 2)
            {
                bodyBytes = 19;
                restOfBody = bodyBytes - 5;
            }
            else if (msgCount > 2)
            {
                bodyBytes = (13 * msgCount) - 6;
                restOfBody = bodyBytes - 6;
            }

            if (frameByte == ""
                for (int i = 0; i < 7; i++)
                    body += serialPort1.ReadByte().ToString("X2") + " ";

            else if (frameByte == "10")
            {
                for (int i = 0; i < 6; i++)
                    body += serialPort1.ReadByte().ToString("X2") + " ";               
                CanECUs.sendCommand("07 E0", continueCommand);

                if (!waitForBytes(restOfBody, 1000))
                {
                    errorText = "Response Command Is Not Fully Received";
                    goto ErrorHandler;
                }

                for (int i = 0; i < restOfBody; i++)
                    body += serialPort1.ReadByte().ToString("X2") + " ";
            }

            body = body.Trim();

            errorMsg = "";
            response = header2B + " " + bodySize + " " + body;

            return true;

            ErrorHandler:
            header2B = "";
            body = "";
            errorMsg = "[!ReadMsg] " + errorText;
            Message.messageBox_Show_Ok("xs", errorMsg);
            return false;
        }