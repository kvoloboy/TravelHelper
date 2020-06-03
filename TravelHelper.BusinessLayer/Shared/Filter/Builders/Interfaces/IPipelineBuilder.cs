using BusinessLayer.Shared.Filter.Pipeline.Interfaces;
using BusinessLayer.Shared.Filter.Pipeline.Nodes.Interfaces;

namespace BusinessLayer.Shared.Filter.Builders.Interfaces
{
    public interface IPipelineBuilder<T>
    {
        IPipelineBuilder<T> WithNode(IPipelineNode<T> node);
        IPipeline<T> Execute();
    }
}
