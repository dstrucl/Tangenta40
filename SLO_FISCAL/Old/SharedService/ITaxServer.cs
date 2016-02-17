
using System.Xml;
using MNet.SLOTaxService.Messages;
using MNet.SLOTaxService.Services;

namespace MNet.SLOTaxService
{
  public interface ITaxServer
  {
    Settings Settings { get; }

    ReturnValue CalculateProtectiveMark(XmlDocument message);

    ReturnValue Send(string message);

    ReturnValue Send(XmlDocument message);

    ReturnValue SendEcho(string message);

    ReturnValue SendEcho(XmlDocument message);

    ReturnValue SendBusinessPremise(XmlDocument message);

    ReturnValue SendInvoice(XmlDocument message);
  }
}