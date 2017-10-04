using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MatchMiddleBox.Models;


namespace MatchMiddleBox.Controllers
{
    public class ImagesController : Controller
    {
        Images img = new Images();
        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RefreshImages()
        {

            ArrayList FruitImages = new ArrayList();
            img.MatchBox = new string[9];

            //Create an arrayList and add fruit image srcs 
            FruitImages.Add("../Img/apple.jpg");
            FruitImages.Add("../Img/orange.jpg");
            FruitImages.Add("../Img/banana.jpg");
            FruitImages.Add("../Img/blueberry.jpg");
            FruitImages.Add("../Img/cherry.jpg");
            FruitImages.Add("../Img/grapes.jpg");
            FruitImages.Add("../Img/mango.jpg");
            FruitImages.Add("../Img/strawberry.jpg");
            FruitImages.Add("../Img/watermelon.jpg");

            int key = 0;
            Random random = new Random();
            int randomNumber;

            //Generate unique randomn number as an index in each iteration 
            //and assign the corrosponding img src value to the MatchBox ArrayList
            while (key < 9)
            {
                randomNumber = random.Next(0, FruitImages.Count - 1);
                img.MatchBox[key] = FruitImages[randomNumber].ToString();
                FruitImages.RemoveAt(randomNumber);
                key++;
            }

            return Json(img.MatchBox, JsonRequestBehavior.AllowGet);
        }

    }
}