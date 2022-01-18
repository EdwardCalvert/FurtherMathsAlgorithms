using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;

namespace SharedComponents.Models
{
  public sealed class DirectedLink : LinkModel
  {
    public DirectedLink(PortModel sourcePort, PortModel? targetPort = null) :
      base(sourcePort, targetPort)
    {
      Labels.Add(new DiagramLinkLabel(this, Name));
        TargetMarker = LinkMarker.NewArrow(20, 10);
    }
        public string Name { get; set; }
  }
}
