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
        public static object TextBoxCheck(string s, bool isNullable, bool isInt)
        {
            int returnResult;
            if (int.TryParse(s, out returnResult))
            {
                if (isInt) { return returnResult; }
                else { return null; }
            }
            if (isNullable && string.IsNullOrEmpty(s)) { return null; }
            if(!string.IsNullOrWhiteSpace(s) && !isInt) { return AHSProvider.ToUpperCase(s); }
            
            
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

