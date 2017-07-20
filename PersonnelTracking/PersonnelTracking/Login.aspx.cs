using PersonnelTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonnelTracking
{
    public partial class Login : System.Web.UI.Page
        
    {
        PersonnelPermitTrackingEntities db = new PersonnelPermitTrackingEntities();
         
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string firstName = firstname.Text.ToString();
            string lastName = lastname.Text.ToString();
            string phoneNumber = phonenumber.Text.ToString();
            string Address = address.Text.ToString();
            int totalPermit = int.Parse(totalpermit.Text.ToString());

            Personnel per = new Personnel() {
                firstname = firstName,
                lastname = lastName,
                phonenumber = phoneNumber,
                address = Address,
                totalpermit = totalPermit,
                usedpermit = 0
            };
            db.Personnels.Add(per);
            db.SaveChanges();
            Response.Redirect("Usage.aspx");
        }
    }
}