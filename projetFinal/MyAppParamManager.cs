 
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using Microsoft.Win32;  

namespace projetFinal  
{  
    public class MyAppParamManager  
    {  
        string CheminRegistre = @"SOFTWARE\GestionRestaurant";

        public void SaveRegistryParameter(string keyName, string value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(CheminRegistre))
            {
                key.SetValue(keyName, value);
            }
        }

        public string LoadRegistryParameter(string keyName, string defaultValue)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(CheminRegistre))
            {
                return key?.GetValue(keyName)?.ToString() ?? defaultValue;
            }
        }
    }  
}  
