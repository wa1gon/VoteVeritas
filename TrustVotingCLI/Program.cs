﻿using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TrustedVoteLibrary;

class Program
{
    static void Main(string[] args)
    {
        // Load the CA certificate and private key
        X509Certificate2 caCert = new X509Certificate2("MyRootCA.pfx", "YourSecurePassword");
        RSA caPrivateKey = caCert.GetRSAPrivateKey();

        // Subject name for the new certificate
        string subjectName = "CN=MySignedCert, O=MyOrganization, C=US";

        // Create the certificate signed by the CA
        X509Certificate2 signedCert = CertificateGenerator.CreateCertificate(subjectName, caCert, caPrivateKey);

        // Save the signed certificate with the private key to a PFX file
        byte[] pfxData = signedCert.Export(X509ContentType.Pfx, "CertPassword");
        System.IO.File.WriteAllBytes("MySignedCert.pfx", pfxData);

        Console.WriteLine("Certificate created and saved successfully.");
    }
}
