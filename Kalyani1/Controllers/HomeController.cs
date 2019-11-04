using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Mail;



namespace Kalyani1.Controllers
{
    /*As of the present state of the project, only one controller exists */
    public class HomeController : Controller
    {
        /*HomePage renderring Action*/
        public ActionResult Index()
        {
            return View();
        }

        /*The actions are hereby listed in alphabetical order.*/
        public ActionResult About() //Our Team  Action.
        {
            ViewBag.Message = "It takes a few good men to make a million Good deeds.";

            return View();
        }
        public ActionResult Achievements()
        {
            return View();
        }

        public ActionResult Activities()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Might be used if we need to display a 'list' composed of 'all' images in folder.
        //[NonAction]
        //        public List<string> getImages()
        //        {
        //            string FolderPath = Server.MapPath(Url.Content("~/Content/Images/"));
        //            DirectoryInfo di = new DirectoryInfo(FolderPath);

        ////Get All jpg Files  
        //            List GetCarouselImages = di.GetFiles("*.jpg")
        //                                .Where(file => file.Name.EndsWith(".jpg"))
        //                                .Select(file => file.Name).ToList();

        //        }
        public ActionResult CSR()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }
        public ActionResult GauDhan()
        {
            return View();
        }
        /*Action for Sending emails upon submission of the volunteer form.*/
        [NonAction]
        [HttpPost]
        public ActionResult SendEmail() /*Uses Gmail SMTP server. Limit 100 emails per day.*/
        {
            try
            {


                string EmailBody = "Hi,\n\n Thankyou for filling the volunteer form. We will get in touch with you shortly.\n\n -Kalyani Gaushala";
                MailMessage MailMsg = new MailMessage("Gaushala@kalyani.com", "vinayak.kuthiala@gmail.com");
                MailMsg.Subject = "Volunteer form fill email";
                MailMsg.Body = EmailBody;

                SmtpClient smtpClient = new SmtpClient();
                //MailMessage m = new MailMessage();
                //SmtpClient sc = new SmtpClient();

                //{
                //    m.From = new MailAddress("demouser@gmail.com");
                //    m.To.Add("test@test.com");
                //    m.Subject = "This is a Test Mail";
                //    m.IsBodyHtml = true;
                //    m.Body = "test gmail";
                //    sc.Host = "smtp.gmail.com";
                //    sc.Port = 587;
                //    sc.Credentials = new System.Net.NetworkCredential("istpsnoopy@gmail.com", "istpkhauf");

                //    sc.EnableSsl = true;
                //    sc.Send(m);
                //    Response.Write("Email Send successfully");
                //}
                smtpClient.Send(MailMsg);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


            //If we want to add it to the contact database as well, to ye waala
            //[NonAction]
            //[HttpPost]
            //public ActionResult SendEmail(DAL.Contact contactModel) /*Uses Gmail SMTP server. Limit 100 emails per day.*/
            //{
            //    try
            //    {

            //        new DAL.CRUDContact().AddContact(contactModel);
            //        string EmailBody = "Hi,\n\n Thankyou for filling the volunteer form. We will get in touch with you shortly.\n\n -Kalyani Gaushala";
            //        MailMessage MailMsg = new MailMessage("Gaushala@kalyani.com", "vinayak.kuthiala@gmail.com");
            //        MailMsg.Subject = "Volunteer form fill email";
            //        MailMsg.Body = EmailBody;

            //        SmtpClient smtpClient = new SmtpClient();
            //        //MailMessage m = new MailMessage();
            //        //SmtpClient sc = new SmtpClient();

            //        //{
            //        //    m.From = new MailAddress("demouser@gmail.com");
            //        //    m.To.Add("test@test.com");
            //        //    m.Subject = "This is a Test Mail";
            //        //    m.IsBodyHtml = true;
            //        //    m.Body = "test gmail";
            //        //    sc.Host = "smtp.gmail.com";
            //        //    sc.Port = 587;
            //        //    sc.Credentials = new System.Net.NetworkCredential("istpsnoopy@gmail.com", "istpkhauf");

            //        //    sc.EnableSsl = true;
            //        //    sc.Send(m);
            //        //    Response.Write("Email Send successfully");
            //        //}
            //        smtpClient.Send(MailMsg);

            //        return RedirectToAction("Index");
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            public ActionResult Volunteer()
        {
            return View();
        }







    }
}