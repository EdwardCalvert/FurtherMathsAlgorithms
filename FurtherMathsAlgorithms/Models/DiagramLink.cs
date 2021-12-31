using Blazor.Diagrams.Core.Models;

namespace FurtherMathsAlgorithms.Models
{
  public sealed class DiagramLink : LinkModel
  {
    public DiagramLink(PortModel sourcePort, PortModel? targetPort = null) :
      base(sourcePort, targetPort)
    {
      Labels.Add(new DiagramLinkLabel(this, Name));
    }

        public string Name { get; set; }
  }
}
