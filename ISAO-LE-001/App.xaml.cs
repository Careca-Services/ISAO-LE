using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using S7.Net;

namespace ISAO_LE_001
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static public bool diag_status;
        static Plc plc;
        


        public App()//!< Detailed description after the member
        {
            
        }




        static public bool Connexion(CpuType type,string ip,short rack,short slot)
        {
            plc = new Plc(type, ip, rack, slot);
            if (plc.IsAvailable)
            {
                
                plc.Open();
                if (plc.IsConnected) return true;
                else
                {
                    MessageBox.Show("API connexion echoué, verifier la configuration", "Erreur API", MessageBoxButton.OK);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("API no disponible, verifier l'adresse ip", "Erreur API", MessageBoxButton.OK);
                return false;
                

            }

            
           

        }

        static public object LectureDataBytes(DataType dtype,int db,int start,int nb)
        {
            var data = plc.Read(dtype, db, start, VarType.Byte, nb);
            return data;
            

        }

        static public object LectureVar(string v)
        {
            return plc.Read(v);
        }

        static public bool PlcOnline()
        {
            bool resp = (plc != null) ?plc.IsConnected : false;
            return resp;
        }

        static public void PlcClose()
        {
            plc.Close();
        }


        

    }
}
