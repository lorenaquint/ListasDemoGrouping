using ListasDemo.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace ListasDemo.Droid.Services
{
	using System;
	using ListasDemo.Services;
	using System.IO;


	public class FileHelper:IFileHelper
    {
        public FileHelper()
        {
        }

		public string GetLocalFilePath(string fileName)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, fileName);
		}
	}
}
