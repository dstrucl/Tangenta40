
using System.Deployment.Internal.CodeSigning;
using System.Security.Cryptography;

namespace MNet.SLOTaxService.Services
{
  internal class SetCryptoConfig
  {
    public static void SetAlgorithm()
    {
      CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
    }
  }
}