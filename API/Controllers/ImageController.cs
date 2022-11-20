using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace API.Controllers
{
    //[ApiController]
    //[Route("[controller]")]

    public class ImageController : Controller
    {
        internal List<Image> images = new();
       // internal List<byte[]> byteImages = new();
      
        internal Image _image = new("Image was not filled");

        public ImageController(IConfiguration configuration)
        {

        }




        [HttpGet("downloadimage")]
        public IActionResult GetImages()
        {

            try
            {
                return Ok(_image);
            }
            catch (Exception)
            {
                return StatusCode(401, "Image Could not be downloaded");
            }
        }



        [HttpPost("uploadimage")]
        public IActionResult PostImages([FromBody] Image image)
        {
            try
            {
                if (image != null)
                {
                _image = image;
                }
                return Ok(_image);
            }
            catch (Exception)
            {
                return StatusCode(401, "Image Could not be uploaded");
            }
        }




        //[HttpPost("deletesingleimage")]
        //public IActionResult DeleteImages([FromBody] Image image)
        //{
        //    try
        //    {
        //        images.RemoveAt(images.IndexOf(image));
        //        return Ok(images);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(401, "Image does not exist in list");
        //    }
        //}



        //public string TestImage()
        //{


        //    byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20221103_173109.jpg");
        //    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
        //    Debug.WriteLine(base64ImageRepresentation);
        //    return base64ImageRepresentation;

        //}




        //public List<Image> TestImageObject()
        //{
        //    // byte[] imageArray = System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20220915_080453.jpg");

        //    images.Add(new Image(Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20220912_105127.jpg"))));
        //    images.Add(new Image(Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20221103_173109.jpg"))));
        //    images.Add(new Image(Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20221006_140053.jpg"))));
        //    images.Add(new Image(Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20220915_080453.jpg"))));
        //    images.Add(new Image(Convert.ToBase64String(System.IO.File.ReadAllBytes(@"C:\Users\kent3211\Development\h4\App\Native\BulletBoard\API\Assets\20220818_111926.jpg"))));
                
                
       
        //    //Image base64ImageRepresentation = new(Convert.ToBase64String(imageArray));

        //   // images.Add(base64ImageRepresentation);
        //    return images;
        //}


    }
}
