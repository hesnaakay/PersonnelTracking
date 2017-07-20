using PersonnelTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonnelTracking
{
    public partial class Usage : System.Web.UI.Page
    {
        static PersonnelPermitTrackingEntities db = new PersonnelPermitTrackingEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static PersonnelModel[] GetPersonnels(string data)
        {
            List<PersonnelModel> personel = new List<PersonnelModel>();

            personel = db.Personnels.Select(p => new PersonnelModel()
            {
                id = p.id,
                firstname = p.firstname,
                lastname = p.lastname,
                phonenumber = p.phonenumber,
                address = p.address,
                totalpermit = p.totalpermit,
                usedpermit = p.usedpermit
            }).ToList();
            return personel.ToArray();
        }
        [System.Web.Services.WebMethod]
        public static PersonnelPermitModel[] GetPersonnel(int data)
        {
            List<PersonnelPermitModel> personelpermit = new List<PersonnelPermitModel>();
            int date = getUsedDate(data);
            var personel = db.Personnels.Where(p => p.id == data).FirstOrDefault();

            personelpermit = db.Permits.Where(p => p.personnel_id == data).ToList().Select(p => new PersonnelPermitModel()
            {
                id = p.id,
                firstname = personel.firstname,
                lastname = personel.lastname,
                startingdate = p.startingdate.ToShortDateString(),
                duedate = p.duedate.ToShortDateString()
            }).ToList();


            return personelpermit.ToArray();
        }

        private static int getUsedDate(int data)
        {
             var control = db.Personnels.ToList().Where(p => p.id == data).FirstOrDefault();
            if(control.usedpermit != 0){
            var permit_start = db.Permits.Where(p => p.personnel_id == data).FirstOrDefault().startingdate;
            var permit_end = db.Permits.Where(p => p.personnel_id == data).FirstOrDefault().duedate;
            int permit_used = control.usedpermit;
            int total = permit_used + (permit_end - permit_start).Days;
            return total;
            }
            else
            {
                return 0;
            }
        }
        [System.Web.Services.WebMethod]
        public static int SavePermit(int id, string startdate, string duedate)
        {
            bool ctrl = controlDate(id, startdate,duedate);
            if (!ctrl)
            {
                return -1;
            }
            try
            {
                db.Permits.Add(new Permit()
                {
                    startingdate = DateTime.Parse(startdate),
                    duedate = DateTime.Parse(duedate),
                    personnel_id = id
                });

                db.SaveChanges();
                var result = db.Personnels.Where(p => p.id == id).FirstOrDefault().usedpermit;
                return result;
            }
            catch(Exception)
            {
                return -1;
            }
            
        }

        private static bool controlDate(int id, string startdate, string duedate)
        {
            int clclt = 0;
            bool result = false;
            int totalpermit = db.Personnels.Where(p => p.id == id).FirstOrDefault().totalpermit;
            var usedpermit = db.Personnels.Where(p => p.id == id).FirstOrDefault().usedpermit;
            if (startdate != "" && duedate != "")
            {
                clclt = (DateTime.Parse(duedate) - DateTime.Parse(startdate)).Days;
                result = compareDate(id, startdate, duedate);
            }
            if (result && (totalpermit >= (usedpermit + clclt)))
            {
                int addValue = usedpermit + clclt;
                var data = db.Personnels.Where(p => p.id == id).FirstOrDefault();
                data.usedpermit = addValue;
                db.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }

        private static bool compareDate(int id, string startdate, string duedate)
        {
            var data = db.Permits.ToList().Where(p => p.personnel_id == id && (p.startingdate <= DateTime.Parse(startdate) && p.duedate >= DateTime.Parse(duedate)) || (p.startingdate >= DateTime.Parse(startdate) && p.duedate <= DateTime.Parse(duedate)) || (p.startingdate <= DateTime.Parse(startdate) && p.duedate >= DateTime.Parse(startdate)) || (p.startingdate <= DateTime.Parse(duedate) && p.duedate >= DateTime.Parse(duedate))).ToList();
            if (data.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}