using System;
using System.IO;
using ListasDemo.iOS.Services;
using ListasDemo.Services;
using Xamarin.Forms;
[assembly:Dependency(typeof(FileHelper))]
namespace ListasDemo.iOS.Services
{
	public class FileHelper:IFileHelper
    {
        public FileHelper()
        {
        }

		public string GetLocalFilePath(string fileName)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..","DataBases");
			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}
			return Path.Combine(libFolder, fileName);
		}
	}
}
