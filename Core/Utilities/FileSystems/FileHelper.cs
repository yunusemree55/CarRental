using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileSystems
{
    public class FileHelper
    {
        public static string newPath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFileName = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Month
                + "_" + DateTime.Now.Day
                + "_" + DateTime.Now.Year + fileExtension;

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $@"{path}\{creatingUniqueFileName}";

            return result;

        }
        
        public static string AddSync (IFormFile file)
        {
            var result = newPath(file);

            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length>0)
                {
                    using (var stream = new FileStream(sourcePath,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Move(sourcePath, result);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                if (sourcePath.Length>0)
                {
                    using (var stream = new FileStream(result,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {

                return exception.Message ;
            }

            return result;
        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();

        }
    }
}
