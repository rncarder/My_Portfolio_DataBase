using AHS.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Text;
namespace AHSDataEntry
{
    internal class UIHelper
    {
        public static void UiCleaner(Control.ControlCollection controls, Color lblColor)
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
                if(c is Label lbl)
                {
                    lbl.BackColor = lblColor;
                }
                if (c.HasChildren) { UiCleaner(c.Controls, lblColor); }
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
        public static void SetComboBox(ComboBox cb, IEnumerable<AHSDb.Model> modList)
        {
            cb.DataSource = null;
            cb.DataSource = modList;
            cb.DisplayMember = "Name";
            cb.SelectedIndex = -1;
            cb.BindingContext = new BindingContext();
        }
        public static void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        public static void Alpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

