﻿// <copyright file="SetCryptoConfig.cs" company="MNet">
//     Copyright (c) Matjaz Prtenjak All rights reserved.
// </copyright>
// <author>Matjaz Prtenjak</author>
//-----------------------------------------------------------------------

using System.Deployment.Internal.CodeSigning;
using System.Security.Cryptography;
using Security.Cryptography;

namespace MNet.SLOTaxService.Services
{
  public class SetCryptoConfig
  {
    public static void SetAlgorithm()
    {
      CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
    }

     public static System.Net.SecurityProtocolType SetTLSProtocol()
     {
          return System.Net.SecurityProtocolType.Ssl3;
     }
}
}