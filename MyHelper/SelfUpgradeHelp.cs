using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.MyHelper
{
    public class SelfUpgradeHelp
    {
        private static HttpClient httpClient = new HttpClient();
        private static string GetFreeHttpDllPath()
        {
            string path = null;
            try
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                path = Uri.UnescapeDataString(uri.Path);
                //Path.GetDirectoryName(path);
            }
            catch
            {
                path = null;
            }
            finally
            {
                if(string.IsNullOrEmpty(path))
                {
                    path = Directory.GetCurrentDirectory() + "\\Scripts\\FreeHttp.dll";
                }
            }
            return path;
        }
        private static async Task<bool> DownloadUpgradeFileAsync(string uri, string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    return false;
                }
            }
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Stream fileStrem = await response.Content.ReadAsStreamAsync();
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await fileStrem.CopyToAsync(fs);
                    fs.Close();
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public static async Task<string> UpdateDllAsync(string sourceFileUrl)
        {
            string path = GetFreeHttpDllPath();
            string oldFilePath = path + ".oldversion";
            string upgradeFile = Path.GetDirectoryName(path) + "/FreeHttpUpgradeFile";
            try
            {
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
                //https://lulianqi.com/file/FreeHttpUpgradeFile
                await DownloadUpgradeFileAsync(sourceFileUrl, upgradeFile);
                System.IO.File.Move(path, oldFilePath);
                System.IO.File.Move(upgradeFile, path);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

    }
}
