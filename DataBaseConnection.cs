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
        //                                                  ECUsSpecification Functions                                      
        // FirstOrDefault() For ECUsSpecification Table
        public static ECUsSpecification ES_FirstOrDefault(int DefaultID)
        {
            ECUsSpecification Record = new ECUsSpecification();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM ECUsSpecification WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }
        public static ECUsSpecification ES_FirstOrDefault(string DefaultBootRef)
        {
            ECUsSpecification Record = new ECUsSpecification();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM ECUsSpecification WHERE BootRef = '" + DefaultBootRef + "';";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }
        public static ECUsSpecification ES_FirstOrDefault(string Col1, string ColVal1, string Col2, string ColVal2, string Col3, string ColVal3, string Col4, string ColVal4, string Col5, string ColVal5, string Col6, string ColVal6)
        {
            ECUsSpecification Record = new ECUsSpecification();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM ECUsSpecification WHERE " + Col1 + " = '" + ColVal1 + "' OR" + Col2 + " = '" + ColVal2 + "' OR" + Col3 + " = '" + ColVal3 + "' OR" + Col4 + " = '" + ColVal4 + "' OR" + Col5 + " = '" + ColVal5 + "' OR" + Col6 + " = '" + ColVal6 + "' OR 1=1;";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }

        // Get Data From ECUsSpecification Table Where The Coloumn
        // Contains A Specific Value
        public static ECUsSpecification ES_Contains(string Col, string ColValue)
        {
            ECUsSpecification Record = new ECUsSpecification();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM ECUsSpecification WHERE " + Col + " = '" + ColValue + "';", con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.type2Cryption = reader["type2Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }
        public static ECUsSpecification ES_Contains(string Col, string ColValue, int DefaultID)
        {
            ECUsSpecification Record = new ECUsSpecification();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM ECUsSpecification WHERE " + Col + " = '" + ColValue + "' AND ID = " + DefaultID.ToString() + ";", con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.type2Cryption = reader["type2Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }

        // Count The Number Of Records In ECUsSpecification Table
        public static int CountInECUsSpecification(int CountID)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE ID = " + CountID.ToString() + "';", con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInECUsSpecification(string Col, string ColValue)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE " + Col + " = '" + ColValue + "';", con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInECUsSpecification(string Col, int Leng, int id)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE ID = " + id.ToString() + "AND LEN(" + Col + ") > " + Leng.ToString() + ";", con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }
        public static int CountInECUsSpecification(string Col, int Leng, int id1, int id2)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + Col + ") > " + Leng.ToString() + " AS ColLen;";

            using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static int CountInECUsSpecification(int id1, int id2, int id3, int id4)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE ID = " + id1.ToString() + " OR ID = " + id2.ToString() + " OR ID = " + id3.ToString() + " OR ID = " + id4.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static int CountInECUsSpecification(string ColCont1, string Cont1, string ColCont2, string Cont2, string ColLeng, int Leng)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;
            string Query = "SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static int CountInECUsSpecification(string Col, Dictionary<int, string> SearchList)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;
            int Leng = SearchList.Count;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                for (int i = 0; i < Leng; i++)
                {
                    string Query = "SELECT COUNT(*) AS NumberOfECUs FROM ECUsSpecification WHERE " + Col + " = " + SearchList[i].ToString() + ";";
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

        // Get Data From ECUsSpecification Table In A Specific Condition
        public static ECUsSpecification GetDataFromECUsSpecification(string Col, int Leng, int id)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string query = "";
            ECUsSpecification Record = new ECUsSpecification();

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                query = "SELECT * FROM ECUsSpecification WHERE ID = " + id.ToString() + " AND Len(" + Col + ") >" + Leng.ToString() + ";";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }
            return Record;
        }
        public static ECUsSpecification GetDataFromECUsSpecification(string Col, int Leng, int id1, int id2)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string query = "";
            ECUsSpecification Record = new ECUsSpecification();

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                query = "SELECT * FROM ECUsSpecification WHERE (ID = " + id1.ToString() + " OR ID = " + id2.ToString() + ") AND Len(" + Col + ") > " + Leng.ToString() + ";";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }
            return Record;
        }
        public static ECUsSpecification GetDataFromECUsSpecification(int id1, int id2, int id3, int id4)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string query = "";
            ECUsSpecification Record = new ECUsSpecification();

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                query = "SELECT * FROM ECUsSpecification WHERE ID = " + id1.ToString() + " OR ID = " + id2.ToString() + " OR ID = " + id3.ToString() + " OR ID = " + id4.ToString() + ";";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }
            return Record;
        }
        public static ECUsSpecification GetDataFromECUsSpecification(string ColCont1, string Cont1, string ColCont2, string Cont2, string ColLeng, int Leng)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            ECUsSpecification Record = new ECUsSpecification();

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                Query = "SELECT * FROM ECUsSpecification WHERE InStr(" + ColCont1 + ",'" + Cont1 + "') AND InStr(" + ColCont2 + ",'" + Cont2 + "') AND LEN(" + ColLeng + ") >" + Leng.ToString() + ";";
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Manufacturer = reader["Manufacturer"].ToString();
                        Record.DeviceName = reader["DeviceName"].ToString();
                        Record.Type = reader["Type"].ToString();
                        Record.BootRef = reader["BootRef"].ToString();
                        Record.SoftRef = reader["SoftRef"].ToString();
                        Record.Calibration = reader["Calibration"].ToString();
                        Record.BinFileName = reader["BinFileName"].ToString();
                        Record.BaudRate = reader["BaudRate"].ToString();
                        Record.CRC_Address = reader["CRC_Address"].ToString();
                        Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                        Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                        Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                        Record.ProductNumber = reader["ProductNumber"].ToString();
                        Record.HardwareCode = reader["HardwareCode"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                        Record.UserID = int.Parse(reader["UserID"].ToString());
                        Record.type1Cryption = reader["type1Cryption"].ToString();
                        Record.binCryption = reader["binCryption"].ToString();
                        Record.crcCryption = reader["crcCryption"].ToString();
                    }
                    con.Close();
                }

            }
            return Record;
        }
        public static ECUsSpecification GetDataFromECUsSpecification(string Col, Dictionary<int,string> SearchList)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            ECUsSpecification Record = new ECUsSpecification();
            int Leng = SearchList.Count();

            using (OleDbConnection con = new OleDbConnection(connstr))
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
                            Record.ID = int.Parse(reader["ID"].ToString());
                            Record.Manufacturer = reader["Manufacturer"].ToString();
                            Record.DeviceName = reader["DeviceName"].ToString();
                            Record.Type = reader["Type"].ToString();
                            Record.BootRef = reader["BootRef"].ToString();
                            Record.SoftRef = reader["SoftRef"].ToString();
                            Record.Calibration = reader["Calibration"].ToString();
                            Record.BinFileName = reader["BinFileName"].ToString();
                            Record.BaudRate = reader["BaudRate"].ToString();
                            Record.CRC_Address = reader["CRC_Address"].ToString();
                            Record.ConnectionID = int.Parse(reader["ConnectionID"].ToString());
                            Record.Type1_AddressRemap = reader["Type1_AddressRemap"].ToString();
                            Record.Type2_TableRemap = reader["Type2_TableRemap"].ToString();
                            Record.ProductNumber = reader["ProductNumber"].ToString();
                            Record.HardwareCode = reader["HardwareCode"].ToString();
                            Record.Comment = reader["Comment"].ToString();
                            Record.UserID = int.Parse(reader["UserID"].ToString());
                            Record.type1Cryption = reader["type1Cryption"].ToString();
                            Record.binCryption = reader["binCryption"].ToString();
                            Record.crcCryption = reader["crcCryption"].ToString();
                        }
                        con.Close();
                    }
                }
                

            }
            return Record;
        }

        // Update ECUsSpecification Table
        public static bool UpdateECUsSpecification(ECUsSpecification New_Value)
        {
            bool isUpdated = false;
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

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

        // Delete Item From ECUsSpecification Table
        public static bool DeleteFromECUsSpecification(int DeleteID)
        {
            bool isDeleted = false;
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "DELETE FROM ECUsSpecification WHERE ID = " + DeleteID.ToString();
                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }
            return isDeleted;
        }


        //                                                  AdvanceRemap Functions                                           
        // FirstOrDefault() For AdvanceRemap Table
        public static AdvanceRemap AR_FirstOrDefault()
        {
            AdvanceRemap Record = new AdvanceRemap();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM AdvanceRemap;";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Type = reader["Type"].ToString();
                        Record.TableName = reader["TableName"].ToString();
                        Record.RowsCount = reader["RowsCount"].ToString();
                        Record.ColsCount = reader["ColsCount"].ToString();
                        Record.X_Name = reader["X_Name"].ToString();
                        Record.Y_Name = reader["Y_Name"].ToString();
                        Record.X_Min = reader["X_Min"].ToString();
                        Record.X_Max = reader["X_Max"].ToString();
                        Record.Y_Min = reader["Y_Min"].ToString();
                        Record.Y_Max = reader["Y_Max"].ToString();
                        Record.Address_Start = reader["Address_Start"].ToString();
                        Record.Address_End = reader["Address_End"].ToString();
                        Record.DataSize = reader["DataSize"].ToString();
                        Record.Type_Cryption = reader["Type_Cryption"].ToString();
                        Record.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        Record.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        Record.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        Record.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        Record.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        Record.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        Record.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        Record.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }
 

        // Get TableName, RowsCount And ColsCount From AdvanceRemap Table
        public static AdvanceRemap GetDataFromAdvanceRemap(string GetType)
        {
            AdvanceRemap Record = new AdvanceRemap();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM AdvanceRemap WHERE Type = '" + GetType + "';";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Type = reader["Type"].ToString();
                        Record.TableName = reader["TableName"].ToString();
                        Record.RowsCount = reader["RowsCount"].ToString();
                        Record.ColsCount = reader["ColsCount"].ToString();
                        Record.X_Name = reader["X_Name"].ToString();
                        Record.Y_Name = reader["Y_Name"].ToString();
                        Record.X_Min = reader["X_Min"].ToString();
                        Record.X_Max = reader["X_Max"].ToString();
                        Record.Y_Min = reader["Y_Min"].ToString();
                        Record.Y_Max = reader["Y_Max"].ToString();
                        Record.Address_Start = reader["Address_Start"].ToString();
                        Record.Address_End = reader["Address_End"].ToString();
                        Record.DataSize = reader["DataSize"].ToString();
                        Record.Type_Cryption = reader["Type_Cryption"].ToString();
                        Record.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        Record.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        Record.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        Record.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        Record.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        Record.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        Record.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        Record.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return Record;
        }
        public static AdvanceRemap GetDataFromAdvanceRemap(string GetType, int GetID)
        {
            AdvanceRemap Record = new AdvanceRemap();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM AdvanceRemap WHERE Type = '" + GetType + "' AND ID = " + GetID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Type = reader["Type"].ToString();
                        Record.TableName = reader["TableName"].ToString();
                        Record.RowsCount = reader["RowsCount"].ToString();
                        Record.ColsCount = reader["ColsCount"].ToString();
                        Record.X_Name = reader["X_Name"].ToString();
                        Record.Y_Name = reader["Y_Name"].ToString();
                        Record.X_Min = reader["X_Min"].ToString();
                        Record.X_Max = reader["X_Max"].ToString();
                        Record.Y_Min = reader["Y_Min"].ToString();
                        Record.Y_Max = reader["Y_Max"].ToString();
                        Record.Address_Start = reader["Address_Start"].ToString();
                        Record.Address_End = reader["Address_End"].ToString();
                        Record.DataSize = reader["DataSize"].ToString();
                        Record.Type_Cryption = reader["Type_Cryption"].ToString();
                        Record.TableName_Cryption = reader["TableName_Cryption"].ToString();
                        Record.RowsCount_Cryption = reader["RowsCount_Cryption"].ToString();
                        Record.ColsCount_Cryption = reader["ColsCount_Cryption"].ToString();
                        Record.X_Name_Cryption = reader["X_Name_Cryption"].ToString();
                        Record.Y_Name_Cryption = reader["Y_Name_Cryption"].ToString();
                        Record.Address_Start_Cryption = reader["Address_Start_Cryption"].ToString();
                        Record.Address_End_Cryption = reader["Address_End_Cryption"].ToString();
                        Record.DataSize_Cryption = reader["DataSize_Cryption"].ToString();
                    }
                    con.Close();
                }
            }

            return Record;
        }

        // Count The Number Of Records In AdvanceRemap Table
        public static int CountInAdvanceRemap(string Col, string ColValue)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) AS NumberOfECUs FROM AdvanceRemap WHERE " + Col + " = '" + ColValue + "';", con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }


        //                                                  ExistingEcus Functions                                           
        // FirstOrDefault() For ExistingEcus Table

        // Update ExistingEcus Table
        public static bool UpdateExistingEcus(ExistingEcu New_Value)
        {
            bool isUpdated = false;
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

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
        public static ExistingEcu EE_FirstOrDefault(int DefaultID)
        {
            ExistingEcu Record = new ExistingEcu();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM ExistingEcus WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Specification_ID = int.Parse(reader["Specification_ID"].ToString());
                        Record.Connection_ID = int.Parse(reader["ConnectionID"].ToString());
                        Record.FileName = reader["FileName"].ToString();
                        Record.Comment = reader["Comment"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }

        // Delete Item From ExistingEcus Table
        public static bool DeleteFromExistingEcus(int DeleteID)
        {
            bool isDeleted = false;
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

            try
            {
                OleDbCommand cmd = dbcon.CreateCommand();
                dbcon.Open();
                cmd.CommandText = "DELETE FROM ExistingEcus WHERE ID = " + DeleteID.ToString();
                cmd.Connection = dbcon;
                cmd.ExecuteNonQuery();
                dbcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Error:" + ex.Message);
            }
            return isDeleted;
        }


        //                                                  DefaultLanguage Functions                                        
        // FirstOrDefault() For DefaultLanguage Table
        public static DefaultLanguage DL_FirstOrDefault(int DefaultID)
        {
            DefaultLanguage Record = new DefaultLanguage();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM DefaultLanguage WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.lang = reader["lang"].ToString();
                    }
                    con.Close();
                }
            }

            return Record;
        }

        // Update DefaultLanguage Table
        public static bool UpdateDefaultLanguage(DefaultLanguage New_Value)
        {
            bool isUpdated = false;
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

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


        //                                                  History Functions                                                
        // FirstOrDefault() For History Table
        public static History HR_FirstOrDefault(int DefaultID)
        {
            History Record = new History();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM History WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.SpecificationID = int.Parse(reader["SpecificationID"].ToString());
                    }
                    con.Close();
                }
            }
            return Record;
        }
        public static History HR_FirstOrDefault()
        {
            History Record = new History();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM History;";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.SpecificationID = int.Parse(reader["SpecificationID"].ToString());
                    }
                    con.Close();
                }
            }
            return Record;
        }

        // Count The Number Of Records In History Table
        public static int CountInHistory()
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            int NumberOfECUs = 0;

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) AS NumberOfECUs FROM History", con))
                {
                    con.Open();
                    NumberOfECUs = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return NumberOfECUs;
        }

        // Update History Table
        public static bool UpdateHistory(History New_Value)
        {
            bool isUpdated = false;
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

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

        //                                                  Connection Functions                                             
        public static Connection CO_FirstOrDefault(int DefaultID)
        {
            Connection Record = new Connection();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM Connection WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Protocols_ID = int.Parse(reader["Protocols_ID"].ToString());
                        Record.Pin = int.Parse(reader["Pin"].ToString());
                        Record.Baudrate = int.Parse(reader["Baudrate"].ToString());
                        Record.Header = reader["Header"].ToString();
                        Record.Start_Command = reader["Start_Command"].ToString();
                        Record.End_Command = reader["End_Command"].ToString();
                        Record.Itteration_Command = reader["Itteration_Command"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }


        //                                                  Protocols Functions                                              
        public static Protocol PR_FirstOrDefault(int DefaultID)
        {
            Protocol Record = new Protocol();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";

            Query = "SELECT * FROM Protocols WHERE ID = " + DefaultID.ToString() + ";";

            using (OleDbConnection con = new OleDbConnection(connstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, con))
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record.ID = int.Parse(reader["ID"].ToString());
                        Record.Name = reader["Protocol Name"].ToString();
                    }
                    con.Close();
                }
            }
            return Record;
        }


        //                                                  Common Functions                                                 
        // Add Mew Item To The Given Table
        public static bool AddToDatabase(string tbName, string[] New_Record)
        {
            bool isAdded = false;
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = E:/User/work/Remap/source - Developing/ProMap 20190911(Ver 1)- Source/67 ProMap 991107 zarvan v5.2.0/ProMap/PromapDatabase.mdb";
            OleDbConnection dbcon = new OleDbConnection(constr);

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
        public static DataTable ShowOnGridView(string tbName)
        {
            DataTable dtECUs = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
               
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static DataTable ShowOnGridView(string tbName, string ColCont, string Cont, string ColLeng, int Leng)
        {
            DataTable dtECUs = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static DataTable ShowOnGridView(string tbName, string ColLeng, int Leng, int id1, int id2)
        {
            DataTable dtECUs = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static DataTable ShowOnGridView(string tbName, string ColCont1, string Cont1, string ColCont2, string Cont2, string ColLeng, int Leng)
        {
            DataTable dtECUs = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static DataTable ShowOnGridView(string tbName, string ColCont1, string Cont1, string ColCont2, string Cont2, string ColCont3, string Cont3, string ColLeng, int Leng)
        {
            DataTable dtECUs = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static DataTable ShowOnGridView(string tbName, string Col, int[] SearchList)
        {
            DataTable dtECUs = new DataTable();
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            int Leng = SearchList.Count();

            switch (tbName)
            {
                // Show ECUsSpecification In Datagridview
                case "ECUsSpecification":
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
                        using (OleDbConnection con = new OleDbConnection(connstr))
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
        public static string[] ReadFromESJoinEE(string ES_Col, string EE_Col)
        {
            string connstr = ConfigurationManager.ConnectionStrings["ProMapAccessDB"].ConnectionString;
            string Query = "";
            string[] Record = new string[7];

            Query = "SELECT * FROM ECUsSpecification INNER JOIN ExistingEcus ON ECUsSpecification.[" + ES_Col + "] = ExistingEcus.[" + EE_Col + "];";

            using (OleDbConnection con = new OleDbConnection(connstr))
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