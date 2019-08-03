using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using UMFAdmission.Models;

namespace UMFAdmission.Controllers
{
    public class HomeController : Controller
    {
        static List<MultipleChoiceQuestion> result = new List<MultipleChoiceQuestion>();
        static List<TestViewModel> wrongQuestions = new List<TestViewModel>();
        public ActionResult Index()
        {
            List<MultipleChoiceQuestion> multipleChoiceQuestions;
            using (AdmissionUMFDBTestEntities db = new AdmissionUMFDBTestEntities())
            {
                multipleChoiceQuestions = db.MultipleChoiceQuestions.ToList();
            }
            return View(multipleChoiceQuestions);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestSettings()
        {
            TestSettingsViewModel test = new TestSettingsViewModel();
            return View(test);
        }
        [HttpPost]
        public ActionResult TestSettings(TestSettingsViewModel viewModel)
        {

            return RedirectToAction("Test",viewModel);
        }
        [Authorize]
        public ActionResult Test(TestSettingsViewModel viewModel)
        {   
            
            List<MultipleChoiceQuestion> multipleChoiceQuestions;
            using (AdmissionUMFDBTestEntities db = new AdmissionUMFDBTestEntities())
            {
                multipleChoiceQuestions = db.MultipleChoiceQuestions.Where(a => a.Category == "Sistem nervos").ToList();
                List<MultipleChoiceQuestion> multipleChoiceQuestions1 = multipleChoiceQuestions.AsEnumerable()
                    .OrderBy(n => Guid.NewGuid())
                    .Take(Int32.Parse(viewModel.NumberOfQuestions))
                    .Where(a=>a.Category=="Sistem nervos").ToList();
                List<TestViewModel> tvm = new List<TestViewModel>();

                //MultipleChoiceQuestion mC = db.MultipleChoiceQuestions.First();
                foreach (var mC in multipleChoiceQuestions1)
                {
                    TestViewModel m = new TestViewModel();
                    //{
                    //    QuestionID = mC.QuestionID,
                    //    Question = mC.Question,
                    //    A = mC.A,
                    //    B = mC.B,
                    //    C = mC.C,
                    //    D = mC.D,
                    //    AnswerA = mC.AnswerA,
                    //    AnswerB = mC.AnswerB,
                    //    AnswerC = mC.AnswerC,
                    //    AnswerD = mC.AnswerD,
                    //};
                    tvm.Add(m = new TestViewModel
                    {
                        QuestionID = mC.QuestionID,
                        Question = mC.Question,
                        A = mC.A,
                        B = mC.B,
                        C = mC.C,
                        D = mC.D,
                        E = mC.E,
                        AnswerA = mC.AnswerA,
                        AnswerB = mC.AnswerB,
                        AnswerC = mC.AnswerC,
                        AnswerD = mC.AnswerD,
                        AnswerE = mC.AnswerE,
                    }
                    );
                }
                return View(tvm);

            }

            return View();
        }
        [HttpPost]
        public ActionResult Test(List<string> data)
        {


            try
            { 
            
            wrongQuestions = new JavaScriptSerializer().Deserialize<List<TestViewModel>>(data[0]);
            return RedirectToAction("Results");
            }
            catch 
            {
                return null;
            }
        }
     

            public ActionResult Results()
            {

            List<TestViewModel> model = wrongQuestions.ToList();

            return View(model);
             }

             public ActionResult Login()
            {


            return View();
            }


        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                using (AdmissionUMFDBTestEntities db = new AdmissionUMFDBTestEntities())
                {

                    User user = db.Users.FirstOrDefault(u => u.Username == viewModel.Username && u.Password == viewModel.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(viewModel.Username, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect user or password");
                        return View(viewModel);
                    }

                }
            }
            else
            {
                return View(viewModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            using (AdmissionUMFDBTestEntities db = new AdmissionUMFDBTestEntities())
            {
                ///de facut LOG IN
                User newUser = db.Users.FirstOrDefault(a => a.Username == viewModel.Name || a.Mail == viewModel.Email);

                if (ModelState.IsValid)
                {
                    if (newUser != null)
                    {
                        ModelState.AddModelError("", "Already exists an user with this email or username");
                        return View(viewModel);

                    }

                    if (viewModel.Password != viewModel.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "Your password and confirm password doesn`t match");
                        return View(viewModel);
                    }


                    newUser = new User
                    {
                        Mail = viewModel.Email,
                        Username = viewModel.Name,
                        Password = viewModel.Password
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    LoginViewModel login = new LoginViewModel
                    {
                        Username = newUser.Username,
                        Password = newUser.Password
                    };
                    return RedirectToAction("Index", "Home");
                }

                return View(newUser);

            }


        }

    }
}