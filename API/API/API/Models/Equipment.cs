using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Equipment
    {
        string name { get; set; }
        int Id { get; set; }
        string requiredSKill { get; set; }

        public void checkIn()
        {
            /*
            for (int i = 0; i < dtRec.Rows.Count; i++)
            {
                DataRow recRow = dtRec.Rows[i];
                if (recRow[0].ToString() == "Contact Vibration Specialist")
                {
                    count--;
                    if (count > 0)
                    {
                        recRow[0] = string.Empty;
                        recRow.Delete();
                        dtRec.AcceptChanges();
                    }
                }
            }
            */

            //todo: check this tool in - *****will this work for checkin process?*******
            throw new NotImplementedException();
        }

        public void checkOut()
        {
            /*
            DataTable dt = ...;
            DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(toInsert, index);
             */
            //todo: check this tool out
            throw new NotImplementedException();
        }
    }
}
