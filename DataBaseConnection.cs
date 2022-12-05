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
    class DatabaseConnection
    {
        private static String connstr1 = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
        private static String query = "";

        public static History firstOrDefault(ref History h)
        {
            query = "SELECT * FROM History;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        h.ID = int.Parse(reader["ID"].ToString());
                        h.SpecificationID = int.Parse(reader["SpecificationID"].ToString());
                    }
                    con.Close();
                }
            }

            return h;
        }
        public static AdvanceRemap firstOrDefault(ref AdvanceRemap ar)
        {
            query = "SELECT * FROM AdvanceRemap;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ar.ID = int.Parse(reader["ID"].ToString());
                        ar.Type = reader["Type"].ToString();
                        ar.TableName = reader["TableName"].ToString();
                        ar.RowsCount = reader["RowsCount"].ToString();
                        ar.ColsCount = reader["ColsCount"].ToString();
                        ar.X_Name = reader["X_Name"].ToString();
                        ar.Y_Name = reader["Y_Name"].ToString();
                        ar.X_Min = reader["X_Min"].ToString();
                        ar.X_Max = reader["X_Max"].ToString();
                        ar.Y_Min = reader["Y_Min"].ToString();
                        ar.Y_Max = reader["Y_Max"].ToString();
                        ar.Address_Start = reader["Address_Start"].ToString();
                        ar.Address_End = reader["Address_End"].ToString();
                        ar.DataSize = reader["DataSize"].ToString();
                        ar.Type_Cryption = reader["Type_Cryption"].ToString();
                        ar.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        ar.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        ar.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        ar.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        ar.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        ar.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        ar.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        ar.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ar;
        }
        public static ECUsSpecification firstOrDefault(ref ECUsSpecification es, int defaultId)
        {
            query = "SELECT * FROM ECUsSpecification WHERE ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return es;
        }
        public static ExistingEcu firstOrDefault(ref ExistingEcu ee, int defaultId)
        {
            query = "SELECT * FROM ExistingEcus WHERE ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ee.ID = int.Parse(reader["ID"].ToString());
                        ee.Specification_ID = int.Parse(reader["Specification_ID"].ToString());
                        ee.Connection_ID = int.Parse(reader["ConnectionID"].ToString());
                        ee.FileName = reader["FileName"].ToString();
                        ee.Comment = reader["Comment"].ToString();
                    }
                    con.Close();
                }
            }

            return ee;
        }
        public static DefaultLanguage firstOrDefault(ref DefaultLanguage dl, int defaultId)
        {
            query = "SELECT * FROM DefaultLanguage WHERE ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dl.ID = int.Parse(reader["ID"].ToString());
                        dl.lang = reader["lang"].ToString();
                    }
                    con.Close();
                }
            }

            return dl;
        }
        public static History firstOrDefault(ref History h, int defaultId)
        {
            query = "SELECT * FROM History WHERE ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        h.ID = int.Parse(reader["ID"].ToString());
                        h.SpecificationID = int.Parse(reader["SpecificationID"].ToString());
                    }
                    con.Close();
                }
            }

            return h;
        }
        public static Connection firstOrDefault(ref Connection c, int defaultId)
        {
            query = "SELECT * FROM Connection WHERE ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        c.ID = int.Parse(reader["ID"].ToString());
                        c.Protocols_ID = int.Parse(reader["Protocols_ID"].ToString());
                        c.Pin = int.Parse(reader["Pin"].ToString());
                        c.Baudrate = int.Parse(reader["Baudrate"].ToString());
                        c.Header = reader["Header"].ToString();
                        c.Start_Command = reader["Start_Command"].ToString();
                        c.End_Command = reader["End_Command"].ToString();
                        c.Itteration_Command = reader["Itteration_Command"].ToString();
                    }
                    con.Close();
                }
            }

            return c;
        }
        public static Protocol firstOrDefault(ref Protocol p, int defaultId)
        {
            query = "SELECT * FROM Protocols WHERE ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        p.ID = int.Parse(reader["ID"].ToString());
                        p.Name = reader["Protocol Name"].ToString();
                    }
                    con.Close();
                }
            }

            return p;
        }
        public static ECUsSpecification firstOrDefault(ref ECUsSpecification es, String defaultBootRef)
        {
            query = "SELECT * FROM ECUsSpecification WHERE BootRef = '" + defaultBootRef + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return es;
        }
        public static ECUsSpecification firstOrDefault(ref ECUsSpecification es, String col1, String colVal1, String col2, String colVal2, String col3, String colVal3, String col4, String colVal4, String col5, String colVal5, String col6, String colVal6)
        {
            query = "SELECT * FROM ECUsSpecification WHERE " + col1 + " = '" + colVal1 + "' OR" + col2 + " = '" + colVal2 + "' OR" + col3 + " = '" + colVal3 + "' OR" + col4 + " = '" + colVal4 + "' OR" + col5 + " = '" + colVal5 + "' OR" + col6 + " = '" + colVal6 + "' OR 1=1;";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return es;
        }

        public static bool deleteFromTable(String tbName, int deleteId)
        {
            bool isDeleted = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "DELETE FROM " + tbName + " WHERE ID = " + deleteId.ToString();

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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

        public static bool updateTable(ECUsSpecification newValue)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "UPDATE ECUsSpecification SET " +
                    "Manufacturer ='" + newValue.Manufacturer +
                    "' ,DeviceName ='" + newValue.DeviceName +
                    "' ,Type ='" + newValue.Type +
                    "' ,BootRef ='" + newValue.BootRef +
                    "' ,SoftRef ='" + newValue.SoftRef +
                    "' ,Calibration ='" + newValue.Calibration +
                    "' ,BinFileName ='" + newValue.BinFileName +
                    "' ,BaudRate ='" + newValue.BaudRate +
                    "' ,CRC_Address ='" + newValue.CRC_Address +
                    "' ,ConnectionID =" + newValue.ConnectionID +
                    " ,Type1_AddressRemap ='" + newValue.Type1_AddressRemap +
                    "' ,Type2_TableRemap ='" + newValue.Type2_TableRemap +
                    "' ,ProductNumber ='" + newValue.ProductNumber +
                    "' ,HardwareCode ='" + newValue.HardwareCode +
                    "' ,Comment ='" + newValue.Comment +
                    "' ,UserID =" + newValue.UserID +
                    " ,type1Cryption ='" + newValue.type1Cryption +
                    "' ,binCryption = '" + newValue.binCryption +
                    "' ,crcCryption = '" + newValue.crcCryption +
                    "' WHERE ID = " + newValue.ID;

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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
        public static bool updateTable(ExistingEcu newValue)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "UPDATE ExistingEcus SET " +
                    "Specification_ID ='" + newValue.Specification_ID +
                    "Connection_ID ='" + newValue.Connection_ID +
                    "FileName ='" + newValue.FileName +
                    "Comment ='" + newValue.Comment +
                    "' WHERE ID = " + newValue.ID;

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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
        public static bool updateTable(DefaultLanguage newValue)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "UPDATE DefaultLanguage SET " +
                    "lang ='" + newValue.lang +
                    "' WHERE ID = " + newValue.ID;

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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
        public static bool updateTable(History newValue)
        {
            bool isUpdated = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "UPDATE History SET " +
                    "SpecificationID ='" + newValue.SpecificationID +
                    "' WHERE ID = " + newValue.ID;

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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

        public static int countInTable(String tbName)
        {
            int NumberOfRecords = 0;
            query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName;

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    NumberOfRecords = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfRecords;
        }
        public static int countInTable(String tbName, int countID)
        {
            int NumberOfRecords = 0;
            query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE ID = " + countID.ToString() + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    NumberOfRecords = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfRecords;
        }
        public static int countInTable(String tbName, String col, String colValue)
        {
            int NumberOfRecords = 0;
            query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE " + col + " = '" + colValue + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    NumberOfRecords = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfRecords;
        }
        public static int countInTable(String tbName, String col, int leng, int id)
        {
            int NumberOfRecords = 0;
            query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE ID = " + id.ToString() + "AND LEN(" + col + ") > " + leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    NumberOfRecords = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfRecords;
        }
        public static int countInTable(String tbName, String col, int leng, int id1, int id2)
        {
            int NumberOfRecords = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + col + ") > " + leng.ToString() + " AS ColLen;";

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
        public static int countInTable(String tbName, int id1, int id2, int id3, int id4)
        {
            int NumberOfRecords = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE ID = " + id1.ToString() + " OR ID = " + id2.ToString() + " OR ID = " + id3.ToString() + " OR ID = " + id4.ToString() + ";";

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
        public static int countInTable(String tbName, String col, Dictionary<int, String> searchList)
        {
            int NumberOfRecords = 0;
            int Leng = searchList.Count;


            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                for (int i = 0; i < Leng; i++)
                {
                    query = "SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE " + col + " = " + searchList[i].ToString() + ";";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        NumberOfRecords = (int)cmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }

            return NumberOfRecords;
        }
        public static int countInTable(String tbName, String colCont1, String cont1, String colCont2, String cont2, String colLeng, int leng)
        {
            int NumberOfRecords = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM " + tbName + " WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

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

        public static ECUsSpecification getDataFromTable(ref ECUsSpecification es, String col, int leng, int id)
        {
            query = "SELECT * FROM ECUsSpecification WHERE ID = " + id.ToString() + " AND Len(" + col + ") >" + leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }

            return es;
        }
        public static ECUsSpecification getDataFromTable(ref ECUsSpecification es, string col, int leng, int id1, int id2)
        {
            query = "SELECT * FROM ECUsSpecification WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + col + ") > " + leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }

            return es;
        }
        public static ECUsSpecification getDataFromTable(ref ECUsSpecification es, int id1, int id2, int id3, int id4)
        {
            query = "SELECT * FROM ECUsSpecification WHERE ID = " + id1.ToString() + " OR ID = " + id2.ToString() + " OR ID = " + id3.ToString() + " OR ID = " + id4.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }

            return es;
        }
        public static ECUsSpecification getDataFromTable(ref ECUsSpecification es, string colCont1, string cont1, string colCont2, string cont2, string colLeng, int leng)
        {
            query = "SELECT * FROM ECUsSpecification WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }
            return es;
        }
        public static ECUsSpecification getDataFromTable(ref ECUsSpecification es, string col, Dictionary<int, string> searchList)
        {
            int Leng = searchList.Count();

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                for (int i = 0; i < Leng; i++)
                {
                    query = "SELECT * FROM ECUsSpecification WHERE " + col + " = " + searchList[i].ToString() + ";";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            es.ID = int.Parse(reader["ID"].ToString());
                            es.Manufacturer = reader["Manufacturer"].ToString();
                            es.DeviceName = reader["DeviceName"].ToString();
                            es.Type = reader["Type"].ToString();
                            es.BootRef = reader["BootRef"].ToString();
                            es.SoftRef = reader["SoftRef"].ToString();
                            es.Calibration = reader["Calibration"].ToString();
                            es.BinFileName = reader["BinFileName"].ToString();
                            es.BaudRate = reader["BaudRate"].ToString();
                            es.CRC_Address = reader["CRC_Address"].ToString();
                            es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                            es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                            es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                            es.ProductNumber = reader["ProductNumber"].ToString();
                            es.HardwareCode = reader["HardwareCode"].ToString();
                            es.Comment = reader["Comment"].ToString();
                            es.UserID = int.Parse(reader["UserID"].ToString());
                            es.type1Cryption = reader["type1Cryption"].ToString();
                            es.binCryption = reader["binCryption"].ToString();
                            es.crcCryption = reader["crcCryption"].ToString();
                        }
                        con.Close();
                    }
                }


            }
            return es;
        }
        public static AdvanceRemap getDataFromTable(ref AdvanceRemap ar, string getType)
        {
            query = "SELECT * FROM AdvanceRemap WHERE Type = '" + getType + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ar.ID = int.Parse(reader["ID"].ToString());
                        ar.Type = reader["Type"].ToString();
                        ar.TableName = reader["TableName"].ToString();
                        ar.RowsCount = reader["RowsCount"].ToString();
                        ar.ColsCount = reader["ColsCount"].ToString();
                        ar.X_Name = reader["X_Name"].ToString();
                        ar.Y_Name = reader["Y_Name"].ToString();
                        ar.X_Min = reader["X_Min"].ToString();
                        ar.X_Max = reader["X_Max"].ToString();
                        ar.Y_Min = reader["Y_Min"].ToString();
                        ar.Y_Max = reader["Y_Max"].ToString();
                        ar.Address_Start = reader["Address_Start"].ToString();
                        ar.Address_End = reader["Address_End"].ToString();
                        ar.DataSize = reader["DataSize"].ToString();
                        ar.Type_Cryption = reader["Type_Cryption"].ToString();
                        ar.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        ar.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        ar.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        ar.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        ar.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        ar.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        ar.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        ar.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ar;
        }
        public static AdvanceRemap getDataFromTable(ref AdvanceRemap ar, string getType, int getId)
        {
            query = "SELECT * FROM AdvanceRemap WHERE Type = '" + getType + "' AND ID = " + getId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ar.ID = int.Parse(reader["ID"].ToString());
                        ar.Type = reader["Type"].ToString();
                        ar.TableName = reader["TableName"].ToString();
                        ar.RowsCount = reader["RowsCount"].ToString();
                        ar.ColsCount = reader["ColsCount"].ToString();
                        ar.X_Name = reader["X_Name"].ToString();
                        ar.Y_Name = reader["Y_Name"].ToString();
                        ar.X_Min = reader["X_Min"].ToString();
                        ar.X_Max = reader["X_Max"].ToString();
                        ar.Y_Min = reader["Y_Min"].ToString();
                        ar.Y_Max = reader["Y_Max"].ToString();
                        ar.Address_Start = reader["Address_Start"].ToString();
                        ar.Address_End = reader["Address_End"].ToString();
                        ar.DataSize = reader["DataSize"].ToString();
                        ar.Type_Cryption = reader["Type_Cryption"].ToString();
                        ar.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        ar.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        ar.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        ar.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        ar.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        ar.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        ar.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        ar.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return ar;
        }

        public static ECUsSpecification tableContains(ECUsSpecification es, String col, String colValue)
        {
            query = "SELECT * FROM ECUsSpecification WHERE " + col + " = '" + colValue + "';";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.type2Cryption = reader["type2Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return es;
        }
        public static ECUsSpecification tableContains(ECUsSpecification es, String col, String colValue, int defaultId)
        {
            query = "SELECT * FROM ECUsSpecification WHERE " + col + " = '" + colValue + "' AND ID = " + defaultId.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr1))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        es.ID = int.Parse(reader["ID"].ToString());
                        es.Manufacturer = reader["Manufacturer"].ToString();
                        es.DeviceName = reader["DeviceName"].ToString();
                        es.Type = reader["Type"].ToString();
                        es.BootRef = reader["BootRef"].ToString();
                        es.SoftRef = reader["SoftRef"].ToString();
                        es.Calibration = reader["Calibration"].ToString();
                        es.BinFileName = reader["BinFileName"].ToString();
                        es.BaudRate = reader["BaudRate"].ToString();
                        es.CRC_Address = reader["CRC_Address"].ToString();
                        es.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        es.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        es.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        es.ProductNumber = reader["ProductNumber"].ToString();
                        es.HardwareCode = reader["HardwareCode"].ToString();
                        es.Comment = reader["Comment"].ToString();
                        es.UserID = int.Parse(reader["UserID"].ToString());
                        es.type1Cryption = reader["type1Cryption"].ToString();
                        es.type2Cryption = reader["type2Cryption"].ToString();
                        es.binCryption = reader["binCryption"].ToString();
                        es.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }

            return es;
        }

        public static bool insertToTable(ECUsSpecification newRecord)
        {
            bool isAdded = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "INSERT INTO ECUsSpecification([Manufacturer] " +
                    ", [Type], [BootRef], [SoftRef], [Calibration], " +
                    " [ProductNumber], [HardwareCode], [Comment]) VALUES('" +
                    newRecord.Manufacturer + "','" + newRecord.Type + "','" +
                    newRecord.BootRef + "','" + newRecord.SoftRef + "','" +
                    newRecord.Calibration + "','" + newRecord.ProductNumber +
                    "','" + newRecord.HardwareCode + "','" + newRecord.Comment + "');";

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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

            return isAdded;
        }
        public static bool insertToTable(ExistingEcu newRecord)
        {
            bool isAdded = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "INSERT INTO ExistingEcus([Specification_ID] , " +
                "[Connection_ID], [FileName], [Comment]) VALUES(" +
                newRecord.Specification_ID + "," + newRecord.Connection_ID +
                ",'" + newRecord.FileName + "','" + newRecord.Comment + "');";

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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

            return isAdded;
        }
        public static bool insertToTable(History newRecord)
        {
            bool isAdded = false;
            OleDbConnection dbcon = new OleDbConnection(connstr1);
            query = "INSERT INTO History([SpecificationID]) VALUES('" +
                    newRecord.SpecificationID + "');";

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = query;
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

            return isAdded;
        }

        public static DataTable showOnGridView(ECUsSpecification es)
        {
            DataTable Records = new DataTable();
            query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, " +
                    "ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, " + 
                    "ECUsSpecification.Calibration FROM ECUsSpecification";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ExistingEcu ee)
        {
            DataTable Records = new DataTable();
            query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, " + 
                    "ExistingEcus.Connection_ID, ExistingEcus.FileName, " + 
                    "ExistingEcus.Comment FROM ExistingEcus";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Protocol p)
        {
            DataTable Records = new DataTable();
            query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Connection c)
        {
            DataTable Records = new DataTable();
            query = "SELECT Connection.ID, Connection.Protocols_ID, " +
                    "Connection.Pin, Connection.Baudrate, Connection.Header, " +
                    "Connection.Start_Command, Connection.End_Command, " +
                    "Connection.Itteration_Command FROM Connection";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;

        }                    
        public static DataTable showOnGridView(ECUsSpecification es, String colCont, String cont, String colLeng, int leng)
        {
            DataTable Records = new DataTable();

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
                    query += "WHERE InStr(" + colCont + ",'" + cont + "') AND LEN(" + colLeng + ") > " + leng.ToString() + ";";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ExistingEcu ee,       String colCont, String cont, String colLeng, int leng)
        {
            DataTable Records = new DataTable();

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
                    query += "WHERE InStr(" + colCont + ",'" + cont + "') AND LEN(" + colLeng + ") > 0;";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Protocol p,           String colCont, String cont, String colLeng, int leng)
        {
            DataTable Records = new DataTable();

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
                    query += "WHERE InStr(" + colCont + ",'" + cont + "') AND LEN(" + colLeng + ") > 0;";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Connection c,         String colCont, String cont, String colLeng, int leng)
        {
            DataTable Records = new DataTable();

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
                    query += "WHERE InStr(" + colCont + ",'" + cont + "') AND LEN(" + colLeng + ") > 0;";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ECUsSpecification es, String colLeng, int leng, int id1, int id2)
        {
            DataTable Records = new DataTable();
            query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
            query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + colLeng + ") > " + leng.ToString() + " AS ColLen;";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ExistingEcu ee,       String colLeng, int leng, int id1, int id2)
        {
            DataTable Records = new DataTable();
            query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
            query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + colLeng + ") > " + leng.ToString() + " AS ColLen;";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Protocol p,           String colLeng, int leng, int id1, int id2)
        {
            DataTable Records = new DataTable();
            query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
            query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + colLeng + ") > " + leng.ToString() + " AS ColLen;";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Connection c,         String colLeng, int leng, int id1, int id2)
        {
            DataTable Records = new DataTable();
            query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
            query += "WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + colLeng + ") > " + leng.ToString() + " AS ColLen;";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ECUsSpecification es, String colCont1, String cont1, String colCont2, String cont2, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ExistingEcu ee,       String colCont1, String cont1, String colCont2, String cont2, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Protocol p,           String colCont1, String cont1, String colCont2, String cont2, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Connection c,         String colCont1, String cont1, String colCont2, String cont2, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ECUsSpecification es, String colCont1, String cont1, String colCont2, String cont2, String colCont3, String cont3, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, ECUsSpecification.Calibration FROM ECUsSpecification";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND InStr(" + colCont3 + ",'" + cont3 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ExistingEcu ee,       String colCont1, String cont1, String colCont2, String cont2, String colCont3, String cont3, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, ExistingEcus.Connection_ID, ExistingEcus.FileName, ExistingEcus.Comment FROM ExistingEcus";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND InStr(" + colCont3 + ",'" + cont3 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Protocol p,           String colCont1, String cont1, String colCont2, String cont2, String colCont3, String cont3, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND InStr(" + colCont3 + ",'" + cont3 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Connection c,         String colCont1, String cont1, String colCont2, String cont2, String colCont3, String cont3, String colLeng, int leng)
        {
            DataTable Records = new DataTable();
            query = "SELECT Connection.ID, Connection.Protocols_ID, Connection.Pin, Connection.Baudrate, Connection.Header, Connection.Start_Command, Connection.End_Command, Connection.Itteration_Command FROM Connection";
            query += "WHERE InStr(" + colCont1 + ",'" + cont1 + "') AND InStr(" + colCont2 + ",'" + cont2 + "') AND InStr(" + colCont3 + ",'" + cont3 + "') AND LEN(" + colLeng + ") >" + leng.ToString() + ";";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        con.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        Records.Load(reader);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ECUsSpecification es, String col, int[] searchList)
        {
            DataTable Records = new DataTable();
            int Leng = searchList.Count();
            query = "SELECT ECUsSpecification.ID, ECUsSpecification.Manufacturer, " +
                    "ECUsSpecification.Type, ECUsSpecification.BootRef, ECUsSpecification.SoftRef, " +
                    "ECUsSpecification.Calibration FROM ECUsSpecification";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    for (int i = 0; i < Leng; i++)
                    {
                        query += "WHERE " + col + " = " + searchList[i].ToString().Trim() + ";";
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            con.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            Records.Load(reader);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(ExistingEcu ee,       String col, int[] searchList)
        {
            DataTable Records = new DataTable();
            int Leng = searchList.Count();
            query = "SELECT ExistingEcus.ID, ExistingEcus.Specification_ID, " +
                    "ExistingEcus.Connection_ID, ExistingEcus.FileName, " +
                    "ExistingEcus.Comment FROM ExistingEcus";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    for (int i = 0; i < Leng; i++)
                    {
                        query += "WHERE " + col + " = " + searchList[i].ToString().Trim() + ";";
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            con.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            Records.Load(reader);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Protocol p,           String col, int[] searchList)
        {
            DataTable Records = new DataTable();
            int Leng = searchList.Count();
            query = "SELECT Protocols.ID, Protocols.Name FROM Protocols";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    for (int i = 0; i < Leng; i++)
                    {
                        query += "WHERE " + col + " = " + searchList[i].ToString().Trim() + ";";
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            con.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            Records.Load(reader);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }
        public static DataTable showOnGridView(Connection c,         String col, int[] searchList)
        {
            DataTable Records = new DataTable();
            int Leng = searchList.Count();
            query = "SELECT Connection.ID, Connection.Protocols_ID, " +
                    "Connection.Pin, Connection.Baudrate, Connection.Header, " +
                    "Connection.Start_Command, Connection.End_Command, " +
                    "Connection.Itteration_Command FROM Connection";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connstr1))
                {
                    for (int i = 0; i < Leng; i++)
                    {
                        query += "WHERE " + col + " = " + searchList[i].ToString().Trim() + ";";
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            con.Open();
                            OleDbDataReader reader = cmd.ExecuteReader();
                            Records.Load(reader);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Error:" + ex.Message);
            }

            return Records;
        }

        public static String[] readFromJoinedTables(String table1, String table2, String col1, String col2)
        {
            string Query = "";
            string[] Record = new string[7];
            Query = "SELECT * FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + ".[" + col1 + "] = " + table2 + ".[" + col2 + "];";

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