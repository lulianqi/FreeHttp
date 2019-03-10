using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService.HttpServer
{
    public class CertificatesHelper
    {
        public static bool SetupSsl(int port)
        {
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine);
            //Use the first cert to configure Ssl
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);
            //Assumption is we have certs. If not then this call will fail :(
            try
            {
                bool found = false;
                foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 cert in store.Certificates)
                {
                    String certHash = cert.GetCertHashString();
                    //Only install certs issued for the machine and has the name as the machine name
                    if (cert.Subject.ToUpper().IndexOf(Environment.MachineName.ToUpper()) >= 0)
                    {
                        try
                        {
                            found = true;
                            //ExecuteNetsh(String.Format("set ssl -i 0.0.0.0:{1} -c \"MY\" -h {0}", certHash, port));
                            ExecuteNetsh(string.Format("http add sslcert ipport=0.0.0.0:{0} certhash={1} appid={{{2}}}", port, certHash, Guid.NewGuid().ToString()));
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                }

                if (!found)
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (store != null)
                {
                    store.Close();
                }
            }

            return true;
        }

        public static void AddCertificateToX509Store(X509Certificate2 cert)
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            //ensure pfx in cert.
            byte[] pfx = cert.Export(X509ContentType.Pfx);
            cert = new X509Certificate2(pfx, (string)null, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
            //then store
            store.Add(cert);
            store.Close();
        }

        public static void BindingCertificate(X509Certificate2 cert, int port)
        {
            if (cert == null)
            {
                throw new ArgumentNullException("your X509Certificate2 is null");
            }
            String certHash = cert.GetCertHashString();
            BindingCertificate(certHash,port);
        }

        public static void BindingCertificate(String certHash, int port)
        {
            if (certHash == null)
            {
                throw new ArgumentNullException("your certHash is null");
            }
            ExecuteNetsh(string.Format("http add sslcert ipport=0.0.0.0:{0} certhash={1} appid={{{2}}} clientcertnegotiation=enable  ", port, certHash, Guid.NewGuid().ToString()));
        }

        private static void ExecuteNetsh(string arguments)
        {
            //netsh http add sslcert ipport=0.0.0.0:8443 certhash=585947f104b5bce53239f02d1c6fed06832f47dc appid={df8c8073-5a4b-4810-b469-5975a9c95230}
            ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process.Start(procStartInfo);
        }
    }
}
