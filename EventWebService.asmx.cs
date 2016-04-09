using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace ProjectServiceApp
{
    /// <summary>
    /// Summary description for EventWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EventWebService : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;


        /// <summary>
        /// To Check UserLogin
        /// </summary>
        /// <param name="EmailID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebMethod(Description = "To Check UserLogin")]
        public DataSet CheckUserLogin(string EmailID,string Password)
        {
            da = new SqlDataAdapter("select * from userinfo WHERE gmail = @Email and password = @Pass", con);
            da.SelectCommand.Parameters.AddWithValue("@Email", EmailID);
            da.SelectCommand.Parameters.AddWithValue("@Pass", Password);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// To REgister New User
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Gender"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="ProfileImageName"></param>
        /// <returns></returns>
        [WebMethod(Description = "To Register the user")]
        public string RegNewUser(string FirstName,string LastName,string Gender,string Email,string Password,string ProfileImageName)
        {
            cmd = new SqlCommand("insert into userinfo values(@Fname,@Lname,@Gender ,@Email, @Pass,'1',@Profile)",con);
            cmd.Parameters.AddWithValue("@Fname",FirstName);
            cmd.Parameters.AddWithValue("@Lname", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Pass", Password);
            cmd.Parameters.AddWithValue("@Profile",ProfileImageName);
            string Status = "";
            con.Open();
            Status=cmd.ExecuteNonQuery().ToString();
            con.Close();
            if (Status == "")
            {
                return "There should be some problem";            
            }
            else
            {
                return "Registered Successfully";
            }
        }

        /// <summary>
        /// sportview- Retrive the data of cricket event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the events of cricket")]
        public DataSet GetCricketEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Cricket'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Football event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the events of football")]
        public DataSet GetFootballEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Football'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Swimming event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the events of swimming")]
        public DataSet GetSwimminglEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Swimming'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Basketball event
        /// </summary>
        /// <returns></returns>
        [WebMethod (Description="To get the events of basketball")]
        public DataSet GetBasketballEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Basketball'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Intercollage Competition event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the intercollage events")]
        public DataSet GetIntercollageCompetitionEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Intercollage Competition'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Government event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the government events")]
        public DataSet GetGovernmentEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Government'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Conference event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the conference events")]
        public DataSet GetConferenceEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Conference'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        /// <summary>
        /// sportview- Retrive the data of Workshop event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the workshop events")]
        public DataSet GetWorkshopEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Workshop'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Art event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the Art events")]
        public DataSet GetArtEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Art'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Dance event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the dance event")]
        public DataSet GetDanceEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Dance'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Concert event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the concert event")]
        public DataSet GetConcertEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Concert'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// sportview- Retrive the data of Jobfair event
        /// </summary>
        /// <returns></returns>
        [WebMethod(Description = "To get the jobFair event")]
        public DataSet GetJobfairEvents()
        {
            da = new SqlDataAdapter("select profile,eventimg,eventdate,eventcountry,eventvenue,eventwebsite from event WHERE eventcategory='Jobfair'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        [WebMethod(Description = "to get the event info")]
        public DataSet GetEventInfoEvents(string WebSiteName)
        {
            da = new SqlDataAdapter("select * from event WHERE eventwebsite = @WebSite", con);
            da.SelectCommand.Parameters.AddWithValue("@WebSite", WebSiteName);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



        /// <summary>
        /// Update the data  from user info
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Gender"></param>
        /// <param name="Email"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="AboutMe"></param>
        /// <param name="Industry"></param>
        /// <param name="Designation"></param>
        /// <param name="Organization"></param>
        /// <param name="Interest"></param>
        /// <param name="Website"></param>
        /// <param name="strFB"></param>
        /// <param name="strTwitter"></param>
        /// <param name="ProfileImageName"></param>
        /// <returns></returns>
        [WebMethod(Description = "To update the user information")]
        public string UpdateUserProfile(string FirstName, string LastName, string Gender, string Email, DateTime DateOfBirth,string Country,string City,string AboutMe,string Industry,string Designation,string Organization,string Interest,string Website,string strFB,string strTwitter, string ProfileImageName)
        {
            cmd = new SqlCommand("update userprofile set fname=@Fname,lname=@Lname,gender=@Gender,gmail=@Email,dateofbirth=@DOB,country=@Country,city=@City,aboutme=@About,industry=@Industry,designation=@Desig,organization=@Org,interest=@Interest,website=@WebSite,facebook=@FB,twitter=@TW,userimg=@Profile where gmail=@Email", con);
            cmd.Parameters.AddWithValue("@Fname", FirstName);
            cmd.Parameters.AddWithValue("@Lname", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@About", AboutMe);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Desig", Designation);
            cmd.Parameters.AddWithValue("@Org", Organization);
            cmd.Parameters.AddWithValue("@Intesert", Interest);
            cmd.Parameters.AddWithValue("@WebSite",Website);
            cmd.Parameters.AddWithValue("@FB", strFB);
            cmd.Parameters.AddWithValue("@TW", strTwitter);
            cmd.Parameters.AddWithValue("@Profile", ProfileImageName);
            string Status = "";
            con.Open();
            Status = cmd.ExecuteNonQuery().ToString();
            con.Close();
            if (Status == "")
            {
                return "There should be some problem";
            }
            else
            {
                return "Updated Successfully";
            }
        }

        /// <summary>
        /// Retrive the data  from user info 
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        [WebMethod(Description = "To check the user information")]
        public string GetEmail(string EmailID)
        {
            da = new SqlDataAdapter("select gmail from userprofile WHERE gmail=@Email", con);
            da.SelectCommand.Parameters.AddWithValue("@Email", EmailID);
            ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables.Count>0)
            {
                return ds.Tables[0].Rows[0]["gmail"].ToString();
            }
            else
            {
                return "Email Not Found";
            }
        }

        
        /// <summary>
        /// insert the data of to userprofile
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Gender"></param>
        /// <param name="Email"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="AboutMe"></param>
        /// <param name="Industry"></param>
        /// <param name="Designation"></param>
        /// <param name="Organization"></param>
        /// <param name="Interest"></param>
        /// <param name="Website"></param>
        /// <param name="strFB"></param>
        /// <param name="strTwitter"></param>
        /// <param name="ProfileImageName"></param>
        /// <returns></returns>
        [WebMethod(Description = "To insert the user information")]
        public string AddToUserProfile(string FirstName, string LastName, string Gender, string Email, DateTime DateOfBirth, string Country, string City, string AboutMe, string Industry, string Designation, string Organization, string Interest, string Website, string strFB, string strTwitter, string ProfileImageName)
        {
            cmd = new SqlCommand("insert into userprofile values(@Fname,@Lname,@Gender,@Email,@DOB,@Country,@City,@About,@Industry,@Desig,@Org,@Interest,@WebSite,@FB,@TW,@UImg)", con);
            cmd.Parameters.AddWithValue("@Fname", FirstName);
            cmd.Parameters.AddWithValue("@Lname", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DOB", DateOfBirth);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@About", AboutMe);
            cmd.Parameters.AddWithValue("@Industry", Industry);
            cmd.Parameters.AddWithValue("@Desig", Designation);
            cmd.Parameters.AddWithValue("@Org", Organization);
            cmd.Parameters.AddWithValue("@Intesert", Interest);
            cmd.Parameters.AddWithValue("@WebSite", Website);
            cmd.Parameters.AddWithValue("@FB", strFB);
            cmd.Parameters.AddWithValue("@TW", strTwitter);
            cmd.Parameters.AddWithValue("@UImg", ProfileImageName);
            string Status = "";
            con.Open();
            Status = cmd.ExecuteNonQuery().ToString();
            con.Close();
            if (Status == "")
            {
                return "There should be some problem";
            }
            else
            {
                return "Added Successfully";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        [WebMethod(Description = "To get the basic information of user")]
        public DataSet GetUserDataFromProfile(string EmailID)
        {
            da = new SqlDataAdapter("select userimg,fname,lname,gmail from userprofile WHERE gmail=@Email", con);
            da.SelectCommand.Parameters.AddWithValue("@Email", EmailID);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod(Description = "To get the professional information of user")]
        public DataSet GetIndustryDataFromProfile(string EmailID)
        {
            da = new SqlDataAdapter("select industry,designation,organization,interest,website from userprofile WHERE gmail=@Email", con);
            da.SelectCommand.Parameters.AddWithValue("@Email", EmailID);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod(Description = "To get the integration information of user")]
        public DataSet GetSocialDataFromProfile(string EmailID)
        {
            da = new SqlDataAdapter("select facebook,twitter from userprofile WHERE gmail=@Email", con);
            da.SelectCommand.Parameters.AddWithValue("@Email", EmailID);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod(Description = "To get the Personal information of user")]
        public DataSet GetDOBDataFromProfile(string EmailID)
        {
            da = new SqlDataAdapter("select dateofbirth,country,city,aboutme from userprofile WHERE gmail=@Email", con);
            da.SelectCommand.Parameters.AddWithValue("@Email", EmailID);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod(Description = "Add feedback")]
        public string UpdateFeedback(string EmailID, string Feedback)
        {
            cmd = new SqlCommand("update user set feedback=@Feedback where gmail=@Email", con);
            cmd.Parameters.AddWithValue("@Email", EmailID);
            cmd.Parameters.AddWithValue("@Feedback", Feedback);
            string Status = "";
            con.Open();
            Status = cmd.ExecuteNonQuery().ToString();
            con.Close();
            if (Status == "")
            {
                return "There should be some problem";
            }
            else
            {
                return "Updated Successfully";
            }
        }

        [WebMethod(Description = "update the forgot password")]
        public string ForgotPassword(string EmailID, string Password)
        {
            cmd = new SqlCommand("update [userinfo] set password=@Password where gmail=@Email", con);
            cmd.Parameters.AddWithValue("@Email", EmailID);
            cmd.Parameters.AddWithValue("@Password", Password);
            string Status = "";
            con.Open();
            Status = cmd.ExecuteNonQuery().ToString();
            con.Close();
            if (Status == "")
            {
                return "There should be some problem";
            }
            else
            {
                return "Updated Successfully";
            }
        }





        //[WebMethod]
        //public string DD(DateTime d)
        //{
        //    string s = XmlConvert.ToString(d);
        //    DateTime when = XmlConvert.ToDateTime(s);
        //    string date= when.Date.ToString();////2010-05-24T18:13:00
        //    string[]asd= date.Split(' ');
        //    return asd[0];
        //}




    }
}
