using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing.Imaging;

namespace mvcRES2019.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    int intSizeLimit = 1048576;
                    if (file.ContentLength <= intSizeLimit)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string filePath = Path.Combine(Server.MapPath("~/tempImages"), fileName);

                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);

                        if (ImageFormat.Jpeg.Equals(img.RawFormat))
                        {
                            ViewBag.type = "That was a jpeg file.";
                        }
                        else if (ImageFormat.Gif.Equals(img.RawFormat))
                        {
                            ViewBag.type = "That was a gif file.";

                        }
                        else if (ImageFormat.Bmp.Equals(img.RawFormat))
                        {
                            ViewBag.type = "That was a bmp file.";
                        }
                        else if (ImageFormat.Png.Equals(img.RawFormat))
                        {
                            ViewBag.type = "png file";
                        }
                        else if (ImageFormat.Tiff.Equals(img.RawFormat))
                        {
                            ViewBag.type = "Tiff file";
                        }
                        else
                        {
                            ViewBag.Msg = "Not a valid image type";
                        }
                        file.SaveAs(filePath);
                        ViewBag.Msg = "Uploaded File Save Successfully";
                    }
                    else
                    {
                        ViewBag.Msg = "Uploaded file exceeds size max";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Uploaded File NOT Saved Successfully " + ex.Message;
                return View();
            }

        }

        [HttpGet]
        public ActionResult MoveFile()
        {
            getImage();
            return View();
        }

        [HttpPost]
        public ActionResult MoveFile(List<string> myList)
        {
            ViewBag.fileName = myList[0];
            return View("MoveFileDisplay");
        }

        public ActionResult ApproveFile(string fileToApprove, string looks)
        {
            if (!String.IsNullOrEmpty(fileToApprove) && looks == "good")
            {
                string sourceFile = Server.MapPath("~/tempImages/" + fileToApprove);
                string destinationFile = Server.MapPath("~/Content/images/" + fileToApprove);
                if (!System.IO.File.Exists(destinationFile))
                {

                    System.IO.File.Move(sourceFile, destinationFile);
                    ViewBag.Msg = "File Successfully Moved";

                }
                else
                {
                    ViewBag.Msg = "File Exists with that name...please resolve the issus";
                }


            }
            else
            {
                string sourceFile = Server.MapPath("~/tempImages/" + fileToApprove);
                string destFile = Server.MapPath("~/Content/images/" + fileToApprove);
                System.IO.File.Move(sourceFile, destFile);
                ViewBag.Msg = "Ok, if it is that bad...we have scheduled it for deletion";
            }
            return View("MoveFileDisplay");
        }

        public void getImage()
        {
            string strFolderPath = Server.MapPath("~/tempImages");
            if (Directory.Exists(strFolderPath))
            {
                string[] fileEntries = Directory.GetFiles(strFolderPath);
                string fileName = null;
                string[] myList = new string[fileEntries.Count()];
                int i = 0;
                foreach (string f in fileEntries)
                {
                    fileName = Path.GetFileName(f);
                    myList[i++] = fileName;
                }
                SelectList list = new SelectList(myList);
                ViewBag.myList = list;
            }
            else
            {
                ViewBag.Msg = "Directory does not exist";
            }
        }
    }
}