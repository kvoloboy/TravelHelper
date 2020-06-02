using BusinessLayer.Utils.Filter.Pipeline.Interfaces;
using BusinessLayer.Utils.Filter.Pipeline.Nodes.Interfaces;

namespace BusinessLayer.Utils.Filter.Builders.Interfaces
{
    public interface IPipelineBuilder<T>
    {
        IPipelineBuilder<T> WithNode(IPipelineNode<T> node);
        IPipeline<T> Execute();
    }
}
