
using System.Xml;
using MNet.SLOTaxService.Services;

namespace MNet.SLOTaxService.Messages
{
  public interface IReturnValue
  {
    BarCodes BarCodes { get; }
    string ErrorMessage { get; }
    ErrorMessageSource ErrorMessageSource { get; }
    XmlDocument MessageReceivedFromFurs { get; }
    XmlDocument MessageSendToFurs { get; }
    MessageType MessageType { get; }
    string ProtectedID { get; }
    SendingStep Step { get; }
    bool Success { get; }
    string UniqueInvoiceID { get; }
  }
}