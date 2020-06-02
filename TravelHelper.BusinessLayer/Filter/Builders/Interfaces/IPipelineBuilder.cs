using BusinessLayer.Filter.Pipeline.Interfaces;
using BusinessLayer.Filter.Pipeline.Nodes.Interfaces;

namespace BusinessLayer.Filter.Builders.Interfaces
{
    public interface IPipelineBuilder<T>
    {
        IPipelineBuilder<T> WithNode(IPipelineNode<T> node);
        IPipeline<T> Execute();
    }
}
