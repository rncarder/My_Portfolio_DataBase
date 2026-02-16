using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AHS.Core;
using System.Reflection.Metadata.Ecma335;
namespace AHSDataEntry
{
    internal class UIHelper
    {
        public static void UiCleaner(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox t)
                {
                    t.Text = "";
                }
                else if (c is ComboBox cb)
                {
                    cb.SelectedIndex = -1;
                }

                if (c.HasChildren) { UiCleaner(c.Controls); }
            }
        }
        public static bool AntiDoops(string q, List<string> userInputs)
        {
            DataSet ds = new DataSet();
            //string q = AHSProvider.SelectQueryString(table, columns.Where(i => i != "Id").ToList());
            using (SqlConnection conn = new SqlConnection(AHSProvider.ConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for(int c =0; c < reader.FieldCount; c++)
                            {
                                string colName = reader.GetName(c);
                                for(int i = 0; i < userInputs.Count; i++)
                                {
                                    if (reader[c] is int)
                                    {
                                        int x;
                                        
                                        if (int.TryParse(userInputs[i], out x))
                                        {
                                            if ((int)reader[c] == x)
                                            {
                                                MessageBox.Show($"{userInputs[i]} is already a value in {colName}");
                                                return true;
                                            }
                                        }
                                        
                                    }
                                    if(reader[c] is string)
                                    {
                                        if (reader[c].ToString().Equals(userInputs[i]))
                                        {
                                            MessageBox.Show($"{userInputs[i]} is already a Value in {colName}");
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                        return false;
                    }
                    
                }
                
 
                
            }
        }
        public static object TextBoxCheck(string s, bool isNullable, bool isInt)
        {
            int returnResult;
            if (int.TryParse(s, out returnResult))
            {
                if (isInt) { return returnResult; }
                else { return null; }
            }
            if (isNullable && string.IsNullOrEmpty(s)) { return null; }
            if(!string.IsNullOrWhiteSpace(s) && !isInt) { return s; }
            
            
            return null;

        }
        public static bool ComboBoxCheck(int cmbIndex, bool isNullable)
        {
            
            if(cmbIndex < 0 && isNullable) { return true; }
            if(cmbIndex < 0) { return false; }
            return true;
        }
    }
}

