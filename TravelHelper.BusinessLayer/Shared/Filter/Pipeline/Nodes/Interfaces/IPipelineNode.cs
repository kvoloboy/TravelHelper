namespace BusinessLayer.Shared.Filter.Pipeline.Nodes.Interfaces
{
    public interface IPipelineNode<TResult>
    {
        TResult Execute(TResult input);
    }
}
