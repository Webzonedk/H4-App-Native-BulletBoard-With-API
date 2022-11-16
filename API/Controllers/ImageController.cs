using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ImageController : Controller
    {
        internal List<string> images = new();

        [Route("getimages]")]
        [HttpGet]
        public IActionResult GetImages()
        {
            return Ok(images);
        }




        [Route("post]")]
        [HttpPost]
        public IActionResult PostImages([FromBody] string image)
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




        [Route("delete]")]
        [HttpPost]
        public IActionResult DeleteImages([FromBody] string image)
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


    }
}
