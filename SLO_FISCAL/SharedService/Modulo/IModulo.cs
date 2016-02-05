
namespace MNet.SLOTaxService.Modulo
{
  internal interface IModulo
  {
    int CalculateModulo10(string value);

    string AppendModulo10(string value);

    bool CheckModulo10(string value);
  }
}