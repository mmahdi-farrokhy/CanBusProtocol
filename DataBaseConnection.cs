using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace ProMap
{
    class DataBaseConnection
    {
        private static String connstr1 = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
        private static String connstr2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
        private static String Query = "";

        // FirstOrDefault
        public static History FirstOrDefault(ref History H)
        {
            Query = "SELECT * FROM History;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        H.ID = int.Parse(reader["ID"].ToString());
                        H.SpecificationID = int.Parse(reader["SpecificationID"].ToString());
                    }
                    con.Close();
                }
            }

            return H;
        }
        public static AdvanceRemap FirstOrDefault(ref AdvanceRemap AR)
        {
            Query = "SELECT * FROM AdvanceRemap;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AR.ID = int.Parse(reader["ID"].ToString());
                        AR.Type = reader["Type"].ToString();
                        AR.TableName = reader["TableName"].ToString();
                        AR.RowsCount = reader["RowsCount"].ToString();
                        AR.ColsCount = reader["ColsCount"].ToString();
                        AR.X_Name = reader["X_Name"].ToString();
                        AR.Y_Name = reader["Y_Name"].ToString();
                        AR.X_Min = reader["X_Min"].ToString();
                        AR.X_Max = reader["X_Max"].ToString();
                        AR.Y_Min = reader["Y_Min"].ToString();
                        AR.Y_Max = reader["Y_Max"].ToString();
                        AR.Address_Start = reader["Address_Start"].ToString();
                        AR.Address_End = reader["Address_End"].ToString();
                        AR.DataSize = reader["DataSize"].ToString();
                        AR.Type_Cryption = reader["Type_Cryption"].ToString();
                        AR.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        AR.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        AR.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        AR.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        AR.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        AR.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        AR.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        AR.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return AR;
        }
        public static ECUsSpecification FirstOrDefault(ref ECUsSpecification ES, int DefaultID)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return ES;
        }
        public static ExistingEcu FirstOrDefault(ref ExistingEcu EE, int DefaultID)
        {
            Query = "SELECT * FROM ExistingEcus WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EE.ID = int.Parse(reader["ID"].ToString());
                        EE.Specification_ID = int.Parse(reader["Specification_ID"].ToString());
                        EE.Connection_ID = int.Parse(reader["ConnectionID"].ToString());
                        EE.FileName = reader["FileName"].ToString();
                        EE.Comment = reader["Comment"].ToString();
                    }
                    con.Close();
                }
            }

            return EE;
        }
        public static DefaultLanguage FirstOrDefault(ref DefaultLanguage DL, int DefaultID)
        {
            Query = "SELECT * FROM DefaultLanguage WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DL.ID = int.Parse(reader["ID"].ToString());
                        DL.lang = reader["lang"].ToString();
                    }
                    con.Close();
                }
            }

            return DL;
        }
        public static History FirstOrDefault(ref History H, int DefaultID)
        {
            Query = "SELECT * FROM History WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        H.ID = int.Parse(reader["ID"].ToString());
                        H.SpecificationID = int.Parse(reader["SpecificationID"].ToString());
                    }
                    con.Close();
                }
            }

            return H;
        }
        public static Connection FirstOrDefault(ref Connection C, int DefaultID)
        {
            Query = "SELECT * FROM Connection WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        C.ID = int.Parse(reader["ID"].ToString());
                        C.Protocols_ID = int.Parse(reader["Protocols_ID"].ToString());
                        C.Pin = int.Parse(reader["Pin"].ToString());
                        C.Baudrate = int.Parse(reader["Baudrate"].ToString());
                        C.Header = reader["Header"].ToString();
                        C.Start_Command = reader["Start_Command"].ToString();
                        C.End_Command = reader["End_Command"].ToString();
                        C.Itteration_Command = reader["Itteration_Command"].ToString();
                    }
                    con.Close();
                }
            }

            return C;
        }
        public static Protocol FirstOrDefault(ref Protocol P, int DefaultID)
        {
            Query = "SELECT * FROM Protocols WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        P.ID = int.Parse(reader["ID"].ToString());
                        P.Name = reader["Protocol Name"].ToString();
                    }
                    con.Close();
                }
            }

            return P;
        }
        public static ECUsSpecification FirstOrDefault(ref ECUsSpecification ES, String DefaultBootRef)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE BootRef = '" + DefaultBootRef + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ES;
        }
        public static ECUsSpecification FirstOrDefault(ref ECUsSpecification ES, String Col1, String ColVal1, String Col2, String ColVal2, String Col3, String ColVal3, String Col4, String ColVal4, String Col5, String ColVal5, String Col6, String ColVal6)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE " + Col1 + " = '" + ColVal1 + "' OR" + Col2 + " = '" + ColVal2 + "' OR" + Col3 + " = '" + ColVal3 + "' OR" + Col4 + " = '" + ColVal4 + "' OR" + Col5 + " = '" + ColVal5 + "' OR" + Col6 + " = '" + ColVal6 + "' OR 1=1;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ES;
        }

        // Delete
        public static bool DeleteFromTable(String tbName, int DeleteID)
        {
            bool isDeleted = false;
            OleDbConnection dbcon = new OleDbConnection(connstr2);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "DELETE FROM " + tbName + " WHERE ID = " + DeleteID.ToString();
                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isDeleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }

            return isDeleted;
        }

        // Update
        public static bool UpdateTable(ECUsSpecification New_Value)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr2);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "UPDATE ECUsSpecification SET " +
                "Manufacturer ='" + New_Value.Manufacturer +
                "' ,DeviceName ='" + New_Value.DeviceName +
                "' ,Type ='" + New_Value.Type +
                "' ,BootRef ='" + New_Value.BootRef +
                "' ,SoftRef ='" + New_Value.SoftRef +
                "' ,Calibration ='" + New_Value.Calibration +
                "' ,BinFileName ='" + New_Value.BinFileName +
                "' ,BaudRate ='" + New_Value.BaudRate +
                "' ,CRC_Address ='" + New_Value.CRC_Address +
                "' ,ConnectionID =" + New_Value.ConnectionID +
                " ,Type1_AddressRemap ='" + New_Value.Type1_AddressRemap +
                "' ,Type2_TableRemap ='" + New_Value.Type2_TableRemap +
                "' ,ProductNumber ='" + New_Value.ProductNumber +
                "' ,HardwareCode ='" + New_Value.HardwareCode +
                "' ,Comment ='" + New_Value.Comment +
                "' ,UserID =" + New_Value.UserID +
                " ,type1Cryption ='" + New_Value.type1Cryption +
                "' ,binCryption = '" + New_Value.binCryption +
                "' ,crcCryption = '" + New_Value.crcCryption +
                "' WHERE ID = " + New_Value.ID;

                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }

            return isUpdated;
        }
        public static bool UpdateTable(ExistingEcu New_Value)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "UPDATE ExistingEcus SET " +
                "Specification_ID ='" + New_Value.Specification_ID +
                "Connection_ID ='" + New_Value.Connection_ID +
                "FileName ='" + New_Value.FileName +
                "Comment ='" + New_Value.Comment +
                "' WHERE ID = " + New_Value.ID;

                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }

            return isUpdated;
        }
        public static bool UpdateTable(DefaultLanguage New_Value)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "UPDATE DefaultLanguage SET " +
                "lang ='" + New_Value.lang +
                "' WHERE ID = " + New_Value.ID;

                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }

            return isUpdated;
        }
        public static bool UpdateTable(History New_Value)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "UPDATE History SET " +
                "SpecificationID ='" + New_Value.SpecificationID +
                "' WHERE ID = " + New_Value.ID;

                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }

            return isUpdated;
        }

        // Count
        public static int CountInTable(String tbName)
        {
            int NumberOfRecords = 0;
            Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName;

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfRecords = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfRecords;
        }
        public static int CountInTable(String tbName, int CountID)
        {
            int NumberOfECUs = 0;
            Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE ID = " + CountID.ToString() + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInTable(String tbName, String Col, String ColValue)
        {
            int NumberOfECUs = 0;
            Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE " + Col + " = '" + ColValue + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInTable(String tbName, String Col, int Leng, int id)
        {
            int NumberOfECUs = 0;
            Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE ID = " + id.ToString() + "AND LEN(" + Col + ") > " + Leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInTable(String tbName, String Col, int Leng, int id1, int id2)
        {
            int NumberOfECUs = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + Col + ") > " + Leng.ToString() + " AS ColLen;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInTable(String tbName, int id1, int id2, int id3, int id4)
        {
            int NumberOfECUs = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE ID = " + id1.ToString() + " OR ID = " + id2.ToString() + " OR ID = " + id3.ToString() + " OR ID = " + id4.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInTable(String tbName, String Col, Dictionary<int, String> SearchList)
        {
            int NumberOfECUs = 0;
            int Leng = SearchList.Count;


            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                for (int i = 0; i < Leng; i++)
                {
                    Query = "SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE " + Col + " = " + SearchList[i].ToString() + ";";
                    using (OleDbCommand cmd = new OleDbCommand(Query, con))
                    {
                        con.Open();
                        NumberOfECUs = (int)cmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }

            return NumberOfECUs;
        }
        public static int CountInTable(String tbName, String ColCont1, String Cont1, String ColCont2, String Cont2, String ColLeng, int Leng)
        {
            int NumberOfECUs = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }

        // GetData
        public static ECUsSpecification GetDataFromTable(ref ECUsSpecification ES, String Col, int Leng, int id)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE ID = " + id.ToString() + " AND Len(" + Col + ") >" + Leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }

            return ES;
        }
        public static ECUsSpecification GetDataFromTable(ref ECUsSpecification ES, string Col, int Leng, int id1, int id2)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + Col + ") > " + Leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }

            return ES;
        }
        public static ECUsSpecification GetDataFromTable(ref ECUsSpecification ES, int id1, int id2, int id3, int id4)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE ID = " + id1.ToString() + " OR ID = " + id2.ToString() + " OR ID = " + id3.ToString() + " OR ID = " + id4.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }

            return ES;
        }
        public static ECUsSpecification GetDataFromTable(ref ECUsSpecification ES, string ColCont1, string Cont1, string ColCont2, string Cont2, string ColLeng, int Leng)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }
            return ES;
        }
        public static ECUsSpecification GetDataFromTable(ref ECUsSpecification ES, string Col, Dictionary<int, string> SearchList)
        {
            int Leng = SearchList.Count();

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                for (int i = 0; i < Leng; i++)
                {
                    Query = "SELECT * FROM ECUsSpecification WHERE " + Col + " = " + SearchList[i].ToString() + ";";
                    using (OleDbCommand cmd = new OleDbCommand(Query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ES.ID = int.Parse(reader["ID"].ToString());
                            ES.Manufacturer = reader["Manufacturer"].ToString();
                            ES.DeviceName = reader["DeviceName"].ToString();
                            ES.Type = reader["Type"].ToString();
                            ES.BootRef = reader["BootRef"].ToString();
                            ES.SoftRef = reader["SoftRef"].ToString();
                            ES.Calibration = reader["Calibration"].ToString();
                            ES.BinFileName = reader["BinFileName"].ToString();
                            ES.BaudRate = reader["BaudRate"].ToString();
                            ES.CRC_Address = reader["CRC_Address"].ToString();
                            ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                            ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                            ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                            ES.ProductNumber = reader["ProductNumber"].ToString();
                            ES.HardwareCode = reader["HardwareCode"].ToString();
                            ES.Comment = reader["Comment"].ToString();
                            ES.UserID = int.Parse(reader["UserID"].ToString());
                            ES.type1Cryption = reader["type1Cryption"].ToString();
                            ES.binCryption = reader["binCryption"].ToString();
                            ES.crcCryption = reader["crcCryption"].ToString();
                        }
                        con.Close();
                    }
                }


            }
            return ES;
        }
        public static AdvanceRemap GetDataFromTable(ref AdvanceRemap AR, string GetType)
        {
            Query = "SELECT * FROM AdvanceRemap WHERE Type = '" + GetType + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AR.ID = int.Parse(reader["ID"].ToString());
                        AR.Type = reader["Type"].ToString();
                        AR.TableName = reader["TableName"].ToString();
                        AR.RowsCount = reader["RowsCount"].ToString();
                        AR.ColsCount = reader["ColsCount"].ToString();
                        AR.X_Name = reader["X_Name"].ToString();
                        AR.Y_Name = reader["Y_Name"].ToString();
                        AR.X_Min = reader["X_Min"].ToString();
                        AR.X_Max = reader["X_Max"].ToString();
                        AR.Y_Min = reader["Y_Min"].ToString();
                        AR.Y_Max = reader["Y_Max"].ToString();
                        AR.Address_Start = reader["Address_Start"].ToString();
                        AR.Address_End = reader["Address_End"].ToString();
                        AR.DataSize = reader["DataSize"].ToString();
                        AR.Type_Cryption = reader["Type_Cryption"].ToString();
                        AR.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        AR.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        AR.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        AR.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        AR.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        AR.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        AR.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        AR.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return AR;
        }
        public static AdvanceRemap GetDataFromTable(ref AdvanceRemap AR, string GetType, int GetID)
        {
            Query = "SELECT * FROM AdvanceRemap WHERE Type = '" + GetType + "' AND ID = " + GetID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AR.ID = int.Parse(reader["ID"].ToString());
                        AR.Type = reader["Type"].ToString();
                        AR.TableName = reader["TableName"].ToString();
                        AR.RowsCount = reader["RowsCount"].ToString();
                        AR.ColsCount = reader["ColsCount"].ToString();
                        AR.X_Name = reader["X_Name"].ToString();
                        AR.Y_Name = reader["Y_Name"].ToString();
                        AR.X_Min = reader["X_Min"].ToString();
                        AR.X_Max = reader["X_Max"].ToString();
                        AR.Y_Min = reader["Y_Min"].ToString();
                        AR.Y_Max = reader["Y_Max"].ToString();
                        AR.Address_Start = reader["Address_Start"].ToString();
                        AR.Address_End = reader["Address_End"].ToString();
                        AR.DataSize = reader["DataSize"].ToString();
                        AR.Type_Cryption = reader["Type_Cryption"].ToString();
                        AR.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        AR.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        AR.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        AR.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        AR.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        AR.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        AR.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        AR.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return AR;
        }

        // Contains
        public static ECUsSpecification TableContains(ECUsSpecification ES, String Col, String ColValue)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE " + Col + " = '" + ColValue + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.type2Cryption = reader["type2Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ES;
        }
        public static ECUsSpecification TableContains(ECUsSpecification ES, String Col, String ColValue, int DefaultID)
        {
            Query = "SELECT * FROM ECUsSpecification WHERE " + Col + " = '" + ColValue + "' AND ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ES.ID = int.Parse(reader["ID"].ToString());
                        ES.Manufacturer = reader["Manufacturer"].ToString();
                        ES.DeviceName = reader["DeviceName"].ToString();
                        ES.Type = reader["Type"].ToString();
                        ES.BootRef = reader["BootRef"].ToString();
                        ES.SoftRef = reader["SoftRef"].ToString();
                        ES.Calibration = reader["Calibration"].ToString();
                        ES.BinFileName = reader["BinFileName"].ToString();
                        ES.BaudRate = reader["BaudRate"].ToString();
                        ES.CRC_Address = reader["CRC_Address"].ToString();
                        ES.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        ES.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        ES.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        ES.ProductNumber = reader["ProductNumber"].ToString();
                        ES.HardwareCode = reader["HardwareCode"].ToString();
                        ES.Comment = reader["Comment"].ToString();
                        ES.UserID = int.Parse(reader["UserID"].ToString());
                        ES.type1Cryption = reader["type1Cryption"].ToString();
                        ES.type2Cryption = reader["type2Cryption"].ToString();
                        ES.binCryption = reader["binCryption"].ToString();
                        ES.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ES;
        }

        // Add Mew Item To The Given Table
        public static bool InsertToDatabase(String tbName, String[] New_Record)
        {
            bool isAdded = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);

            switch (tbName)
            {
                case "ECUsSpecification":
                    try
                    {
                        OleDbCommand cmd = dbcon.CreateCommand();
                        dbcon.Open();
                        cmd.CommandText = "INSERT INTO ECUsSpecification([Manufacturer] , [Type], [BootRef], [SoftRef], [Calibration], [ProductNumber], [HardwareCode], [Comment]) VALUES('" + New_Record[0] + "','" + New_Record[1] + "','" + New_Record[2] + "','" + New_Record[3] + "','" + New_Record[4] + "','" + New_Record[5] + "','" + New_Record[6] + "','" + New_Record[7] + "');";
                        cmd.Connection = dbcon;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ECU Inserted", "Done!");
                        dbcon.Close();
                        isAdded = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert Error:" + ex.Message);
                    }
                    break;

                case "ExistingEcus":
                    try
                    {
                        OleDbCommand cmd = dbcon.CreateCommand();
                        dbcon.Open();
                        cmd.CommandText = "INSERT INTO ExistingEcus([Specification_ID] , [Connection_ID], [FileName], [Comment]) VALUES(" + New_Record[0] + "," + New_Record[1] + ",'" + New_Record[2] + "','" + New_Record[3] + "');";
                        cmd.Connection = dbcon;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ECU Inserted", "Done!");
                        dbcon.Close();
                        isAdded = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert Error:" + ex.Message);
                    }
                    break;

                case "History":
                    try
                    {
                        OleDbCommand cmd = dbcon.CreateCommand();
                        dbcon.Open();
                        cmd.CommandText = "INSERT INTO History([SpecificationID]) VALUES('" + New_Record[0] + "');";
                        cmd.Connection = dbcon;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("History Inserted", "Done!");
                        dbcon.Close();
                        isAdded = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert Error:" + ex.Message);
                    }
                    break;
            }
            return isAdded;
        }

        // Read From Database Tables And Show On Datagirdview
        public static DataTable ShowOnGridView(String tbName)
        {
            DataTable dtECUs = new DataTable();
               
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            using (OleDbCommand cmd = new OleDbCommand("SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification", con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show ExistingEcus In Datagridview
                case "ExistingEcus":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            using (OleDbCommand cmd = new OleDbCommand("SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus", con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Protocols In Datagridview
                case "Protocols":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            using (OleDbCommand cmd = new OleDbCommand("SELECT Protocols.ID, Protocols.Name FROM Protocols", con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Connection In Datagridview
                case "Connection":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            using (OleDbCommand cmd = new OleDbCommand("SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection", con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;
            }

            return dtECUs;
        }
        public static DataTable ShowOnGridView(String tbName, String ColCont, String Cont, String ColLeng, int Leng)
        {
            DataTable dtECUs = new DataTable();
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
                            Query += "WHERE InStr(" + ColCont + ",'" + Cont + "') AND LEN(" + ColLeng + ") > " + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show ExistingEcus In Datagridview
                case "ExistingEcus":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
                            Query += "WHERE InStr(" + ColCont + ",'" + Cont + "') AND LEN(" + ColLeng + ") > 0;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Protocols In Datagridview
                case "Protocols":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
                            Query += "WHERE InStr(" + ColCont + ",'" + Cont + "') AND LEN(" + ColLeng + ") > 0;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Connection In Datagridview
                case "Connection":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
                            Query += "WHERE InStr(" + ColCont + ",'" + Cont + "') AND LEN(" + ColLeng + ") > 0;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;
            }

            return dtECUs;
        }
        public static DataTable ShowOnGridView(String tbName, String ColLeng, int Leng, int id1, int id2)
        {
            DataTable dtECUs = new DataTable();
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
                            Query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + ColLeng + ") > " + Leng.ToString() + " AS ColLen;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show ExistingEcus In Datagridview
                case "ExistingEcus":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
                            Query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + ColLeng + ") > " + Leng.ToString() + " AS ColLen;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Protocols In Datagridview
                case "Protocols":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
                            Query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + ColLeng + ") > " + Leng.ToString() + " AS ColLen;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Connection In Datagridview
                case "Connection":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
                            Query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + ColLeng + ") > " + Leng.ToString() + " AS ColLen;";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;
            }

            return dtECUs;
        }
        public static DataTable ShowOnGridView(String tbName, String ColCont1, String Cont1, String ColCont2, String Cont2, String ColLeng, int Leng)
        {
            DataTable dtECUs = new DataTable();
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show ExistingEcus In Datagridview
                case "ExistingEcus":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Protocols In Datagridview
                case "Protocols":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Connection In Datagridview
                case "Connection":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;
            }

            return dtECUs;
        }
        public static DataTable ShowOnGridView(String tbName, String ColCont1, String Cont1, String ColCont2, String Cont2, String ColCont3, String Cont3, String ColLeng, int Leng)
        {
            DataTable dtECUs = new DataTable();
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND InStr(" + ColCont3 + ",'" + Cont3 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show ExistingEcus In Datagridview
                case "ExistingEcus":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND InStr(" + ColCont3 + ",'" + Cont3 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Protocols In Datagridview
                case "Protocols":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND InStr(" + ColCont3 + ",'" + Cont3 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Connection In Datagridview
                case "Connection":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            Query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
                            Query += "WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND InStr(" + ColCont3 + ",'" + Cont3 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                            using (OleDbCommand cmd = new OleDbCommand(Query, con))
                            {
                                con.Open();
                                OleDbDataReader reader = cmd.ExecuteReader();
                                dtECUs.Load(reader);
                                con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;
            }

            return dtECUs;
        }
        public static DataTable ShowOnGridView(String tbName, String Col, int[] SearchList)
        {
            DataTable dtECUs = new DataTable();
            string Query = "";
            int Leng = SearchList.Count();
            
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            for (int i = 0; i < Leng; i++)
                            {
                                Query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
                                Query += "WHERE " + Col + " = " + SearchList[i].ToString().Trim() + ";";
                                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                                {
                                    con.Open();
                                    OleDbDataReader reader = cmd.ExecuteReader();
                                    dtECUs.Load(reader);
                                    con.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show ExistingEcus In Datagridview
                case "ExistingEcus":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            for (int i = 0; i < Leng; i++)
                            {
                                Query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
                                Query += "WHERE " + Col + " = " + SearchList[i].ToString().Trim() + ";";
                                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                                {
                                    con.Open();
                                    OleDbDataReader reader = cmd.ExecuteReader();
                                    dtECUs.Load(reader);
                                    con.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Protocols In Datagridview
                case "Protocols":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            for (int i = 0; i < Leng; i++)
                            {
                                Query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
                                Query += "WHERE " + Col + " = " + SearchList[i].ToString().Trim() + ";";
                                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                                {
                                    con.Open();
                                    OleDbDataReader reader = cmd.ExecuteReader();
                                    dtECUs.Load(reader);
                                    con.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;

                // Show Connection In Datagridview
                case "Connection":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr1))
                        {
                            for (int i = 0; i < Leng; i++)
                            {
                                Query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
                                Query += "WHERE " + Col + " = " + SearchList[i].ToString().Trim() + ";";
                                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                                {
                                    con.Open();
                                    OleDbDataReader reader = cmd.ExecuteReader();
                                    dtECUs.Load(reader);
                                    con.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Read Error:" + ex.Message);
                    }
                    break;
            }

            return dtECUs;
        }

        // Read Data From 2 Joined Tables
        public static String[] ReadFromJoinedTables(String Table1, String Table2, String ES_Col, String EE_Col)
        {
            string Query = "";
            string[] Record = new string[7];

            Query = "SELECT * FROM " + Table1 + " INNER JOIN " + Table2 + " ON ECUsSpecification.[" + ES_Col + "] = ExistingEcus.[" + EE_Col + "];";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record[0] = reader["ID"].ToString();
                        Record[1] = reader["Manufacturer"].ToString();
                        Record[2] = reader["Type"].ToString();
                        Record[3] = reader["BootRef"].ToString();
                        Record[4] = reader["SoftRef"].ToString();
                        Record[5] = reader["Calibration"].ToString();
                        Record[6] = reader["Comment"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }

    }
}