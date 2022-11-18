using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API.Controllers
{
    //[ApiController]
    //[Route("[controller]")]

    public class ImageController : Controller
    {
        internal List<Image> images = new();

        public ImageController(IConfiguration configuration)
        {

        }




        [HttpGet("download")]
        public IActionResult Test()
        {

            try
            {

                //TestImageObject()
               // string test = "tester lige her";
                return Ok(TestImage());
            }
            catch (Exception)
            {
                return StatusCode(401, "Image Could not be downloaded");
            }
        }



        [HttpGet("downloadimages")]
        public IActionResult GetImages()
        {
            
            try
            {

                //TestImageObject()
                string test = "tester lige her";
                return Ok(test );
            }
            catch (Exception)
            {
                return StatusCode(401, "Image Could not be downloaded");
            }
        }





        [HttpPost("uploadimages")]
        public IActionResult PostImages([FromBody] Image image)
        {
            try
            {
                if (!images.Contains(image))
                {
                    images.Add(image);
                }
                return Ok(images);
            }
            catch (Exception)
            {
                return StatusCode(401, "Image Could not be uploaded");
            }
        }





        [HttpPost("deletesingleimage")]
        public IActionResult DeleteImages([FromBody] Image image)
        {
            try
            {
                images.RemoveAt(images.IndexOf(image));
                return Ok(images);
            }
            catch (Exception)
            {
                return StatusCode(401, "Image does not exist in list");
            }
        }

        public string TestImage()
        {


            byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20221103_173109.jpg");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            Debug.WriteLine(base64ImageRepresentation);
            return base64ImageRepresentation;

        }

        public List<Image> TestImageObject()
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20221103_173109.jpg");
            Image base64ImageRepresentation = new(Convert.ToBase64String(imageArray));
        
            images.Add(base64ImageRepresentation);
            return images;
        }


    }
}
